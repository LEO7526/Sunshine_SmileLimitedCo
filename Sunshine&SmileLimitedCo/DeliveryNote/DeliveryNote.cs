using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SunshineSmileLimitedCo
{
    public partial class DeliveryNote : Form
    {
        private readonly string _deliveryNo;

        public DeliveryNote(string deliveryNo)
        {
            InitializeComponent();
            _deliveryNo = deliveryNo;
            this.Load += DeliveryNote_Load;
        }

        private void DeliveryNote_Load(object sender, EventArgs e)
        {
            LoadDeliveryData(_deliveryNo); // Now loads with the correct delivery number, all labels populated
        }

        // Pass the delivery number (not the order number!) for best results
        public void LoadDeliveryData(string deliveryNo)
        {
            lblDeliveryNoValue.Text = deliveryNo ?? "Null";

            string connectionString = "server=127.0.0.1;user=root;password=;database=projectdb";
            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Get delivery info, customer info, and order info
                    string infoQuery = @"
                SELECT 
                    d.delivery_no, d.delivery_date, d.oid, 
                    c.cname, c.ctel, c.caddr
                FROM delivery d
                JOIN orders o ON d.oid = o.oid
                JOIN customer c ON o.cid = c.cid
                WHERE d.delivery_no = @deliveryNo
                LIMIT 1";
                    using (var cmd = new MySqlCommand(infoQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@deliveryNo", deliveryNo);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblDeliveryNoValue.Text = reader["delivery_no"]?.ToString() ?? "Null";
                                lblDeliveryDateValue.Text = reader["delivery_date"]?.ToString() ?? "Null";
                                lblOrderNoValue.Text = reader["oid"]?.ToString() ?? "Null";
                                lblNameValue1.Text = reader["cname"]?.ToString() ?? "Null";
                                lblPhoneValue.Text = reader["ctel"]?.ToString() ?? "Null";
                                lblAddressValue.Text = reader["caddr"]?.ToString() ?? "Null";
                            }
                            else
                            {
                                MessageBox.Show("No delivery/order/customer info found for this Delivery No.");
                                return;
                            }
                        }
                    }

                    // 2. Load order items for the order in this delivery
                    string itemsQuery = @"
                SELECT 
                    p.pid AS ID, 
                    p.pname AS Name, 
                    o.ocost AS UnitPrice, 
                    o.oqty AS QTY, 
                    (o.ocost * o.oqty) AS Amount
                FROM delivery d
                JOIN orders o ON d.oid = o.oid
                JOIN product p ON o.pid = p.pid
                WHERE d.delivery_no = @deliveryNo
            ";
                    using (var cmd = new MySqlCommand(itemsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@deliveryNo", deliveryNo);
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridViewItems.Rows.Clear();
                            decimal total = 0;

                            foreach (DataRow dr in dt.Rows)
                            {
                                string id = dr["ID"].ToString();
                                string name = dr["Name"].ToString();
                                string unitPrice = Convert.ToDecimal(dr["UnitPrice"]).ToString("C2");
                                int qty = Convert.ToInt32(dr["QTY"]);
                                decimal amount = Convert.ToDecimal(dr["Amount"]);
                                total += amount;

                                dataGridViewItems.Rows.Add(id, name, unitPrice, qty, amount.ToString("C2"));
                            }

                            lblTotalValue.Text = total.ToString("C2");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load delivery note data: " + ex.Message);
                }
            }
        }


    }
}
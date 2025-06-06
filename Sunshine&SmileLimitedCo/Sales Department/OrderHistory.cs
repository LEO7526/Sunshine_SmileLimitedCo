using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Sales_Department
{
    public partial class OrderHistory : Form
    {
        private readonly string customerId;
        private readonly string staffId;
        private readonly string staffRole;

        public OrderHistory(string customerId, string staffId, string staffRole)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.staffId = staffId;
            this.staffRole = staffRole;

            dgvOrderHistory.AutoGenerateColumns = true;
            dgvOrderHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Load += OrderHistory_Load;
            btnBack.Click += btnBack_Click;
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            using (var conn = new MySqlConnection("server=127.0.0.1;user=root;password=;database=projectdb"))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT o.oid AS 'Order ID',
                               
                               o.cid AS 'Customer ID',
                               c.cname AS 'Customer Name',
                               o.odate AS 'Order Date'
                        FROM Orders o
                        JOIN Customer c ON o.cid = c.cid
                        WHERE o.cid = @CustomerId
                        ORDER BY o.odate DESC
                    ";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvOrderHistory.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load order history: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
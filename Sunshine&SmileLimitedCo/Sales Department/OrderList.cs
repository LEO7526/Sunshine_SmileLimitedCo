using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Sales_Department
{
    public partial class OrderList : Form
    {
        private readonly string staffId;
        private readonly string staffRole;

        public OrderList(string staffId, string staffRole)
        {
            InitializeComponent();
            this.staffId = staffId;
            this.staffRole = staffRole;

            dgvOrderList.AutoGenerateColumns = true;
            dgvOrderList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderList.CellDoubleClick += dgvOrderList_CellDoubleClick;
            btnSelectOrder.Click += btnSelectOrder_Click; // Button for selecting order
            LoadOrderList();
        }

        private void LoadOrderList()
        {
            using (var conn = new MySqlConnection("server=127.0.0.1;user=root;password=;database=projectdb"))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT o.oid AS 'Order ID',
                               o.odate AS 'Order Date',
                               o.cid AS 'Customer ID',
                               c.cname AS 'Customer Name'
                        FROM Orders o
                        JOIN Customer c ON o.cid = c.cid
                        ORDER BY o.odate DESC
                    ";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvOrderList.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load order list: " + ex.Message);
                }
            }
        }

        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowOrderDetails();
            }
        }

        private void btnSelectOrder_Click(object sender, EventArgs e)
            
        {
            this.Hide();
            ShowOrderDetails();
        }

        private void ShowOrderDetails()
        {
            if (dgvOrderList.SelectedRows.Count > 0)
            {
                string orderId = dgvOrderList.SelectedRows[0].Cells["Order ID"].Value.ToString();
                var orderForm = new View_and_Edit_Order(orderId, staffId, staffRole);
                orderForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order.");
            }
        }
    }
}
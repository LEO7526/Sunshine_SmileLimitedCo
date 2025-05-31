using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Sales_Department
{
    public partial class View_and_Edit_Order : Form
    {
        private DataTable ordersTable;

        public View_and_Edit_Order()
        {
            InitializeComponent();
            dgvOrders.AutoGenerateColumns = true;
            dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
            InitializeOrderControls();
            LoadOrders();
        }

        // Initialize sorting/filtering controls (if not set up in Designer)
        private void InitializeOrderControls()
        {
            // Populate sort column ComboBox
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Order ID");
            cmbSortColumn.Items.Add("Order Date");
            cmbSortColumn.Items.Add("Product ID");
            cmbSortColumn.Items.Add("Quantity");
            cmbSortColumn.Items.Add("Total Cost");
            cmbSortColumn.Items.Add("Customer ID");
            cmbSortColumn.SelectedIndex = -1; // No sort by default

            // Ensure descending checkbox is unchecked by default
            chkDescending.Checked = false;

            // Wire up filter/sort button
            btnApplyFilterSort.Click += btnApplyFilterSort_Click;
        }

        // Load all orders from the database
        private void LoadOrders()
        {
            using (var conn = OpenDatabaseConnection())
            {
                if (conn == null) return;
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                            oid AS 'Order ID', 
                            CAST(odate AS CHAR) AS 'Order Date', 
                            pid AS 'Product ID', 
                            oqty AS 'Quantity', 
                            ocost AS 'Total Cost', 
                            cid AS 'Customer ID' 
                            FROM Orders";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        ordersTable = new DataTable();
                        adapter.Fill(ordersTable);
                        dgvOrders.DataSource = ordersTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load orders: {ex.Message}");
                }
            }
        }

        // Apply sorting and filtering based on user input
        private void btnApplyFilterSort_Click(object sender, EventArgs e)
        {
            if (ordersTable == null) return;

            string filter = "";
            if (!string.IsNullOrWhiteSpace(txtFilterCustomerId.Text))
            {
                string customerId = txtFilterCustomerId.Text.Replace("'", "''");
                filter = $"Convert([Customer ID], 'System.String') LIKE '%{customerId}%'";
            }

            string sort = "";
            if (cmbSortColumn.SelectedIndex != -1)
            {
                string sortColumn = cmbSortColumn.SelectedItem.ToString();
                string sortDirection = chkDescending.Checked ? "DESC" : "ASC";
                sort = $"[{sortColumn}] {sortDirection}";
            }

            DataView dv = ordersTable.DefaultView;
            dv.RowFilter = filter;
            dv.Sort = sort;
            dgvOrders.DataSource = dv;
        }

        // Helper: Open MySQL connection (adjust connection string as needed)
        private MySqlConnection OpenDatabaseConnection()
        {
            try
            {
                string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb";
                return new MySqlConnection(MySqlCon);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}");
                return null;
            }
        }

        // Handle double-click on a row to open detailed order info
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.Rows[e.RowIndex].Cells["Order ID"].Value != null)
            {
                // Retrieve order details from the selected row
                var row = dgvOrders.Rows[e.RowIndex];
                string orderId = row.Cells["Order ID"].Value.ToString();
                string orderDate = row.Cells["Order Date"].Value.ToString();
                string productId = row.Cells["Product ID"].Value.ToString();
                string quantity = row.Cells["Quantity"].Value.ToString();
                string totalCost = row.Cells["Total Cost"].Value.ToString();
                string customerId = row.Cells["Customer ID"].Value.ToString();

                // Open the detailedOrderInfo form and pass the order details
                var detailForm = new detailedOrderInfo(orderId, orderDate, productId, quantity, totalCost, customerId);
                detailForm.ShowDialog();

                // Optionally, reload orders after editing
                LoadOrders();
            }
        }
    }
}

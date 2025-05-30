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
                        odate AS 'Order Date', 
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
                dgvOrders.AutoGenerateColumns = true;
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
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Sales_Department
{
    public partial class View_and_Edit_Order : Form
    {
        private DataTable ordersTable;
        private readonly string staffId;
        private readonly string staffRole;
        private readonly string orderId;

        public View_and_Edit_Order(string staffId, string staffRole)
        {
            InitializeComponent();
            this.staffId = staffId;
            this.staffRole = staffRole;

            dgvOrders.AutoGenerateColumns = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            InitializeOrderControls();
            this.Load += View_and_Edit_Order_Load;
        }
        public View_and_Edit_Order(string orderId, string staffId, string staffRole)
        {
            InitializeComponent();
            this.staffId = staffId;
            this.staffRole = staffRole;
            this.orderId = orderId;

            dgvOrders.AutoGenerateColumns = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            InitializeOrderControls();
            this.Load += View_and_Edit_Order_Load;
        }

        private void View_and_Edit_Order_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void InitializeOrderControls()
        {
            cmbSortColumn.Items.Clear();
            cmbSortColumn.Items.Add("Product ID");
            cmbSortColumn.Items.Add("Product Name");
            cmbSortColumn.Items.Add("Unit Price");
            cmbSortColumn.Items.Add("Quantity");
            cmbSortColumn.Items.Add("Total Cost");
            cmbSortColumn.SelectedIndex = -1;
            chkDescending.Checked = false;
            btnApplyFilterSort.Click += btnApplyFilterSort_Click;
        }

        private void LoadOrders()
        {
            using (var conn = OpenDatabaseConnection())
            {
                if (conn == null) return;
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            o.oid AS 'Order ID',
                            CAST(o.odate AS CHAR) AS 'Order Date',
                            o.cid AS 'Customer ID',
                            c.cname AS 'Customer Name',
                            p.pid AS 'Product ID',
                            p.pname AS 'Product Name',
                            p.pcost AS 'Unit Price',
                            op.pqty AS 'Quantity',
                            (p.pcost * op.pqty) AS 'Total Cost'
                        FROM Orders o
                        JOIN Customer c ON o.cid = c.cid
                        JOIN OrderProducts op ON o.oid = op.oid
                        JOIN Product p ON op.pid = p.pid
                        WHERE o.oid = @OrderId
                    ";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            ordersTable = new DataTable();
                            adapter.Fill(ordersTable);

                            dgvOrders.DataSource = ordersTable;
                            HideLabelColumns();
                            dgvOrders.DataBindingComplete += DgvOrders_DataBindingComplete;

                            // Set the order/customer info labels if present
                            if (ordersTable.Rows.Count > 0)
                            {
                                var row = ordersTable.Rows[0];
                                lblOrderID.Text = row["Order ID"].ToString();
                                lblOrderDate.Text = row["Order Date"].ToString();
                                lblCustomerID.Text = row["Customer ID"].ToString();
                                lblCustomerName.Text = row["Customer Name"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load orders: {ex.Message}");
                }
            }
        }

        private void DgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvOrders.DataBindingComplete -= DgvOrders_DataBindingComplete; // prevent repeated calls
        }

        private void HideLabelColumns()
        {
            string[] labelColumns = { "Order ID", "Order Date", "Customer ID", "Customer Name" };
            foreach (string colName in labelColumns)
            {
                if (dgvOrders.Columns.Contains(colName))
                {
                    dgvOrders.Columns[colName].Visible = false;
                }
            }
        }

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

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvOrders.Rows[e.RowIndex];

                DataRowView rowView = row.DataBoundItem as DataRowView;
                if (rowView == null) return;

                string orderId = rowView["Order ID"]?.ToString() ?? "";
                string orderDate = rowView["Order Date"]?.ToString() ?? "";
                string productId = rowView["Product ID"]?.ToString() ?? "";
                string quantity = rowView["Quantity"]?.ToString() ?? "";
                string totalCost = rowView["Total Cost"]?.ToString() ?? "";
                string customerId = rowView["Customer ID"]?.ToString() ?? "";

                // Open detailed info form if you have one
                // var detailForm = new DetailedOrderInfo(orderId, orderDate, productId, quantity, totalCost, customerId, staffId, staffRole);
                // detailForm.ShowDialog();

                // Reload if any changes were made
                LoadOrders();
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvOrders.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    lblOrderID.Text = rowView["Order ID"]?.ToString() ?? "";
                    lblOrderDate.Text = rowView["Order Date"]?.ToString() ?? "";
                    lblCustomerID.Text = rowView["Customer ID"]?.ToString() ?? "";
                    lblCustomerName.Text = rowView["Customer Name"]?.ToString() ?? "";
                }
            }
            else
            {
                lblOrderID.Text = "";
                lblOrderDate.Text = "";
                lblCustomerID.Text = "";
                lblCustomerName.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var orderListForm = new OrderList(staffId, staffRole);
            orderListForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Assume selectedRow or current order has a customer ID property/column
            string customerId = lblCustomerID.Text; // or wherever you store/display it

            if (string.IsNullOrEmpty(customerId))
            {
                MessageBox.Show("Please select an order first.");
                return;
            }

            var historyForm = new OrderHistory(customerId, staffId, staffRole);
            historyForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
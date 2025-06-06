using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Sales_Department
{
    public partial class CustomerList : Form
    {
        public string SelectedCustomerId { get; private set; }

        public CustomerList()
        {
            InitializeComponent();
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;
            btnBack.Click += btnBack_Click;

            this.Load += CustomerList_Load;
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (var conn = new MySqlConnection("server=127.0.0.1;user=root;password=;database=projectdb"))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT cid AS 'Customer ID', cname AS 'Customer Name', ctel AS 'Customer Phone' 
                FROM Customer
                ORDER BY cid
            ";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvCustomers.DataSource = dt;
                    }

                    // Add 'Add' button column if not already added
                    if (!dgvCustomers.Columns.Contains("Add"))
                    {
                        DataGridViewButtonColumn addButton = new DataGridViewButtonColumn();
                        addButton.Name = "Add";
                        addButton.HeaderText = "Add";
                        addButton.Text = "Add";
                        addButton.UseColumnTextForButtonValue = true;
                        dgvCustomers.Columns.Add(addButton);
                    }

                    // Optionally set the button column to the last position
                    dgvCustomers.Columns["Add"].DisplayIndex = dgvCustomers.Columns.Count - 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load customers: " + ex.Message);
                }
            }
        }

        // Handle button click in DataGridView to go back to edit form
        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomers.Columns[e.ColumnIndex].Name == "Add" && e.RowIndex >= 0)
            {
                var customerId = dgvCustomers.Rows[e.RowIndex].Cells["Customer ID"].Value.ToString();

                // Your logic to return to the edit form with the selected customerId.
                // Example: set property and close dialog if this form is a modal selector
                this.SelectedCustomerId = customerId;
                this.DialogResult = DialogResult.OK;
                this.Close();

                // Or, if you navigate to the edit form directly:
                // var editForm = new EditCustomerForm(customerId);
                // editForm.Show();
                // this.Close();
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedCustomerId = dgvCustomers.Rows[e.RowIndex].Cells["Customer ID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
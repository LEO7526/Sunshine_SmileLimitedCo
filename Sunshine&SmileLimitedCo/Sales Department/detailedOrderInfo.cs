using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Sales_Department
{
    public partial class detailedOrderInfo : Form
    {
        public detailedOrderInfo()
        {
            InitializeComponent();
            // Ensure event handlers are wired up if not done in Designer
            btnSave.Click += btnSave_Click;
            btnDelete.Click += btnDelete_Click;
        }

        public detailedOrderInfo(string orderId, string orderDate, string productId, string quantity, string totalCost, string customerId)
            : this()
        {
            txtOrderId.Text = orderId;
            txtOrderDate.Text = orderDate;
            txtProductId.Text = productId;
            txtQuantity.Text = quantity;
            txtTotalCost.Text = totalCost;
            txtCustomerId.Text = customerId;
        }

        // Input validation method
        private bool ValidateInputs()
        {
            // Required fields
            if (string.IsNullOrWhiteSpace(txtOrderId.Text) ||
                string.IsNullOrWhiteSpace(txtOrderDate.Text) ||
                string.IsNullOrWhiteSpace(txtProductId.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtTotalCost.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Numeric validation
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Quantity must be a non-negative integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtTotalCost.Text, out decimal cost) || cost < 0)
            {
                MessageBox.Show("Total Cost must be a non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Date validation
            if (!DateTime.TryParse(txtOrderDate.Text, out DateTime orderDate))
            {
                MessageBox.Show("Order Date must be a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Add more validation as needed

            return true;
        }

        // Save button click event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                using (var conn = new MySqlConnection("server=127.0.0.1;user=root;password=;database=projectdb"))
                {
                    conn.Open();
                    string query = @"UPDATE Orders 
                                         SET odate = @OrderDate, 
                                             pid = @ProductId, 
                                             oqty = @Quantity, 
                                             ocost = @TotalCost, 
                                             cid = @CustomerId
                                         WHERE oid = @OrderId";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", txtOrderId.Text);
                        cmd.Parameters.AddWithValue("@OrderDate", txtOrderDate.Text);
                        cmd.Parameters.AddWithValue("@ProductId", txtProductId.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                        cmd.Parameters.AddWithValue("@TotalCost", txtTotalCost.Text);
                        cmd.Parameters.AddWithValue("@CustomerId", txtCustomerId.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order details saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No order was updated. Please check the Order ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete button click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                MessageBox.Show("Order ID is required to delete an order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this order?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (var conn = new MySqlConnection("server=127.0.0.1;user=root;password=;database=projectdb"))
                {
                    conn.Open();
                    string query = "DELETE FROM Orders WHERE oid = @OrderId";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", txtOrderId.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No order was deleted. Please check the Order ID.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Sales_Department
{
    public partial class DetailedOrderInfo : Form
    {
        private readonly string staffId;
        private readonly string staffRole;
        private readonly string connStr;

        public DetailedOrderInfo()
        {
            InitializeComponent();
            connStr = ConfigurationManager.ConnectionStrings["projectdb"]?.ConnectionString
                      ?? "server=127.0.0.1;user=root;password=;database=projectdb";
        }

        public DetailedOrderInfo(
            string orderId,
            string orderDate,
            string productId,
            string quantity,
            string totalCost,
            string customerId,
            string staffId,
            string staffRole)
            : this()
        {
            txtOrderId.Text = orderId;
            txtOrderDate.Text = orderDate;
            txtProductId.Text = productId;
            txtQuantity.Text = quantity;
            txtTotalCost.Text = totalCost;
            txtCustomerId.Text = customerId;
            this.staffId = staffId;
            this.staffRole = staffRole;
        }

        private bool ValidateInputs()
        {
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
            if (!DateTime.TryParse(txtOrderDate.Text, out DateTime orderDate))
            {
                MessageBox.Show("Order Date must be a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                // Get original order values before updating
                var originalOrder = GetOriginalOrder(txtOrderId.Text);

                using (var conn = new MySqlConnection(connStr))
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
                            // Log only the changed fields, before and after
                            string changeDetails = BuildChangeDetails(originalOrder);
                            LogOrderChange(
                                txtOrderId.Text,
                                "UPDATE",
                                changeDetails
                            );
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
                // Optionally, get original data before delete for logging
                var originalOrder = GetOriginalOrder(txtOrderId.Text);

                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM Orders WHERE oid = @OrderId";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", txtOrderId.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            string details = $"Order deleted: {FormatOrderDetails(originalOrder)}";
                            LogOrderChange(
                                txtOrderId.Text,
                                "DELETE",
                                details
                            );
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

        private void LogOrderChange(string orderId, string changeType, string changeDetails)
        {
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"INSERT INTO order_change_log (order_id, staff_id, staff_role, change_type, change_details, change_time)  
                                        VALUES (@orderId, @staffId, @staffRole, @changeType, @changeDetails, @changeTime)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@staffId", staffId ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@staffRole", staffRole ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@changeType", changeType);
                        cmd.Parameters.AddWithValue("@changeDetails", changeDetails);
                        cmd.Parameters.AddWithValue("@changeTime", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to log change: " + ex.Message, "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Helper methods

        // Fetches the original order from DB, returns as tuple
        private (string OrderDate, string ProductId, string Quantity, string TotalCost, string CustomerId) GetOriginalOrder(string orderId)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT odate, pid, oqty, ocost, cid FROM Orders WHERE oid = @OrderId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                reader["odate"].ToString(),
                                reader["pid"].ToString(),
                                reader["oqty"].ToString(),
                                reader["ocost"].ToString(),
                                reader["cid"].ToString()
                            );
                        }
                        else
                        {
                            return (null, null, null, null, null);
                        }
                    }
                }
            }
        }

        // Builds a string showing which fields changed, with before and after values
        private string BuildChangeDetails((string OrderDate, string ProductId, string Quantity, string TotalCost, string CustomerId) original)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order updated:");
            if (original.OrderDate != txtOrderDate.Text)
                sb.AppendLine($" - OrderDate: '{original.OrderDate}' → '{txtOrderDate.Text}'");
            if (original.ProductId != txtProductId.Text)
                sb.AppendLine($" - ProductId: '{original.ProductId}' → '{txtProductId.Text}'");
            if (original.Quantity != txtQuantity.Text)
                sb.AppendLine($" - Quantity: '{original.Quantity}' → '{txtQuantity.Text}'");
            if (original.TotalCost != txtTotalCost.Text)
                sb.AppendLine($" - TotalCost: '{original.TotalCost}' → '{txtTotalCost.Text}'");
            if (original.CustomerId != txtCustomerId.Text)
                sb.AppendLine($" - CustomerId: '{original.CustomerId}' → '{txtCustomerId.Text}'");
            if (sb.Length == "Order updated:\n".Length)
                sb.AppendLine(" (No actual changes detected)");
            return sb.ToString();
        }

        // Formats the order details for delete log
        private string FormatOrderDetails((string OrderDate, string ProductId, string Quantity, string TotalCost, string CustomerId) order)
        {
            if (order.OrderDate == null) return "(Order not found)";
            return $"Date={order.OrderDate}, ProductID={order.ProductId}, Quantity={order.Quantity}, TotalCost={order.TotalCost}, CustomerID={order.CustomerId}";
        }
    }
}
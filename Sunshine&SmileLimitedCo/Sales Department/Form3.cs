using MySql.Data.MySqlClient;
using Sunshine_SmileLimitedCo.Sales_Department;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo
{
    public partial class Form3 : Form
    {
        // Shopping cart: pid, pname, price, quantity, subtotal
        private readonly List<(string pid, string pname, decimal price, int quantity, decimal subtotal)> cart =
            new List<(string, string, decimal, int, decimal)>();

        public Form3()
        {
            InitializeComponent();
            ConfigureForm();
            LoadCustomerIds();
            SetupCartGrid();

            // Add a button for product selection if not present
            if (this.Controls.Find("btnSelectProduct", false).Length == 0)
            {
                Button btnSelectProduct = new Button
                {
                    Name = "btnSelectProduct",
                    Text = "Select Product",
                    Location = new Point(400, 10),
                    Size = new Size(120, 30)
                };
                btnSelectProduct.Click += btnSelectProduct_Click;
                this.Controls.Add(btnSelectProduct);
            }
        }

        // Set up form properties
        private void ConfigureForm()
        {
            Text = "Order Entry";
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
        }

        // Load Customer IDs into the ComboBox
        private void LoadCustomerIds()
        {
            try
            {
                string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb";
                using (var conn = new MySqlConnection(MySqlCon))
                {
                    conn.Open();
                    string query = "SELECT cid FROM customer";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbCustomerId.Items.Clear();
                        while (reader.Read())
                        {
                            cmbCustomerId.Items.Add(reader["cid"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load customer IDs: {ex.Message}");
            }
        }

        // Set up DataGridView for cart if not already in Designer
        private void SetupCartGrid()
        {
            if (cartGrid == null) return; // cartGrid is the DataGridView for cart items

            cartGrid.Columns.Clear();
            cartGrid.Columns.Add("ProductID", "ProductID");
            cartGrid.Columns.Add("ProductName", "Product Name");
            cartGrid.Columns.Add("UnitPrice", "Unit Price");
            cartGrid.Columns.Add("Quantity", "Quantity");
            cartGrid.Columns.Add("Subtotal", "Subtotal");
            cartGrid.AllowUserToAddRows = false;
            cartGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cartGrid.MultiSelect = false;
        }

        // Show cart contents in DataGridView
        private void RefreshCartGrid()
        {
            cartGrid.Rows.Clear();
            foreach (var item in cart)
            {
                cartGrid.Rows.Add(item.pid, item.pname, item.price.ToString("C2"), item.quantity, item.subtotal.ToString("C2"));
            }
        }

        // Update grand total label (sum of all subtotals in the cart)
        private void UpdateGrandTotal()
        {
            decimal grandTotal = cart.Sum(c => c.subtotal);
            lbTotals.Text = grandTotal.ToString("C2");
        }

        // Reduce product quantity in database
        private void UpdateProductQuantity(string productId, int orderedQty, MySqlConnection conn)
        {
            try
            {
                string query = "UPDATE product SET pqty = pqty - @OrderedQty WHERE pid = @ProductID";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderedQty", orderedQty);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update product quantity: {ex.Message}");
            }
        }

        // Open a MySQL database connection
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

        // --- PRODUCT SELECTION & CART LOGIC ---

        // Open product selection dialog (now handles qty and returns a full cart item)
        private void btnSelectProduct_Click(object sender, EventArgs e)
        {
            using (var productList = new ProductList())
            {
                if (productList.ShowDialog() == DialogResult.OK && productList.SelectedCartItem != null)
                {
                    var newItem = productList.SelectedCartItem.Value;

                    // If already in cart, update quantity and subtotal
                    var existing = cart.FirstOrDefault(x => x.pid == newItem.pid);
                    if (!string.IsNullOrEmpty(existing.pid))
                    {
                        cart.Remove(existing);
                        newItem = (newItem.pid, newItem.pname, newItem.price,
                                   existing.quantity + newItem.quantity,
                                   newItem.price * (existing.quantity + newItem.quantity));
                    }

                    cart.Add(newItem);

                    RefreshCartGrid();
                    UpdateGrandTotal();
                }
            }
        }

        // Place order logic (unchanged)
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add products first.");
                return;
            }
            string selectedCustomerId = cmbCustomerId.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCustomerId))
            {
                MessageBox.Show("Please select a Customer ID.");
                return;
            }

            using (MySqlConnection conn = OpenDatabaseConnection())
            {
                if (conn == null) return;
                try
                {
                    conn.Open();
                    // Insert into orders table
                    string insertOrder = "INSERT INTO orders (odate, ocost, cid, ostatus) VALUES (NOW(), @Total, @CustomerId, 1)";
                    using (var cmd = new MySqlCommand(insertOrder, conn))
                    {
                        decimal total = cart.Sum(item => item.subtotal);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@CustomerId", selectedCustomerId);
                        cmd.ExecuteNonQuery();
                        long orderId = cmd.LastInsertedId;

                        // Insert each cart item into orderproducts
                        foreach (var item in cart)
                        {
                            var cmd2 = new MySqlCommand("INSERT INTO orderproducts (oid, pid, pqty) VALUES (@OrderId, @ProductId, @Quantity)", conn);
                            cmd2.Parameters.AddWithValue("@OrderId", orderId);
                            cmd2.Parameters.AddWithValue("@ProductId", item.pid);
                            cmd2.Parameters.AddWithValue("@Quantity", item.quantity);
                            cmd2.ExecuteNonQuery();

                            // Optionally update inventory here
                            UpdateProductQuantity(item.pid, item.quantity, conn);
                        }
                    }
                    MessageBox.Show("Order placed successfully!");
                    cart.Clear();
                    RefreshCartGrid();
                    UpdateGrandTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to place order: {ex.Message}");
                }
            }
        }

        // Customer selection dialog logic (unchanged)
        private void button1_Click(object sender, EventArgs e)
        {
            using (var customerList = new CustomerList())
            {
                // Show as modal dialog
                if (customerList.ShowDialog() == DialogResult.OK)
                {
                    // After closing, get the selected customer ID
                    string selectedCustomerId = customerList.SelectedCustomerId;
                    cmbCustomerId.Text = selectedCustomerId;

                    // Fetch the customer name from the database and set to label
                    string customerName = GetCustomerNameById(selectedCustomerId);
                    lblCustomerName.Text = customerName ?? "Name not found";
                }
            }
        }

        // Helper method to get customer name by ID
        private string GetCustomerNameById(string customerId)
        {
            try
            {
                string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb";
                using (var conn = new MySqlConnection(MySqlCon))
                {
                    conn.Open();
                    string query = "SELECT cname FROM customer WHERE cid = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", customerId);
                        var result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to get customer name: {ex.Message}");
                return null;
            }
        }
    }
}
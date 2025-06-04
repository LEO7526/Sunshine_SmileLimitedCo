using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo
{
    public partial class Form3 : Form
    {
        // List of product image file paths
        private readonly List<string> imagePaths = new List<string>
        {
            "Resources/Product/Cyberpunk Truck C204.jpg",
            "Resources/Product/XDD Wooden Plane.jpg",
            "Resources/Product/iRobot 3233GG.jpg",
            "Resources/Product/Apex Ball Ball Helicopter M1297.jpg",
            "Resources/Product/RoboKat AI Cat Robot.jpg"
        };

        // Dictionary mapping image paths to product names and prices
        private readonly Dictionary<string, (string name, string price, string pid)> productDetails =
            new Dictionary<string, (string, string, string)>
        {
            { "Resources/Product/Cyberpunk Truck C204.jpg", ("Cyberpunk Truck C204", "$19.90", "1") },
            { "Resources/Product/XDD Wooden Plane.jpg", ("XDD Wooden Plane", "$9.90", "2") },
            { "Resources/Product/iRobot 3233GG.jpg", ("iRobot 3233GG", "$249.90", "3") },
            { "Resources/Product/Apex Ball Ball Helicopter M1297.jpg", ("Apex Ball Ball Helicopter M1297", "$30.00", "4") },
            { "Resources/Product/RoboKat AI Cat Robot.jpg", ("RoboKat AI Cat Robot", "$499.00", "5") }
        };

        // Shopping cart: pid, pname, price, quantity, subtotal
        private readonly List<(string pid, string pname, decimal price, int quantity, decimal subtotal)> cart =
            new List<(string, string, decimal, int, decimal)>();

        public Form3()
        {
            InitializeComponent();
            ConfigureForm();
            Panel panel = CreateScrollingPanel();
            Controls.Add(panel);
            LoadImages(panel);
            LoadCustomerIds();
            SetupCartGrid();
        }

        // Set up form properties
        private void ConfigureForm()
        {
            Text = "Image Gallery";
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
        }

        // Create a scrollable panel for displaying product images
        private Panel CreateScrollingPanel()
        {
            return new Panel
            {
                AutoScroll = true,
                Location = new Point(300, 10),
                Size = new Size(650, 330)
            };
        }

        // Load product images into the panel as PictureBoxes
        private void LoadImages(Panel panel)
        {
            int imagesPerRow = 4;
            int xOffset = 10, yOffset = 10;
            int imageWidth = 150, imageHeight = 150;
            int index = 0;

            foreach (var imagePath in imagePaths)
            {
                if (!System.IO.File.Exists(imagePath)) continue;

                PictureBox pictureBox = CreatePictureBox(imagePath, index, imagesPerRow, xOffset, yOffset, imageWidth, imageHeight);
                panel.Controls.Add(pictureBox);
                index++;
            }
            panel.AutoScrollMinSize = new Size(0, yOffset + (index / imagesPerRow + 1) * (imageHeight + 10));
        }

        // Create a PictureBox for a product image
        private PictureBox CreatePictureBox(string imagePath, int index, int imagesPerRow, int xOffset, int yOffset, int imageWidth, int imageHeight)
        {
            var pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(imageWidth, imageHeight),
                Location = new Point(xOffset + (index % imagesPerRow) * (imageWidth + 10), yOffset + (index / imagesPerRow) * (imageHeight + 10)),
                Image = LoadImageSafely(imagePath),
                Tag = imagePath
            };

            pictureBox.Click += PictureBox_Click;
            return pictureBox;
        }

        // Handle product image click: update product details
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag is string imagePath)
            {
                UpdateProductDetails(imagePath);
            }
        }

        // Update product name, price in the UI based on selected image
        private void UpdateProductDetails(string imagePath)
        {
            if (productDetails.ContainsKey(imagePath))
            {
                (string pname, string price, string pid) = productDetails[imagePath];
                lbPname.Text = pname;
                lbPcost.Text = price;
                lbPid.Text = pid;
                txtQty.Text = "1";
                UpdateTotalLabel();
            }
        }

        // Safely load an image, fallback to a default if not found
        private Image LoadImageSafely(string path)
        {
            try
            {
                return new Bitmap(path);
            }
            catch
            {
                return new Bitmap("Resources/Product/Apex Ball Ball Helicopter M1297.jpg");
            }
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

        // Update grand total label
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

        // Update total cost when quantity changes
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalLabel();
        }

        private void UpdateTotalLabel()
        {
            if (!string.IsNullOrWhiteSpace(txtQty.Text) && int.TryParse(txtQty.Text, out int qty) && decimal.TryParse(lbPcost.Text.Replace("$", ""), out decimal price))
            {
                lbTotals.Text = (qty * price).ToString("C2");
            }
            else
            {
                lbTotals.Text = "$0.00";
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbPid.Text) || string.IsNullOrWhiteSpace(txtQty.Text))
            {
                MessageBox.Show("Please select a product and enter a quantity.");
                return;
            }
            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (positive integer).");
                return;
            }
            if (!decimal.TryParse(lbPcost.Text.Replace("$", ""), out decimal price))
            {
                MessageBox.Show("Invalid price.");
                return;
            }
            string pid = lbPid.Text;
            string pname = lbPname.Text;
            decimal subtotal = price * qty;

            // If already in cart, update quantity and subtotal
            var existing = cart.FirstOrDefault(x => x.pid == pid);
            if (!string.IsNullOrEmpty(existing.pid))
            {
                cart.Remove(existing);
                qty += existing.quantity;
                subtotal = price * qty;
            }
            cart.Add((pid, pname, price, qty, subtotal));

            // Update grid display
            RefreshCartGrid();
            UpdateGrandTotal();
        }

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
    }
}
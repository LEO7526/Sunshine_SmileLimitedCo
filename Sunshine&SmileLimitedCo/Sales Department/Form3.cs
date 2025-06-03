using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        private readonly Dictionary<string, (string name, string price)> productDetails =
            new Dictionary<string, (string, string)>
        {
            { "Resources/Product/Cyberpunk Truck C204.jpg", ("Cyberpunk Truck C204", "$299.99") },
            { "Resources/Product/XDD Wooden Plane.jpg", ("XDD Wooden Plane", "$49.99") },
            { "Resources/Product/iRobot 3233GG.jpg", ("iRobot 3233GG", "$199.99") },
            { "Resources/Product/Apex Ball Ball Helicopter M1297.jpg", ("Apex Ball Helicopter M1297", "$149.99") },
            { "Resources/Product/RoboKat AI Cat Robot.jpg", ("RoboKat AI Cat Robot", "$399.99") }
        };

        public Form3()
        {
            InitializeComponent();
            ConfigureForm();
            Panel panel = CreateScrollingPanel();
            Controls.Add(panel);
            LoadImages(panel);
            LoadCustomerIds();
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

            // Set minimum scroll size for the panel
            panel.AutoScrollMinSize = new Size(0, yOffset + (index / imagesPerRow) * (imageHeight + 10));
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

        // Handle product image click: generate order ID and update product details
        private void PictureBox_Click(object sender, EventArgs e)
        {
            GenerateOrderID();
            if (sender is PictureBox pictureBox && pictureBox.Tag is string imagePath)
            {
                UpdateProductDetails(imagePath);
            }
        }

        // Update product name, price, and total in the UI based on selected image
        private void UpdateProductDetails(string imagePath)
        {
            if (productDetails.ContainsKey(imagePath))
            {
                (string name, string price) = productDetails[imagePath];

                lbPname.Text = name;
                lbPcost.Text = price;

                // Convert price to numeric format
                decimal priceValue = Convert.ToDecimal(price.Replace("$", ""));
                int orderedQty = string.IsNullOrWhiteSpace(txtQty.Text) ? 0 : Convert.ToInt32(txtQty.Text);

                // Update total cost label
                lbTotals.Text = (orderedQty * priceValue).ToString("C2"); // Formats in currency style
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

        // Generate a unique order ID and display it
        private void GenerateOrderID()
        {
            string orderID = $"ORD-{DateTime.Now:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
            lbOrderid.Text = orderID;
        }

        // Load Customer IDs into the ComboBox you drew in the Designer
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

        // Handle order button click: validate input and process the order
        private void button1_Click(object sender, EventArgs e)
        {
            // Validate product and quantity
            if (string.IsNullOrWhiteSpace(lbPname.Text) || string.IsNullOrWhiteSpace(txtQty.Text))
            {
                MessageBox.Show("Please select a product and enter a quantity.");
                return;
            }

            // Validate customer ID
            string selectedCustomerId = cmbCustomerId.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCustomerId))
            {
                MessageBox.Show("Please select a Customer ID.");
                return;
            }

            // Validate quantity is a positive integer
            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (positive integer).");
                return;
            }

            // Open database connection and process the order
            using (MySqlConnection conn = OpenDatabaseConnection())
            {
                if (conn == null) return;

                try
                {
                    conn.Open();
                    // ComboBox only allows valid IDs
                    ProcessOrder(conn, selectedCustomerId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection or order processing failed: {ex.Message}");
                }
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

        // Query product info and validate the order
        private void ProcessOrder(MySqlConnection conn, string selectedCustomerId)
        {
            try
            {
                string query = "SELECT pid, pqty FROM product WHERE pname = @name";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", lbPname.Text);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ValidateOrder(dt, conn, selectedCustomerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving product data: {ex.Message}");
            }
        }

        // Validate order quantity and stock, then save order and update product quantity
        private void ValidateOrder(DataTable dt, MySqlConnection conn, string selectedCustomerId)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    int pqty = Convert.ToInt32(dt.Rows[0]["pqty"]);
                    if (!int.TryParse(txtQty.Text, out int orderedQty) || orderedQty <= 0)
                    {
                        MessageBox.Show("Invalid quantity entered.");
                        return;
                    }
                    string productId = dt.Rows[0]["pid"].ToString();
                    string orderId = Guid.NewGuid().ToString();

                    if (orderedQty > pqty)
                    {
                        MessageBox.Show($"Not enough Goods! We have only {pqty} items available.");
                        ClearLabels();
                    }
                    else
                    {
                        decimal price = 0;
                        decimal.TryParse(lbPcost.Text.Replace("$", ""), out price);
                        lbTotals.Text = (orderedQty * price).ToString("C2");
                        MessageBox.Show("Order Created Successfully!", "Confirmation");

                        // Save Order to Database with Order ID and selected Customer ID
                        SaveOrderToDatabase(orderId, productId, orderedQty, selectedCustomerId, conn);

                        // Reduce Product Quantity in the database
                        UpdateProductQuantity(productId, orderedQty, conn);
                    }
                }
                else
                {
                    MessageBox.Show("Product not found. Please check the product name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Order validation failed: {ex.Message}");
            }
        }

        // Save the order to the Orders table in the database
        private void SaveOrderToDatabase(string orderId, string productId, int orderedQty, string customerId, MySqlConnection conn)
        {
            try
            {
                decimal total = 0;
                decimal.TryParse(lbTotals.Text.Replace("$", ""), out total);

                string query = "INSERT INTO Orders (oid, odate, pid, oqty, ocost, cid) VALUES (@OrderID, NOW(), @ProductID, @Quantity, @Total, @CustomerId)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@Quantity", orderedQty);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save order: {ex.Message}");
            }
        }

        // Update the product quantity in the database after an order
        private void UpdateProductQuantity(string productId, int orderedQty, MySqlConnection conn)
        {
            try
            {
                string query = "UPDATE product SET pqty = pqty - @OrderedQty WHERE pid = @ProductID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
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

        // Clear product and order info from the UI
        private void ClearLabels()
        {
            lbPname.Text = "";
            lbPcost.Text = "";
            txtQty.Text = "";
            lbTotals.Text = "";
        }

        // Update total cost when quantity changes
        private void lbQty_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQty.Text) && int.TryParse(txtQty.Text, out int qty))
            {
                decimal price = 0;
                decimal.TryParse(lbPcost.Text.Replace("$", ""), out price);
                lbTotals.Text = (qty * price).ToString("C2"); // Format as currency
            }
        }
    }
}
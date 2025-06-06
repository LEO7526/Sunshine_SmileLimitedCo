using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo
{
    public partial class ProductList : Form
    {
        // This property will be read by Form3 when DialogResult == OK
        public (string pid, string pname, decimal price, int quantity, decimal subtotal)? SelectedCartItem { get; private set; }

        // Product image and info
        private readonly List<string> imagePaths = new List<string>
        {
            "Resources/Product/Cyberpunk Truck C204.jpg",
            "Resources/Product/XDD Wooden Plane.jpg",
            "Resources/Product/iRobot 3233GG.jpg",
            "Resources/Product/Apex Ball Ball Helicopter M1297.jpg",
            "Resources/Product/RoboKat AI Cat Robot.jpg",
            "Resources/Product/large brown teddy bear.png",
            "Resources/Product/LEGO toy.png",
            "Resources/Product/robot.png",
            "Resources/Product/toy car.png",
            "Resources/Product/multicolor sticky notes pack.png"
        };

        private readonly Dictionary<string, (string name, string price, string pid)> productDetails =
            new Dictionary<string, (string, string, string)>
        {
            { "Resources/Product/Cyberpunk Truck C204.jpg", ("Cyberpunk Truck C204", "$19.90", "1") },
            { "Resources/Product/XDD Wooden Plane.jpg", ("XDD Wooden Plane", "$9.90", "2") },
            { "Resources/Product/iRobot 3233GG.jpg", ("iRobot 3233GG", "$249.90", "3") },
            { "Resources/Product/Apex Ball Ball Helicopter M1297.jpg", ("Apex Ball Ball Helicopter M1297", "$30.00", "4") },
            { "Resources/Product/RoboKat AI Cat Robot.jpg", ("RoboKat AI Cat Robot", "$499.00", "5") },
            { "Resources/Product/large brown teddy bear.png", ("large brown teddy bear", "$89.00", "6") },
            { "Resources/Product/multicolor sticky notes pack.png", ("multicolor sticky notes pack", "$8.80", "7") },
            { "Resources/Product/LEGO toy.png", ("LEGO toy", "$8.80", "8") },
            { "Resources/Product/robot.png", ("robot", "$8.80", "9") },
            { "Resources/Product/toy car.png", ("toy car", "$8.80", "10") }
        };

        private readonly string placeholderImagePath = "Resources/Product/placeholder.png";

        public ProductList()
        {
            InitializeComponent();
            this.Text = "Product Gallery";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(800, 500);

            // Panel for products
            Panel panel = CreateScrollingPanel();
            this.Controls.Add(panel);
            LoadImages(panel);

            // Subscribe to Quantity change for instant total update
            txtQty.TextChanged += TxtQty_TextChanged;
        }

        private Panel CreateScrollingPanel()
        {
            return new Panel
            {
                AutoScroll = true,
                Location = new Point(10, 10),
                Size = new Size(660, 330),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
        }

        private void LoadImages(Panel panel)
        {
            int imagesPerRow = 4;
            int xOffset = 10, yOffset = 10;
            int imageWidth = 150, imageHeight = 150;
            int index = 0;

            foreach (var imagePath in imagePaths)
            {
                string resolvedPath = imagePath;
                if (!System.IO.File.Exists(imagePath))
                {
                    Debug.WriteLine($"Missing image: {imagePath}");
                    resolvedPath = placeholderImagePath;
                }

                PictureBox pictureBox = CreatePictureBox(resolvedPath, index, imagesPerRow, xOffset, yOffset, imageWidth, imageHeight, imagePath);
                panel.Controls.Add(pictureBox);
                index++;
            }
            int rows = (index + imagesPerRow - 1) / imagesPerRow;
            panel.AutoScrollMinSize = new Size(0, yOffset + rows * (imageHeight + 10));
        }

        private PictureBox CreatePictureBox(string resolvedPath, int index, int imagesPerRow, int xOffset, int yOffset, int imageWidth, int imageHeight, string tagPath)
        {
            var pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(imageWidth, imageHeight),
                Location = new Point(xOffset + (index % imagesPerRow) * (imageWidth + 10), yOffset + (index / imagesPerRow) * (imageHeight + 10)),
                Image = LoadImageSafely(resolvedPath),
                Tag = tagPath,
                Cursor = Cursors.Hand
            };

            pictureBox.Click += PictureBox_Click;
            return pictureBox;
        }

        private Image LoadImageSafely(string path)
        {
            try
            {
                return new Bitmap(path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to load image '{path}': {ex.Message}");
                Bitmap bmp = new Bitmap(150, 150);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Red);
                    g.DrawString("Image\nMissing", new Font("Arial", 12), Brushes.White, new PointF(10, 60));
                }
                return bmp;
            }
        }

        // When a product image is clicked, display its details and reset total
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag is string imagePath)
            {
                if (productDetails.TryGetValue(imagePath, out var details))
                {
                    lbPname.Text = details.name;
                    lbPcost.Text = details.price;
                    lbOrderid.Text = details.pid;
                    txtQty.Text = "1";
                    UpdateTotalLabel();
                }
            }
        }

        // Instantly update total when quantity changes
        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalLabel();
        }

        // Calculate and show totals
        private void UpdateTotalLabel()
        {
            if (!string.IsNullOrWhiteSpace(txtQty.Text)
                && int.TryParse(txtQty.Text, out int qty)
                && decimal.TryParse(lbPcost.Text.Replace("$", ""), out decimal price))
            {
                lbTotals.Text = (qty * price).ToString("C2");
            }
            else
            {
                lbTotals.Text = "$0.00";
            }
        }

        // On "Add to Cart" button click
        private void addPoduct_Click(object sender, EventArgs e)
        {
            // Ensure a product is selected
            if (string.IsNullOrWhiteSpace(lbOrderid.Text) || string.IsNullOrWhiteSpace(lbPname.Text) || string.IsNullOrWhiteSpace(lbPcost.Text))
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            // Validate quantity
            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.");
                return;
            }

            if (!decimal.TryParse(lbPcost.Text.Replace("$", ""), out decimal price))
            {
                MessageBox.Show("Invalid price format.");
                return;
            }

            // Set property to be read by Form3
            SelectedCartItem = (
                lbOrderid.Text,
                lbPname.Text,
                price,
                qty,
                price * qty
            );
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
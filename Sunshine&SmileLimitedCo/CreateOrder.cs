using Sunshine_SmileLimitedCo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using package here 
using MySql.Data.MySqlClient;


namespace Sunshine_SmileLimitedCo
{
    public partial class CreateOrder : Form
    {
        public CreateOrder()
        {
            InitializeComponent();

        }
        private string userRole;

        public CreateOrder(string role)
        {
            InitializeComponent();
            userRole = role;

            // Example usage: Display role in a label
            Label lblRole = new Label
            {
                Text = "User Role: " + userRole,
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Controls.Add(lblRole);
        }

        private void Form2_Load(object sender, EventArgs e)

        {

            //establish database connection
            establishDbCon();

            //load product into combo box
            LoadProducts();

            //ensures the image updates whenever a product is selected
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

        }
        //load product into combo box for selection
        //load the first product name and cost into the label
        private void LoadProducts()
        {
            string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb";
            using (MySqlConnection conn = new MySqlConnection(MySqlCon))
            {
                try
                {
                    conn.Open();

                    // Load products into ComboBox
                    string query = "SELECT pid, pname FROM product";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "pname"; // Show product names
                    comboBox1.ValueMember = "pid"; // Store product IDs internally

                    // Load first product details into labels
                    string query1 = "SELECT pname, pcost FROM product LIMIT 1"; // Get only the first product
                    MySqlCommand cmd = new MySqlCommand(query1, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtPname.Text = reader["pname"].ToString();
                        txtPcost.Text = reader["pcost"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //load image when selecting different product using combo box
        //update pname and pcost 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                return;

            DataRowView drv = comboBox1.SelectedItem as DataRowView; // Cast SelectedItem
            if (drv != null)
            {
                string selectedProduct = drv["pname"].ToString();
                txtPname.Text = selectedProduct; // Update product name

                // Construct image path and load image if available
                string imagePath = Application.StartupPath + @"\Resources\Product\" + selectedProduct + ".jpg";

                if (System.IO.File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Makes image fit the PictureBox
                }
                else
                {
                    MessageBox.Show("Image not found for " + selectedProduct);
                    pictureBox1.Image = null; // Reset if not found
                }

                // Fetch and display product cost
                string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb";
                using (MySqlConnection conn = new MySqlConnection(MySqlCon))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT pcost FROM product WHERE pname = @pname";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@pname", selectedProduct);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                txtPcost.Text = result.ToString();
                            }
                            else
                            {
                                txtPcost.Text = "Price not found";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        //connect to the database
        private void establishDbCon()
        {
            string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb";
            MySqlConnection MySqlConnection = new MySqlConnection(MySqlCon);

            try
            {
                MySqlConnection.Open();
                //MessageBox.Show("Connection Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MySqlConnection.Close();
            }
        }


        ////close form
        //private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    FormLogin login = new FormLogin();
        //    login.Show();
        //}

        //Bitmap

        
    }
}

using MySql.Data.MySqlClient;
using Sunshine_SmileLimitedCo.Inventory;
using Sunshine_SmileLimitedCo.Sales_Department;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace Sunshine_SmileLimitedCo.Inventory
{
    public partial class updateMaterial : Form
    {
        String qtyInput;
        public updateMaterial()
        {
            InitializeComponent();
        }
        private MySqlConnection OpenDatabaseConnection()
        {
            try
            {
                string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb;SslMode = None";
                return new MySqlConnection(MySqlCon);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}");
                return null;
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            using (var conn = OpenDatabaseConnection())
            {
                if (conn == null) return; 

                try
                {
                    conn.Open(); 
                    string query = "SELECT mid FROM material"; 
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader()) 
                    {
                        comboBox1.Items.Clear(); 
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["mid"].ToString()); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();
            string image = "mID" + selectedValue;

            System.Drawing.Image img = Properties.Resources.ResourceManager.GetObject(image) as System.Drawing.Image;

            if (img != null)
            {
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qtyInput = textBox1.Text; 
            string selectedMaterial = comboBox1.SelectedItem?.ToString(); 

            if (string.IsNullOrWhiteSpace(qtyInput) || string.IsNullOrWhiteSpace(selectedMaterial))
            {
                MessageBox.Show("Please enter a valid quantity and select a material!！");
                return;
            }

            using (var conn = OpenDatabaseConnection())
            {
                if (conn == null) return; 

                try
                {
                    conn.Open();
                    string query = "UPDATE material SET mqty = @qty WHERE mid = @mid"; 

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@qty", qtyInput); 
                        cmd.Parameters.AddWithValue("@mid", selectedMaterial);

                        int rowsAffected = cmd.ExecuteNonQuery(); 

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Quantity updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Update failed, please check if the data exists!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Quantity update failed: {ex.Message}");
                }
            }
        }
    }
}

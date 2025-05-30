using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sunshine_SmileLimitedCo
{
    public partial class FormLogin : Form
    {
        public bool Login = false;

        public FormLogin()
        {
            InitializeComponent();
            Login = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin(txtUsername.Text, txtPassword.Text, out string userRole))
            {
                Login = true;
                OpenForm(userRole);
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool ValidateLogin(string username, string password, out string userRole)
        {
            userRole = null;
            string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb";

            using (MySqlConnection conn = new MySqlConnection(MySqlCon))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT srole FROM staff WHERE sname=@username AND spassword=@password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            userRole = result.ToString();
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return false;
        }

        private void OpenForm(string userRole)
        {
            if (userRole == "Sales Manager")
            {
                this.Hide();
                CreateOrder mainForm = new CreateOrder(); 
                mainForm.ShowDialog();
            }
            else
            {
                this.Hide();
                InventoryRecord form1 = new InventoryRecord(userRole);
                form1.ShowDialog();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();
            }
        }
    }
}

using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sunshine_SmileLimitedCo
{
    public partial class FormLogin : Form
    {
        public string StaffId { get; private set; }
        public string StaffRole { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin(txtUsername.Text, txtPassword.Text, out string staffId, out string userRole))
            {
                StaffId = staffId;
                StaffRole = userRole;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool ValidateLogin(string username, string password, out string staffId, out string userRole)
        {
            staffId = null;
            userRole = null;
            string MySqlCon = "server=127.0.0.1;user=root;password=;database=projectdb";

            using (MySqlConnection conn = new MySqlConnection(MySqlCon))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT sid, srole FROM staff WHERE sname=@username AND spassword=@password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                staffId = reader["sid"].ToString();
                                userRole = reader["srole"].ToString();
                                return true;
                            }
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

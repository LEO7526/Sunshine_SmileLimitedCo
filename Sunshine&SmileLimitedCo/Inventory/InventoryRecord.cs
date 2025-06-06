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

namespace Sunshine_SmileLimitedCo
{
    public partial class InventoryRecord : Form
    {
        private DataTable materailTable;
        public InventoryRecord()
        {
            InitializeComponent();
            LoadOrders();
        }

        private string userRole;


        public InventoryRecord(string role)
        {
            userRole = role;

            // Example usage: Display role in a label
            Label lblRole = new Label
            {
                Text = "User Role: " + userRole,
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Controls.Add(lblRole);
            LoadOrders();
            InitializeComponent();

        }




        private void LoadOrders()
        {
            using (var conn = OpenDatabaseConnection())
            {
                if (conn == null) return;
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                            mid AS 'Material ID', 
                            mname AS 'Material Name', 
                            mqty AS 'Material QTY', 
                            munit AS 'Material Unit' 
                            FROM material";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        materailTable = new DataTable();
                        adapter.Fill(materailTable);
                        materialDataView.DataSource = materailTable;
                        materialDataView.Columns[0].Width = 120; 
                        materialDataView.Columns[1].Width = 150; 
                        materialDataView.Columns[2].Width = 80;  
                        materialDataView.Columns[3].Width = 100; 

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load orders: {ex.Message}");
                }
            }
        }
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

        private void materialDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = materailTable.Rows[e.RowIndex];
                string materialId = row["Material ID"]?.ToString() ?? "";
                string materialName = row["Material Name"]?.ToString() ?? "";
                string materialQty = row["Material QTY"]?.ToString() ?? "";
                string materialUnit = row["Material Unit"]?.ToString() ?? "";


                var detailForm = new detailMaterialInfo(materialId, materialName, materialQty, materialUnit);
                detailForm.ShowDialog();

                LoadOrders();
            }
        }

        private void cMaterailOrder_Click(object sender, EventArgs e)
        {
            var updateForm = new updateMaterial();
            updateForm.ShowDialog();
            LoadOrders();
        }
    }
}

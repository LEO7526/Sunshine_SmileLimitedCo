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
        public InventoryRecord()
        {
            InitializeComponent();
        }

        private string userRole;

        public InventoryRecord(string role)
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
    }
}

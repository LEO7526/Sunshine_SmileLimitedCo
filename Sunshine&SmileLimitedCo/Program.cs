using System;
using System.Windows.Forms;
using Sunshine_SmileLimitedCo.Afterservice;
using Sunshine_SmileLimitedCo.Sales_Department;
using SunshineSmileLimitedCo;
// Removed unused using directive
// using static System.Net.Mime.MediaTypeNames;

namespace Sunshine_SmileLimitedCo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Route based on staff role
                    if (loginForm.StaffRole?.Trim().Equals("Sales Manager", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        Application.Run(new OrderNavigationForm(loginForm.StaffId, loginForm.StaffRole));
                    }
                    else if (loginForm.StaffRole?.Trim().Equals("Delivery Manager", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        Application.Run(new DeliveryNote("DEL0001"));
                    }
                    else if (loginForm.StaffRole?.Trim().Equals("Inventory Manager", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        Application.Run(new InventoryRecord());
                    }
                    else if (loginForm.StaffRole?.Trim().Equals("Afterservice Manager", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        Application.Run(new complaint());
                    }
                    else
                    {
                        MessageBox.Show("Your role is not recognized. Please contact the administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}

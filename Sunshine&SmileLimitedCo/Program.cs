

using Sunshine_SmileLimitedCo;
using Sunshine_SmileLimitedCo.Sales_Department;
using System;
using System.Windows.Forms;

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
                    Application.Run(new View_and_Edit_Order(loginForm.StaffId, loginForm.StaffRole));
                }
            }
        }
    }
}

using Sunshine_SmileLimitedCo;
using Sunshine_SmileLimitedCo.Sales_Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View_and_Edit_Order());
        }
    }
}

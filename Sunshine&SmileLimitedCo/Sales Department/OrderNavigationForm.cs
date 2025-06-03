using System;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Sales_Department
{
    public partial class OrderNavigationForm : Form
    {

        private readonly string staffId;
        private readonly string staffRole;

        public OrderNavigationForm(string staffId, string staffRole)
        {
            this.staffId = staffId;
            this.staffRole = staffRole;
            InitializeComponent();
        }
        public OrderNavigationForm()
        {
            InitializeComponent();
        }

       

        

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            var createForm = new Form3();
            createForm.ShowDialog(); // or .Show() for non-modal
        }

        private void btnEditViewOrder_Click(object sender, EventArgs e)
        {
            var editViewForm = new View_and_Edit_Order(staffId, staffRole);
            editViewForm.ShowDialog(); // or .Show() for non-modal
        }
    }
}
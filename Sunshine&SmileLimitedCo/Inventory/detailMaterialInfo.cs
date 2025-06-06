using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunshine_SmileLimitedCo.Inventory
{
    public partial class detailMaterialInfo : Form
    {
        private readonly string staffId;
        private readonly string staffRole;
        private readonly string connStr;
        private string image;

        public detailMaterialInfo()
        {
            InitializeComponent();
            connStr = ConfigurationManager.ConnectionStrings["projectdb"]?.ConnectionString
                      ?? "server=127.0.0.1;user=root;password=;database=projectdb";

        }

        public detailMaterialInfo(
            string mID,
            string mName,
            string mQty,
            string mUnit)
            : this()
        {
            mIDTextBox.Text = mID;
            mNameTextBox.Text = mName;
            mQtyTextBox.Text = mQty;
            mUnitTextBox.Text = mUnit;
            image = "mID"+mID;

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Image img = Properties.Resources.ResourceManager.GetObject(image) as Image;

            if (img != null)
            {
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {
                MessageBox.Show("Image loading failed.");
            }
        }
    }
}

namespace Sunshine_SmileLimitedCo
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTotals = new System.Windows.Forms.Label();
            this.cmbCustomerId = new System.Windows.Forms.ComboBox();
            this.cartGrid = new System.Windows.Forms.DataGridView();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cartGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTotals
            // 
            this.lbTotals.BackColor = System.Drawing.SystemColors.Info;
            this.lbTotals.Location = new System.Drawing.Point(1048, 662);
            this.lbTotals.Name = "lbTotals";
            this.lbTotals.Size = new System.Drawing.Size(103, 18);
            this.lbTotals.TabIndex = 3;
            // 
            // cmbCustomerId
            // 
            this.cmbCustomerId.FormattingEnabled = true;
            this.cmbCustomerId.Location = new System.Drawing.Point(133, 21);
            this.cmbCustomerId.Name = "cmbCustomerId";
            this.cmbCustomerId.Size = new System.Drawing.Size(121, 26);
            this.cmbCustomerId.TabIndex = 5;
            // 
            // cartGrid
            // 
            this.cartGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.cartGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartGrid.Location = new System.Drawing.Point(138, 107);
            this.cartGrid.Name = "cartGrid";
            this.cartGrid.RowHeadersWidth = 62;
            this.cartGrid.RowTemplate.Height = 31;
            this.cartGrid.Size = new System.Drawing.Size(565, 219);
            this.cartGrid.TabIndex = 6;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(553, 343);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(137, 63);
            this.btnPlaceOrder.TabIndex = 8;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(917, 662);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "Totals";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 18);
            this.label12.TabIndex = 14;
            this.label12.Text = "Customer ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 42);
            this.button1.TabIndex = 15;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.SystemColors.Info;
            this.lblCustomerName.Location = new System.Drawing.Point(135, 60);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(103, 18);
            this.lblCustomerName.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 18);
            this.label14.TabIndex = 17;
            this.label14.Text = "Customer Name";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(138, 343);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 78);
            this.button3.TabIndex = 18;
            this.button3.Text = "Select Product";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "Product";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(251, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 78);
            this.button4.TabIndex = 20;
            this.button4.Text = "Delete Product";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(1173, 703);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.cartGrid);
            this.Controls.Add(this.cmbCustomerId);
            this.Controls.Add(this.lbTotals);
            this.Name = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.cartGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;


        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbOrderid;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btAddToCart;
        private System.Windows.Forms.Button btPlaceOrder;
        private System.Windows.Forms.Label lbTotals;
        private System.Windows.Forms.ComboBox cmbCustomerId;
        private System.Windows.Forms.DataGridView cartGrid;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
    }
}
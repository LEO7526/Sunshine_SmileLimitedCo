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
            this.lbPname = new System.Windows.Forms.Label();
            this.lbPcost = new System.Windows.Forms.Label();
            this.lbTotals = new System.Windows.Forms.Label();
            this.lbPid = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.cmbCustomerId = new System.Windows.Forms.ComboBox();
            this.cartGrid = new System.Windows.Forms.DataGridView();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cartGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPname
            // 
            this.lbPname.AutoSize = true;
            this.lbPname.Location = new System.Drawing.Point(123, 400);
            this.lbPname.Name = "lbPname";
            this.lbPname.Size = new System.Drawing.Size(50, 18);
            this.lbPname.TabIndex = 0;
            this.lbPname.Text = "label7";
            // 
            // lbPcost
            // 
            this.lbPcost.AutoSize = true;
            this.lbPcost.Location = new System.Drawing.Point(123, 441);
            this.lbPcost.Name = "lbPcost";
            this.lbPcost.Size = new System.Drawing.Size(50, 18);
            this.lbPcost.TabIndex = 1;
            this.lbPcost.Text = "label8";
            // 
            // lbTotals
            // 
            this.lbTotals.AutoSize = true;
            this.lbTotals.Location = new System.Drawing.Point(123, 525);
            this.lbTotals.Name = "lbTotals";
            this.lbTotals.Size = new System.Drawing.Size(50, 18);
            this.lbTotals.TabIndex = 3;
            this.lbTotals.Text = "label9";
            // 
            // lbPid
            // 
            this.lbPid.AutoSize = true;
            this.lbPid.Location = new System.Drawing.Point(123, 484);
            this.lbPid.Name = "lbPid";
            this.lbPid.Size = new System.Drawing.Size(58, 18);
            this.lbPid.TabIndex = 2;
            this.lbPid.Text = "label10";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(126, 358);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 29);
            this.txtQty.TabIndex = 4;
            // 
            // cmbCustomerId
            // 
            this.cmbCustomerId.FormattingEnabled = true;
            this.cmbCustomerId.Location = new System.Drawing.Point(126, 576);
            this.cmbCustomerId.Name = "cmbCustomerId";
            this.cmbCustomerId.Size = new System.Drawing.Size(121, 26);
            this.cmbCustomerId.TabIndex = 5;
            // 
            // cartGrid
            // 
            this.cartGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartGrid.Location = new System.Drawing.Point(465, 420);
            this.cartGrid.Name = "cartGrid";
            this.cartGrid.RowHeadersWidth = 62;
            this.cartGrid.RowTemplate.Height = 31;
            this.cartGrid.Size = new System.Drawing.Size(696, 150);
            this.cartGrid.TabIndex = 6;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(138, 629);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(137, 63);
            this.btnAddToCart.TabIndex = 7;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(374, 629);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(137, 63);
            this.btnPlaceOrder.TabIndex = 8;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(1173, 703);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.cartGrid);
            this.Controls.Add(this.cmbCustomerId);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lbTotals);
            this.Controls.Add(this.lbPid);
            this.Controls.Add(this.lbPcost);
            this.Controls.Add(this.lbPname);
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
        private System.Windows.Forms.Label lbPname;
        private System.Windows.Forms.Label lbPcost;
        private System.Windows.Forms.Label lbTotals;
        private System.Windows.Forms.Label lbPid;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.ComboBox cmbCustomerId;
        private System.Windows.Forms.DataGridView cartGrid;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnPlaceOrder;
    }
}
namespace Sunshine_SmileLimitedCo
{
    partial class ProductList
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
            this.label5 = new System.Windows.Forms.Label();
            this.lbOrderid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lbPcost = new System.Windows.Forms.Label();
            this.lbPname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addPoduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTotals
            // 
            this.lbTotals.BackColor = System.Drawing.SystemColors.Info;
            this.lbTotals.ForeColor = System.Drawing.Color.Black;
            this.lbTotals.Location = new System.Drawing.Point(750, 569);
            this.lbTotals.Name = "lbTotals";
            this.lbTotals.Size = new System.Drawing.Size(279, 22);
            this.lbTotals.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 569);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Totals";
            // 
            // lbOrderid
            // 
            this.lbOrderid.BackColor = System.Drawing.SystemColors.Info;
            this.lbOrderid.ForeColor = System.Drawing.Color.Black;
            this.lbOrderid.Location = new System.Drawing.Point(214, 511);
            this.lbOrderid.Name = "lbOrderid";
            this.lbOrderid.Size = new System.Drawing.Size(279, 22);
            this.lbOrderid.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 517);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Order ID";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(753, 517);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(276, 29);
            this.txtQty.TabIndex = 18;
            // 
            // lbPcost
            // 
            this.lbPcost.BackColor = System.Drawing.SystemColors.Info;
            this.lbPcost.ForeColor = System.Drawing.Color.Black;
            this.lbPcost.Location = new System.Drawing.Point(214, 597);
            this.lbPcost.Name = "lbPcost";
            this.lbPcost.Size = new System.Drawing.Size(279, 22);
            this.lbPcost.TabIndex = 17;
            // 
            // lbPname
            // 
            this.lbPname.BackColor = System.Drawing.SystemColors.Info;
            this.lbPname.ForeColor = System.Drawing.Color.Black;
            this.lbPname.Location = new System.Drawing.Point(214, 555);
            this.lbPname.Name = "lbPname";
            this.lbPname.Size = new System.Drawing.Size(279, 22);
            this.lbPname.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(577, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 597);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Product Cost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 555);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Product Name";
            // 
            // addPoduct
            // 
            this.addPoduct.Location = new System.Drawing.Point(468, 632);
            this.addPoduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addPoduct.Name = "addPoduct";
            this.addPoduct.Size = new System.Drawing.Size(92, 41);
            this.addPoduct.TabIndex = 24;
            this.addPoduct.Text = "Add";
            this.addPoduct.UseVisualStyleBackColor = true;
            this.addPoduct.Click += new System.EventHandler(this.addPoduct_Click);
            // 
            // ProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 687);
            this.Controls.Add(this.addPoduct);
            this.Controls.Add(this.lbTotals);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbOrderid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lbPcost);
            this.Controls.Add(this.lbPname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ProductList";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTotals;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbOrderid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lbPcost;
        private System.Windows.Forms.Label lbPname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addPoduct;
    }
}
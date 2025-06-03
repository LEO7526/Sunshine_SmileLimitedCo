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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPname = new System.Windows.Forms.Label();
            this.lbPcost = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbOrderid = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTotals = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCustomerId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 723);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 765);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Cost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 812);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity";
            // 
            // lbPname
            // 
            this.lbPname.BackColor = System.Drawing.SystemColors.Info;
            this.lbPname.ForeColor = System.Drawing.Color.Black;
            this.lbPname.Location = new System.Drawing.Point(189, 723);
            this.lbPname.Name = "lbPname";
            this.lbPname.Size = new System.Drawing.Size(279, 22);
            this.lbPname.TabIndex = 4;
            // 
            // lbPcost
            // 
            this.lbPcost.BackColor = System.Drawing.SystemColors.Info;
            this.lbPcost.ForeColor = System.Drawing.Color.Black;
            this.lbPcost.Location = new System.Drawing.Point(189, 765);
            this.lbPcost.Name = "lbPcost";
            this.lbPcost.Size = new System.Drawing.Size(279, 22);
            this.lbPcost.TabIndex = 5;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(192, 812);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(276, 29);
            this.txtQty.TabIndex = 6;
            this.txtQty.TextChanged += new System.EventHandler(this.lbQty_TextChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 684);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Order ID";
            // 
            // lbOrderid
            // 
            this.lbOrderid.BackColor = System.Drawing.SystemColors.Info;
            this.lbOrderid.ForeColor = System.Drawing.Color.Black;
            this.lbOrderid.Location = new System.Drawing.Point(189, 678);
            this.lbOrderid.Name = "lbOrderid";
            this.lbOrderid.Size = new System.Drawing.Size(279, 22);
            this.lbOrderid.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 903);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 864);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Totals";
            // 
            // lbTotals
            // 
            this.lbTotals.BackColor = System.Drawing.SystemColors.Info;
            this.lbTotals.ForeColor = System.Drawing.Color.Black;
            this.lbTotals.Location = new System.Drawing.Point(189, 864);
            this.lbTotals.Name = "lbTotals";
            this.lbTotals.Size = new System.Drawing.Size(279, 22);
            this.lbTotals.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 638);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Customer ID";
            // 
            // cmbCustomerId
            // 
            this.cmbCustomerId.FormattingEnabled = true;
            this.cmbCustomerId.Location = new System.Drawing.Point(192, 635);
            this.cmbCustomerId.Name = "cmbCustomerId";
            this.cmbCustomerId.Size = new System.Drawing.Size(276, 26);
            this.cmbCustomerId.TabIndex = 14;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1170);
            this.Controls.Add(this.cmbCustomerId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbTotals);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbOrderid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lbPcost);
            this.Controls.Add(this.lbPname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPname;
        private System.Windows.Forms.Label lbPcost;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbOrderid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTotals;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCustomerId;
    }
}
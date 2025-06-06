namespace Sunshine_SmileLimitedCo.Sales_Department
{
    partial class View_and_Edit_Order
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.txtFilterCustomerId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSortColumn = new System.Windows.Forms.ComboBox();
            this.btnApplyFilterSort = new System.Windows.Forms.Button();
            this.chkAscending = new System.Windows.Forms.CheckBox();
            this.chkDescending = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(64, 150);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.RowTemplate.Height = 31;
            this.dgvOrders.Size = new System.Drawing.Size(755, 386);
            this.dgvOrders.TabIndex = 0;
            // 
            // txtFilterCustomerId
            // 
            this.txtFilterCustomerId.Location = new System.Drawing.Point(254, 582);
            this.txtFilterCustomerId.Name = "txtFilterCustomerId";
            this.txtFilterCustomerId.Size = new System.Drawing.Size(378, 29);
            this.txtFilterCustomerId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search By Customer ID";
            // 
            // cmbSortColumn
            // 
            this.cmbSortColumn.FormattingEnabled = true;
            this.cmbSortColumn.Location = new System.Drawing.Point(956, 577);
            this.cmbSortColumn.Name = "cmbSortColumn";
            this.cmbSortColumn.Size = new System.Drawing.Size(121, 26);
            this.cmbSortColumn.TabIndex = 3;
            // 
            // btnApplyFilterSort
            // 
            this.btnApplyFilterSort.Location = new System.Drawing.Point(254, 761);
            this.btnApplyFilterSort.Name = "btnApplyFilterSort";
            this.btnApplyFilterSort.Size = new System.Drawing.Size(128, 53);
            this.btnApplyFilterSort.TabIndex = 4;
            this.btnApplyFilterSort.Text = "Sort";
            this.btnApplyFilterSort.UseVisualStyleBackColor = true;
            // 
            // chkAscending
            // 
            this.chkAscending.AutoSize = true;
            this.chkAscending.Location = new System.Drawing.Point(254, 674);
            this.chkAscending.Name = "chkAscending";
            this.chkAscending.Size = new System.Drawing.Size(106, 22);
            this.chkAscending.TabIndex = 5;
            this.chkAscending.Text = "Ascending";
            this.chkAscending.UseVisualStyleBackColor = true;
            // 
            // chkDescending
            // 
            this.chkDescending.AutoSize = true;
            this.chkDescending.Location = new System.Drawing.Point(400, 674);
            this.chkDescending.Name = "chkDescending";
            this.chkDescending.Size = new System.Drawing.Size(114, 22);
            this.chkDescending.TabIndex = 6;
            this.chkDescending.Text = "Descending";
            this.chkDescending.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(704, 585);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search By Other Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 674);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sorted in ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Order ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Customer ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(782, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 53);
            this.button1.TabIndex = 11;
            this.button1.Text = "Order List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblOrderID
            // 
            this.lblOrderID.BackColor = System.Drawing.SystemColors.Info;
            this.lblOrderID.Location = new System.Drawing.Point(200, 46);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(151, 18);
            this.lblOrderID.TabIndex = 12;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.SystemColors.Info;
            this.lblCustomerName.Location = new System.Drawing.Point(551, 98);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(151, 18);
            this.lblCustomerName.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(406, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Customer Name";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.BackColor = System.Drawing.SystemColors.Info;
            this.lblCustomerID.Location = new System.Drawing.Point(200, 98);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(151, 18);
            this.lblCustomerID.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-2, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 18);
            this.label10.TabIndex = 16;
            this.label10.Text = "Product";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(406, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 18);
            this.label11.TabIndex = 17;
            this.label11.Text = "Order Date";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.BackColor = System.Drawing.SystemColors.Info;
            this.lblOrderDate.Location = new System.Drawing.Point(498, 46);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(151, 18);
            this.lblOrderDate.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(956, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 53);
            this.button2.TabIndex = 19;
            this.button2.Text = "Product List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(949, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 53);
            this.button3.TabIndex = 20;
            this.button3.Text = "History";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(831, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 47);
            this.label6.TabIndex = 21;
            this.label6.Text = "Add Product";
            // 
            // View_and_Edit_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 836);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkDescending);
            this.Controls.Add(this.chkAscending);
            this.Controls.Add(this.btnApplyFilterSort);
            this.Controls.Add(this.cmbSortColumn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilterCustomerId);
            this.Controls.Add(this.dgvOrders);
            this.Name = "View_and_Edit_Order";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.TextBox txtFilterCustomerId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSortColumn;
        private System.Windows.Forms.Button btnApplyFilterSort;
        private System.Windows.Forms.CheckBox chkAscending;
        private System.Windows.Forms.CheckBox chkDescending;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
    }
}
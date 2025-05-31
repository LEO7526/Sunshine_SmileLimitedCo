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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(56, 26);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.RowTemplate.Height = 31;
            this.dgvOrders.Size = new System.Drawing.Size(997, 386);
            this.dgvOrders.TabIndex = 0;
            // 
            // txtFilterCustomerId
            // 
            this.txtFilterCustomerId.Location = new System.Drawing.Point(246, 458);
            this.txtFilterCustomerId.Name = "txtFilterCustomerId";
            this.txtFilterCustomerId.Size = new System.Drawing.Size(378, 29);
            this.txtFilterCustomerId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search By Customer ID";
            // 
            // cmbSortColumn
            // 
            this.cmbSortColumn.FormattingEnabled = true;
            this.cmbSortColumn.Location = new System.Drawing.Point(948, 453);
            this.cmbSortColumn.Name = "cmbSortColumn";
            this.cmbSortColumn.Size = new System.Drawing.Size(121, 26);
            this.cmbSortColumn.TabIndex = 3;
            // 
            // btnApplyFilterSort
            // 
            this.btnApplyFilterSort.Location = new System.Drawing.Point(246, 637);
            this.btnApplyFilterSort.Name = "btnApplyFilterSort";
            this.btnApplyFilterSort.Size = new System.Drawing.Size(127, 52);
            this.btnApplyFilterSort.TabIndex = 4;
            this.btnApplyFilterSort.Text = "Sort";
            this.btnApplyFilterSort.UseVisualStyleBackColor = true;
            // 
            // chkAscending
            // 
            this.chkAscending.AutoSize = true;
            this.chkAscending.Location = new System.Drawing.Point(246, 550);
            this.chkAscending.Name = "chkAscending";
            this.chkAscending.Size = new System.Drawing.Size(106, 22);
            this.chkAscending.TabIndex = 5;
            this.chkAscending.Text = "Ascending";
            this.chkAscending.UseVisualStyleBackColor = true;
            // 
            // chkDescending
            // 
            this.chkDescending.AutoSize = true;
            this.chkDescending.Location = new System.Drawing.Point(392, 550);
            this.chkDescending.Name = "chkDescending";
            this.chkDescending.Size = new System.Drawing.Size(114, 22);
            this.chkDescending.TabIndex = 6;
            this.chkDescending.Text = "Descending";
            this.chkDescending.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(696, 461);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search By Other Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 550);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sorted in ";
            // 
            // View_and_Edit_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 701);
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
            this.Text = "View_and_Edit_Order";
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
    }
}
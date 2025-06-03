namespace Sunshine_SmileLimitedCo.Sales_Department
{
    partial class OrderNavigationForm
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
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnEditViewOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(112, 186);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(122, 57);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnEditViewOrder
            // 
            this.btnEditViewOrder.Location = new System.Drawing.Point(333, 186);
            this.btnEditViewOrder.Name = "btnEditViewOrder";
            this.btnEditViewOrder.Size = new System.Drawing.Size(122, 57);
            this.btnEditViewOrder.TabIndex = 1;
            this.btnEditViewOrder.Text = "Edit Order";
            this.btnEditViewOrder.UseVisualStyleBackColor = true;
            this.btnEditViewOrder.Click += new System.EventHandler(this.btnEditViewOrder_Click);
            // 
            // OrderNavigationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditViewOrder);
            this.Controls.Add(this.btnCreateOrder);
            this.Name = "OrderNavigationForm";
            this.Text = "OrderNavigationForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnEditViewOrder;
    }
}
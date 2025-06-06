namespace Sunshine_SmileLimitedCo
{
    partial class InventoryRecord
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
            this.materialDataView = new System.Windows.Forms.DataGridView();
            this.cMaterailOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // materialDataView
            // 
            this.materialDataView.AllowUserToAddRows = false;
            this.materialDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialDataView.Location = new System.Drawing.Point(402, 146);
            this.materialDataView.Name = "materialDataView";
            this.materialDataView.RowHeadersVisible = false;
            this.materialDataView.RowHeadersWidth = 82;
            this.materialDataView.RowTemplate.Height = 38;
            this.materialDataView.Size = new System.Drawing.Size(971, 609);
            this.materialDataView.TabIndex = 0;
            this.materialDataView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.materialDataView_CellDoubleClick);
            // 
            // cMaterailOrder
            // 
            this.cMaterailOrder.Location = new System.Drawing.Point(66, 330);
            this.cMaterailOrder.Name = "cMaterailOrder";
            this.cMaterailOrder.Size = new System.Drawing.Size(248, 73);
            this.cMaterailOrder.TabIndex = 2;
            this.cMaterailOrder.Text = "Update Materail";
            this.cMaterailOrder.UseVisualStyleBackColor = true;
            this.cMaterailOrder.Click += new System.EventHandler(this.cMaterailOrder_Click);
            // 
            // InventoryRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 869);
            this.Controls.Add(this.cMaterailOrder);
            this.Controls.Add(this.materialDataView);
            this.Name = "InventoryRecord";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.materialDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView materialDataView;
        private System.Windows.Forms.Button cMaterailOrder;
        private System.Windows.Forms.ComboBox cmbSortColumn;
    }
}
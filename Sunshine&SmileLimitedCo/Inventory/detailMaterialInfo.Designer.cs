namespace Sunshine_SmileLimitedCo.Inventory
{
    partial class detailMaterialInfo
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mIDTextBox = new System.Windows.Forms.TextBox();
            this.mNameTextBox = new System.Windows.Forms.TextBox();
            this.mQtyTextBox = new System.Windows.Forms.TextBox();
            this.mUnitTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Material QTY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 482);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Material Unit";
            // 
            // mIDTextBox
            // 
            this.mIDTextBox.Location = new System.Drawing.Point(325, 175);
            this.mIDTextBox.Name = "mIDTextBox";
            this.mIDTextBox.ReadOnly = true;
            this.mIDTextBox.Size = new System.Drawing.Size(194, 36);
            this.mIDTextBox.TabIndex = 5;
            // 
            // mNameTextBox
            // 
            this.mNameTextBox.Location = new System.Drawing.Point(325, 271);
            this.mNameTextBox.Name = "mNameTextBox";
            this.mNameTextBox.ReadOnly = true;
            this.mNameTextBox.Size = new System.Drawing.Size(194, 36);
            this.mNameTextBox.TabIndex = 6;
            // 
            // mQtyTextBox
            // 
            this.mQtyTextBox.Location = new System.Drawing.Point(325, 372);
            this.mQtyTextBox.Name = "mQtyTextBox";
            this.mQtyTextBox.ReadOnly = true;
            this.mQtyTextBox.Size = new System.Drawing.Size(194, 36);
            this.mQtyTextBox.TabIndex = 7;
            // 
            // mUnitTextBox
            // 
            this.mUnitTextBox.Location = new System.Drawing.Point(325, 470);
            this.mUnitTextBox.Name = "mUnitTextBox";
            this.mUnitTextBox.ReadOnly = true;
            this.mUnitTextBox.Size = new System.Drawing.Size(194, 36);
            this.mUnitTextBox.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(752, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 388);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // detailMaterialInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 803);
            this.Controls.Add(this.mUnitTextBox);
            this.Controls.Add(this.mQtyTextBox);
            this.Controls.Add(this.mNameTextBox);
            this.Controls.Add(this.mIDTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "detailMaterialInfo";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mIDTextBox;
        private System.Windows.Forms.TextBox mNameTextBox;
        private System.Windows.Forms.TextBox mQtyTextBox;
        private System.Windows.Forms.TextBox mUnitTextBox;
    }
}

namespace QLNhanSu_He2024
{
    partial class frmMain
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
            this.btnNV = new System.Windows.Forms.Button();
            this.btnLuong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNV
            // 
            this.btnNV.Location = new System.Drawing.Point(131, 86);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(227, 143);
            this.btnNV.TabIndex = 0;
            this.btnNV.Text = "Thông tin NV";
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnLuong
            // 
            this.btnLuong.Location = new System.Drawing.Point(424, 86);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Size = new System.Drawing.Size(228, 143);
            this.btnLuong.TabIndex = 1;
            this.btnLuong.Text = "Bảng Lương NV";
            this.btnLuong.UseVisualStyleBackColor = true;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 475);
            this.Controls.Add(this.btnLuong);
            this.Controls.Add(this.btnNV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmMain";
            this.Text = "Chương trình chính";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Button btnLuong;
    }
}

namespace JsonShow
{
    partial class Dialog
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
            this.OkSerializeName = new System.Windows.Forms.Button();
            this.CancelSerializeName = new System.Windows.Forms.Button();
            this.SerializeColumName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OkSerializeName
            // 
            this.OkSerializeName.Location = new System.Drawing.Point(45, 85);
            this.OkSerializeName.Name = "OkSerializeName";
            this.OkSerializeName.Size = new System.Drawing.Size(75, 23);
            this.OkSerializeName.TabIndex = 0;
            this.OkSerializeName.Text = "确定";
            this.OkSerializeName.UseVisualStyleBackColor = true;
            this.OkSerializeName.Click += new System.EventHandler(this.OkSerializeName_Click);
            // 
            // CancelSerializeName
            // 
            this.CancelSerializeName.Location = new System.Drawing.Point(136, 85);
            this.CancelSerializeName.Name = "CancelSerializeName";
            this.CancelSerializeName.Size = new System.Drawing.Size(75, 23);
            this.CancelSerializeName.TabIndex = 1;
            this.CancelSerializeName.Text = "关闭";
            this.CancelSerializeName.UseVisualStyleBackColor = true;
            this.CancelSerializeName.Click += new System.EventHandler(this.CancelSerializeName_Click);
            // 
            // SerializeColumName
            // 
            this.SerializeColumName.Location = new System.Drawing.Point(45, 41);
            this.SerializeColumName.Name = "SerializeColumName";
            this.SerializeColumName.Size = new System.Drawing.Size(166, 21);
            this.SerializeColumName.TabIndex = 2;
            this.SerializeColumName.TextChanged += new System.EventHandler(this.SerializeColumName_TextChanged);
            // 
            // DialogContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 120);
            this.Controls.Add(this.SerializeColumName);
            this.Controls.Add(this.CancelSerializeName);
            this.Controls.Add(this.OkSerializeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Dialog";
            this.Text = "Content";
            this.Load += new System.EventHandler(this.CloumnName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkSerializeName;
        private System.Windows.Forms.Button CancelSerializeName;
        public  System.Windows.Forms.TextBox SerializeColumName;
    }
}
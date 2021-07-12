
namespace JsonShow
{
    partial class Rich
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
            this.Content = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Content.Font = new System.Drawing.Font("黑体", 14.25F);
            this.Content.Location = new System.Drawing.Point(12, 12);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(776, 426);
            this.Content.TabIndex = 0;
            this.Content.Text = "";
            this.Content.TextChanged += new System.EventHandler(this.RichContents_TextChanged);
            // 
            // Rich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Content);
            this.Name = "Rich";
            this.Text = "RichContent";
            this.Load += new System.EventHandler(this.RichContent_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox Content;
    }
}
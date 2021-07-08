
using System.Windows.Forms;

namespace JsonShow
{
    partial class SerializeJsonForm
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
            this.components = new System.ComponentModel.Container();
            this.CloumnMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreatJson = new System.Windows.Forms.Button();
            this.CreatReoGrid = new unvell.ReoGrid.ReoGridControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DeSerializedJson = new System.Windows.Forms.Button();
            this.SerializedExcel = new System.Windows.Forms.Button();
            this.CloumnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloumnMenu
            // 
            this.CloumnMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.CloumnMenu.Name = "CloumnMenu";
            this.CloumnMenu.Size = new System.Drawing.Size(69, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            // 
            // CreatJson
            // 
            this.CreatJson.AllowDrop = true;
            this.CreatJson.Location = new System.Drawing.Point(12, 12);
            this.CreatJson.Name = "CreatJson";
            this.CreatJson.Size = new System.Drawing.Size(98, 23);
            this.CreatJson.TabIndex = 3;
            this.CreatJson.Text = "生成Json文件";
            this.CreatJson.UseVisualStyleBackColor = true;
            this.CreatJson.Click += new System.EventHandler(this.CreatJsons);
            // 
            // CreatReoGrid
            // 
            this.CreatReoGrid.AllowDrop = true;
            this.CreatReoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreatReoGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CreatReoGrid.ColumnHeaderContextMenuStrip = null;
            this.CreatReoGrid.LeadHeaderContextMenuStrip = null;
            this.CreatReoGrid.Location = new System.Drawing.Point(12, 41);
            this.CreatReoGrid.Name = "CreatReoGrid";
            this.CreatReoGrid.RowHeaderContextMenuStrip = null;
            this.CreatReoGrid.Script = null;
            this.CreatReoGrid.SheetTabContextMenuStrip = null;
            this.CreatReoGrid.SheetTabNewButtonVisible = true;
            this.CreatReoGrid.SheetTabVisible = true;
            this.CreatReoGrid.SheetTabWidth = 60;
            this.CreatReoGrid.ShowScrollEndSpacing = true;
            this.CreatReoGrid.Size = new System.Drawing.Size(776, 397);
            this.CreatReoGrid.TabIndex = 4;
            this.CreatReoGrid.Text = "reoGridControl1";
            this.CreatReoGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDragDrop);
            this.CreatReoGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDragEnter);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.Location = new System.Drawing.Point(116, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "添加行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RowAdd);
            // 
            // button2
            // 
            this.button2.AllowDrop = true;
            this.button2.Location = new System.Drawing.Point(220, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "添加列";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ColumnAdd);
            // 
            // DeSerializedJson
            // 
            this.DeSerializedJson.AllowDrop = true;
            this.DeSerializedJson.Location = new System.Drawing.Point(324, 12);
            this.DeSerializedJson.Name = "DeSerializedJson";
            this.DeSerializedJson.Size = new System.Drawing.Size(98, 23);
            this.DeSerializedJson.TabIndex = 7;
            this.DeSerializedJson.Text = "解析Json文件";
            this.DeSerializedJson.UseVisualStyleBackColor = true;
            this.DeSerializedJson.Click += new System.EventHandler(this.DeSerializedJson_Click);
            // 
            // SerializedExcel
            // 
            this.SerializedExcel.Location = new System.Drawing.Point(429, 12);
            this.SerializedExcel.Name = "SerializedExcel";
            this.SerializedExcel.Size = new System.Drawing.Size(75, 23);
            this.SerializedExcel.TabIndex = 8;
            this.SerializedExcel.Text = "解析Excel";
            this.SerializedExcel.UseVisualStyleBackColor = true;
            this.SerializedExcel.Click += new System.EventHandler(this.SerializedExcel_Click);
            // 
            // SerializeJsonForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SerializedExcel);
            this.Controls.Add(this.DeSerializedJson);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CreatReoGrid);
            this.Controls.Add(this.CreatJson);
            this.Name = "SerializeJsonForm";
            this.Text = "SerializeJsonForm";
            this.Load += new System.EventHandler(this.SerializeJsonForm_Load);
            this.CloumnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CreatJson;
        private System.Windows.Forms.ContextMenuStrip CloumnMenu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private unvell.ReoGrid.ReoGridControl CreatReoGrid;
        private Button button1;
        private Button button2;
        private Button DeSerializedJson;
        private Button SerializedExcel;
    }
}
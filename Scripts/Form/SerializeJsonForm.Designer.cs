
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
            this.CreatReoGrid = new unvell.ReoGrid.ReoGridControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按行生成Json每行一个文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoAddEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.按列生成Json文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成单个Json文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成C实体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析Json文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析Excel文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloumnMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            // CreatReoGrid
            // 
            this.CreatReoGrid.AllowDrop = true;
            this.CreatReoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreatReoGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CreatReoGrid.ColumnHeaderContextMenuStrip = null;
            this.CreatReoGrid.LeadHeaderContextMenuStrip = null;
            this.CreatReoGrid.Location = new System.Drawing.Point(12, 28);
            this.CreatReoGrid.Name = "CreatReoGrid";
            this.CreatReoGrid.RowHeaderContextMenuStrip = null;
            this.CreatReoGrid.Script = null;
            this.CreatReoGrid.SheetTabContextMenuStrip = null;
            this.CreatReoGrid.SheetTabNewButtonVisible = true;
            this.CreatReoGrid.SheetTabVisible = true;
            this.CreatReoGrid.SheetTabWidth = 60;
            this.CreatReoGrid.ShowScrollEndSpacing = true;
            this.CreatReoGrid.Size = new System.Drawing.Size(788, 410);
            this.CreatReoGrid.TabIndex = 4;
            this.CreatReoGrid.Text = "reoGridControl1";
            this.CreatReoGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDragDrop);
            this.CreatReoGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDragEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.解析ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 生成ToolStripMenuItem
            // 
            this.生成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按行生成Json每行一个文件ToolStripMenuItem,
            this.AutoAddEditor,
            this.按列生成Json文件ToolStripMenuItem,
            this.生成单个Json文件ToolStripMenuItem,
            this.生成C实体ToolStripMenuItem});
            this.生成ToolStripMenuItem.Name = "生成ToolStripMenuItem";
            this.生成ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.生成ToolStripMenuItem.Text = "生成";
            // 
            // 按行生成Json每行一个文件ToolStripMenuItem
            // 
            this.按行生成Json每行一个文件ToolStripMenuItem.Name = "按行生成Json每行一个文件ToolStripMenuItem";
            this.按行生成Json每行一个文件ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.按行生成Json每行一个文件ToolStripMenuItem.Text = "按行生成Json文件";
            this.按行生成Json每行一个文件ToolStripMenuItem.Click += new System.EventHandler(this.CreatJsons);
            // 
            // AutoAddEditor
            // 
            this.AutoAddEditor.Name = "AutoAddEditor";
            this.AutoAddEditor.Size = new System.Drawing.Size(222, 22);
            this.AutoAddEditor.Text = "自动添加到Json编辑器";
            this.AutoAddEditor.Click += new System.EventHandler(this.AutoEditorToolStripMenuItem_Click);
            // 
            // 按列生成Json文件ToolStripMenuItem
            // 
            this.按列生成Json文件ToolStripMenuItem.Name = "按列生成Json文件ToolStripMenuItem";
            this.按列生成Json文件ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.按列生成Json文件ToolStripMenuItem.Text = "按列生成Json文件（无效）";
            // 
            // 生成单个Json文件ToolStripMenuItem
            // 
            this.生成单个Json文件ToolStripMenuItem.Name = "生成单个Json文件ToolStripMenuItem";
            this.生成单个Json文件ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.生成单个Json文件ToolStripMenuItem.Text = "生成单个Json文件（无效）";
            // 
            // 生成C实体ToolStripMenuItem
            // 
            this.生成C实体ToolStripMenuItem.Name = "生成C实体ToolStripMenuItem";
            this.生成C实体ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.生成C实体ToolStripMenuItem.Text = "生成C#实体（无效）";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加行ToolStripMenuItem,
            this.添加列ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 添加行ToolStripMenuItem
            // 
            this.添加行ToolStripMenuItem.Name = "添加行ToolStripMenuItem";
            this.添加行ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加行ToolStripMenuItem.Text = "修改行数";
            this.添加行ToolStripMenuItem.Click += new System.EventHandler(this.SetRowToolStripMenuItem_Click);
            // 
            // 添加列ToolStripMenuItem
            // 
            this.添加列ToolStripMenuItem.Name = "添加列ToolStripMenuItem";
            this.添加列ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加列ToolStripMenuItem.Text = "修改列数";
            this.添加列ToolStripMenuItem.Click += new System.EventHandler(this.SetColumnsToolStripMenuItem_Click);
            // 
            // 解析ToolStripMenuItem
            // 
            this.解析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.解析Json文件ToolStripMenuItem,
            this.解析Excel文件ToolStripMenuItem});
            this.解析ToolStripMenuItem.Name = "解析ToolStripMenuItem";
            this.解析ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.解析ToolStripMenuItem.Text = "解析";
            // 
            // 解析Json文件ToolStripMenuItem
            // 
            this.解析Json文件ToolStripMenuItem.Name = "解析Json文件ToolStripMenuItem";
            this.解析Json文件ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.解析Json文件ToolStripMenuItem.Text = "解析Json文件";
            this.解析Json文件ToolStripMenuItem.Click += new System.EventHandler(this.JsonSerializedToolStripMenuItem_Click);
            // 
            // 解析Excel文件ToolStripMenuItem
            // 
            this.解析Excel文件ToolStripMenuItem.Name = "解析Excel文件ToolStripMenuItem";
            this.解析Excel文件ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.解析Excel文件ToolStripMenuItem.Text = "解析Excel文件";
            this.解析Excel文件ToolStripMenuItem.Click += new System.EventHandler(this.ExcelSerializeToolStripMenuItem_Click);
            // 
            // SerializeJsonForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.CreatReoGrid);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SerializeJsonForm";
            this.Text = "SerializeJsonForm";
            this.Load += new System.EventHandler(this.SerializeJsonForm_Load);
            this.CloumnMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip CloumnMenu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private unvell.ReoGrid.ReoGridControl CreatReoGrid;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 生成ToolStripMenuItem;
        private ToolStripMenuItem 按行生成Json每行一个文件ToolStripMenuItem;
        private ToolStripMenuItem AutoAddEditor;
        private ToolStripMenuItem 按列生成Json文件ToolStripMenuItem;
        private ToolStripMenuItem 生成单个Json文件ToolStripMenuItem;
        private ToolStripMenuItem 生成C实体ToolStripMenuItem;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 添加行ToolStripMenuItem;
        private ToolStripMenuItem 添加列ToolStripMenuItem;
        private ToolStripMenuItem 解析ToolStripMenuItem;
        private ToolStripMenuItem 解析Json文件ToolStripMenuItem;
        private ToolStripMenuItem 解析Excel文件ToolStripMenuItem;
    }
}
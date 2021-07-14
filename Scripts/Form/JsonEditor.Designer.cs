
namespace JsonShow
{
    partial class JsonEditor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonEditor));
            this.ShowJsonList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFilesfromList = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenJsonFileInExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenJsonFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCurrentJson = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllJson = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSaveHook = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoFormHook = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearJsonList = new System.Windows.Forms.ToolStripMenuItem();
            this.ClealCaches = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenCachesFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自适应宽高ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerializeJson = new System.Windows.Forms.ToolStripMenuItem();
            this.json生成器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.json内容展示窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.进度 = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.状态 = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorState = new System.Windows.Forms.ToolStripStatusLabel();
            this.Json = new System.Windows.Forms.Label();
            this.MainReoGrid = new unvell.ReoGrid.ReoGridControl();
            this.FormCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看详细内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.JsonEditorRich = new System.Windows.Forms.RichTextBox();
            this.打开项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.FormCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowJsonList
            // 
            this.ShowJsonList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowJsonList.ContextMenuStrip = this.contextMenuStrip;
            this.ShowJsonList.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowJsonList.FormattingEnabled = true;
            this.ShowJsonList.HorizontalScrollbar = true;
            this.ShowJsonList.ItemHeight = 19;
            this.ShowJsonList.Location = new System.Drawing.Point(43, 80);
            this.ShowJsonList.Name = "ShowJsonList";
            this.ShowJsonList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ShowJsonList.Size = new System.Drawing.Size(328, 631);
            this.ShowJsonList.TabIndex = 2;
            this.ShowJsonList.SelectedIndexChanged += new System.EventHandler(this.JsonShowList_SelectedIndexChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteJsonFiles,
            this.DeleteFilesfromList,
            this.OpenJsonFileInExplore});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(173, 70);
            // 
            // DeleteJsonFiles
            // 
            this.DeleteJsonFiles.Name = "DeleteJsonFiles";
            this.DeleteJsonFiles.Size = new System.Drawing.Size(172, 22);
            this.DeleteJsonFiles.Text = "删除文件";
            this.DeleteJsonFiles.Click += new System.EventHandler(this.DeleteJsonFiles_Click);
            // 
            // DeleteFilesfromList
            // 
            this.DeleteFilesfromList.Name = "DeleteFilesfromList";
            this.DeleteFilesfromList.Size = new System.Drawing.Size(172, 22);
            this.DeleteFilesfromList.Text = "从列表中删除";
            this.DeleteFilesfromList.Click += new System.EventHandler(this.DeleteFilesfromList_Click);
            // 
            // OpenJsonFileInExplore
            // 
            this.OpenJsonFileInExplore.Name = "OpenJsonFileInExplore";
            this.OpenJsonFileInExplore.Size = new System.Drawing.Size(172, 22);
            this.OpenJsonFileInExplore.Text = "打开文件所在目录";
            this.OpenJsonFileInExplore.Click += new System.EventHandler(this.OpenJsonFileInExplore_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(43, 28);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(181, 21);
            this.SearchText.TabIndex = 4;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.White;
            this.SearchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchButton.BackgroundImage")));
            this.SearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Location = new System.Drawing.Point(232, 28);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(21, 21);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.选项ToolStripMenuItem,
            this.SerializeJson});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开项目ToolStripMenuItem,
            this.openJsonFile,
            this.OpenJsonFolder,
            this.SaveCurrentJson,
            this.SaveAllJson,
            this.AutoSaveHook,
            this.AutoFormHook});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // openJsonFile
            // 
            this.openJsonFile.Name = "openJsonFile";
            this.openJsonFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openJsonFile.Size = new System.Drawing.Size(226, 22);
            this.openJsonFile.Text = "打开文件";
            this.openJsonFile.Click += new System.EventHandler(this.OpenFile_ItemClicked);
            // 
            // OpenJsonFolder
            // 
            this.OpenJsonFolder.Name = "OpenJsonFolder";
            this.OpenJsonFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.OpenJsonFolder.Size = new System.Drawing.Size(226, 22);
            this.OpenJsonFolder.Text = "打开文件夹";
            this.OpenJsonFolder.Click += new System.EventHandler(this.OpenJsonFolde_Click);
            // 
            // SaveCurrentJson
            // 
            this.SaveCurrentJson.Name = "SaveCurrentJson";
            this.SaveCurrentJson.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveCurrentJson.Size = new System.Drawing.Size(226, 22);
            this.SaveCurrentJson.Text = "保存当前文件修改";
            this.SaveCurrentJson.Click += new System.EventHandler(this.SaveJson);
            // 
            // SaveAllJson
            // 
            this.SaveAllJson.Name = "SaveAllJson";
            this.SaveAllJson.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAllJson.Size = new System.Drawing.Size(226, 22);
            this.SaveAllJson.Text = "保存所有修改";
            this.SaveAllJson.Click += new System.EventHandler(this.SaveAllJsons);
            // 
            // 自动保存ToolStripMenuItem
            // 
            this.AutoSaveHook.Name = "AutoSaveHook";
            this.AutoSaveHook.Size = new System.Drawing.Size(226, 22);
            this.AutoSaveHook.Text = "自动保存";
            this.AutoSaveHook.Click += new System.EventHandler(this.AutoSaveToolStripMenuItem_Click);
            // 
            // AutoFormHook
            // 
            this.AutoFormHook.Name = "AutoFormHook";
            this.AutoFormHook.Size = new System.Drawing.Size(226, 22);
            this.AutoFormHook.Text = "自动同步表格";
            this.AutoFormHook.Click += new System.EventHandler(this.AutoForm_ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearJsonList,
            this.ClealCaches,
            this.OpenCachesFolder});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // ClearJsonList
            // 
            this.ClearJsonList.Name = "ClearJsonList";
            this.ClearJsonList.Size = new System.Drawing.Size(160, 22);
            this.ClearJsonList.Text = "清空列表";
            this.ClearJsonList.Click += new System.EventHandler(this.ClearJsonLists_ItemClicked);
            // 
            // ClealCaches
            // 
            this.ClealCaches.Name = "ClealCaches";
            this.ClealCaches.Size = new System.Drawing.Size(160, 22);
            this.ClealCaches.Text = "清空缓存";
            this.ClealCaches.Click += new System.EventHandler(this.ClearCache_ItemClicked);
            // 
            // OpenCachesFolder
            // 
            this.OpenCachesFolder.Name = "OpenCachesFolder";
            this.OpenCachesFolder.Size = new System.Drawing.Size(160, 22);
            this.OpenCachesFolder.Text = "打开缓存文件夹";
            this.OpenCachesFolder.Click += new System.EventHandler(this.OpenCacheFolder_Clicked);
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.自适应宽高ToolStripMenuItem});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 自适应宽高ToolStripMenuItem
            // 
            this.自适应宽高ToolStripMenuItem.Name = "自适应宽高ToolStripMenuItem";
            this.自适应宽高ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.自适应宽高ToolStripMenuItem.Text = "自适应宽高";
            this.自适应宽高ToolStripMenuItem.Click += new System.EventHandler(this.AutoCellSize_MenuItem_Click);
            // 
            // SerializeJson
            // 
            this.SerializeJson.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.json生成器ToolStripMenuItem,
            this.json内容展示窗口ToolStripMenuItem});
            this.SerializeJson.Name = "SerializeJson";
            this.SerializeJson.Size = new System.Drawing.Size(44, 21);
            this.SerializeJson.Text = "视图";
            this.SerializeJson.Click += new System.EventHandler(this.SerializeJson_Click);
            // 
            // json生成器ToolStripMenuItem
            // 
            this.json生成器ToolStripMenuItem.Name = "json生成器ToolStripMenuItem";
            this.json生成器ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.json生成器ToolStripMenuItem.Text = "Json生成器";
            this.json生成器ToolStripMenuItem.Click += new System.EventHandler(this.JsonCreateEditorToolStripMenuItem_Click);
            // 
            // json内容展示窗口ToolStripMenuItem
            // 
            this.json内容展示窗口ToolStripMenuItem.Name = "json内容展示窗口ToolStripMenuItem";
            this.json内容展示窗口ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.json内容展示窗口ToolStripMenuItem.Text = "Json内容展示窗口";
            this.json内容展示窗口ToolStripMenuItem.Click += new System.EventHandler(this.JsonContentEditorToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.进度,
            this.EditorProgressBar,
            this.状态,
            this.EditorState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // 进度
            // 
            this.进度.Name = "进度";
            this.进度.Size = new System.Drawing.Size(35, 17);
            this.进度.Text = "进度:";
            // 
            // EditorProgressBar
            // 
            this.EditorProgressBar.Name = "EditorProgressBar";
            this.EditorProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // 状态
            // 
            this.状态.Margin = new System.Windows.Forms.Padding(15, 3, 0, 2);
            this.状态.Name = "状态";
            this.状态.Size = new System.Drawing.Size(35, 17);
            this.状态.Text = "状态:";
            // 
            // EditorState
            // 
            this.EditorState.Name = "EditorState";
            this.EditorState.Size = new System.Drawing.Size(44, 17);
            this.EditorState.Text = "可操作";
            // 
            // Json
            // 
            this.Json.AutoSize = true;
            this.Json.Location = new System.Drawing.Point(43, 62);
            this.Json.Name = "Json";
            this.Json.Size = new System.Drawing.Size(53, 12);
            this.Json.TabIndex = 8;
            this.Json.Text = "文件目录";
            // 
            // MainReoGrid
            // 
            this.MainReoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainReoGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainReoGrid.ColumnHeaderContextMenuStrip = null;
            this.MainReoGrid.ContextMenuStrip = this.FormCell;
            this.MainReoGrid.LeadHeaderContextMenuStrip = null;
            this.MainReoGrid.Location = new System.Drawing.Point(413, 80);
            this.MainReoGrid.Name = "MainReoGrid";
            this.MainReoGrid.RowHeaderContextMenuStrip = null;
            this.MainReoGrid.Script = null;
            this.MainReoGrid.SheetTabContextMenuStrip = null;
            this.MainReoGrid.SheetTabNewButtonVisible = true;
            this.MainReoGrid.SheetTabVisible = true;
            this.MainReoGrid.SheetTabWidth = 60;
            this.MainReoGrid.ShowScrollEndSpacing = true;
            this.MainReoGrid.Size = new System.Drawing.Size(859, 631);
            this.MainReoGrid.TabIndex = 10;
            this.MainReoGrid.Text = "reoGridControl1";
            this.MainReoGrid.Click += new System.EventHandler(this.MainReoGrid_Click);
            // 
            // FormCell
            // 
            this.FormCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看详细内容ToolStripMenuItem});
            this.FormCell.Name = "FormCell";
            this.FormCell.Size = new System.Drawing.Size(149, 26);
            // 
            // 查看详细内容ToolStripMenuItem
            // 
            this.查看详细内容ToolStripMenuItem.Name = "查看详细内容ToolStripMenuItem";
            this.查看详细内容ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查看详细内容ToolStripMenuItem.Text = "查看详细内容";
            this.查看详细内容ToolStripMenuItem.Click += new System.EventHandler(this.CellLookToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Dserialized Form";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // JsonEditorRich
            // 
            this.JsonEditorRich.Location = new System.Drawing.Point(1112, 4);
            this.JsonEditorRich.Name = "JsonEditorRich";
            this.JsonEditorRich.ReadOnly = true;
            this.JsonEditorRich.ShortcutsEnabled = false;
            this.JsonEditorRich.Size = new System.Drawing.Size(172, 70);
            this.JsonEditorRich.TabIndex = 12;
            this.JsonEditorRich.Text = "";
            this.JsonEditorRich.Visible = false;
            // 
            // 打开项目ToolStripMenuItem
            // 
            this.打开项目ToolStripMenuItem.Name = "打开项目ToolStripMenuItem";
            this.打开项目ToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.打开项目ToolStripMenuItem.Text = "打开项目";
            this.打开项目ToolStripMenuItem.Click += new System.EventHandler(this.OpenProjectToolStripMenuItem_Click);
            // 
            // JsonEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.JsonEditorRich);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainReoGrid);
            this.Controls.Add(this.Json);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.ShowJsonList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "JsonEditor";
            this.Text = "Json编辑器";
            this.Load += new System.EventHandler(this.JsonEditorLoad);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.FormCell.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox ShowJsonList;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openJsonFile;
        private System.Windows.Forms.ToolStripMenuItem OpenJsonFolder;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveCurrentJson;
        private System.Windows.Forms.ToolStripMenuItem SaveAllJson;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar EditorProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel 进度;
        private System.Windows.Forms.ToolStripStatusLabel 状态;
        private System.Windows.Forms.ToolStripStatusLabel EditorState;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearJsonList;
        private System.Windows.Forms.Label Json;
        private System.Windows.Forms.ToolStripMenuItem ClealCaches;
        private System.Windows.Forms.ToolStripMenuItem OpenCachesFolder;
        private System.Windows.Forms.ToolStripMenuItem AutoSaveHook;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteJsonFiles;
        private System.Windows.Forms.ToolStripMenuItem DeleteFilesfromList;
        private System.Windows.Forms.ToolStripMenuItem OpenJsonFileInExplore;
        private System.Windows.Forms.ToolStripMenuItem SerializeJson;
        private unvell.ReoGrid.ReoGridControl MainReoGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem AutoFormHook;
        private System.Windows.Forms.ToolStripMenuItem 自适应宽高ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip FormCell;
        private System.Windows.Forms.ToolStripMenuItem 查看详细内容ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem json生成器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem json内容展示窗口ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox JsonEditorRich;
        private System.Windows.Forms.ToolStripMenuItem 打开项目ToolStripMenuItem;
    }
}


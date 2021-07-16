
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点7", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点3", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点2");
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenJsonFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCurrentJson = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllJson = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSaveHook = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoFormHook = new System.Windows.Forms.ToolStripMenuItem();
            this.导出当前Json类型文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClealCaches = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenCachesFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.修改行数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改列数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自适应宽高ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerializeJson = new System.Windows.Forms.ToolStripMenuItem();
            this.生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按行生成Json文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoAddEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析Json文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析Excel文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.进度 = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.状态 = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorState = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainReoGrid = new unvell.ReoGrid.ReoGridControl();
            this.FormCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看详细内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.FormCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(12, 39);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(148, 21);
            this.SearchText.TabIndex = 4;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.White;
            this.SearchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchButton.BackgroundImage")));
            this.SearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Location = new System.Drawing.Point(166, 38);
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
            this.SerializeJson,
            this.生成ToolStripMenuItem,
            this.解析ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
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
            this.AutoFormHook,
            this.导出当前Json类型文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开项目ToolStripMenuItem
            // 
            this.打开项目ToolStripMenuItem.Name = "打开项目ToolStripMenuItem";
            this.打开项目ToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.打开项目ToolStripMenuItem.Text = "打开项目";
            this.打开项目ToolStripMenuItem.Click += new System.EventHandler(this.OpenProjectToolStripMenuItem_Click);
            // 
            // openJsonFile
            // 
            this.openJsonFile.Name = "openJsonFile";
            this.openJsonFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openJsonFile.Size = new System.Drawing.Size(262, 22);
            this.openJsonFile.Text = "打开文件";
            this.openJsonFile.Click += new System.EventHandler(this.OpenFile_ItemClicked);
            // 
            // OpenJsonFolder
            // 
            this.OpenJsonFolder.Name = "OpenJsonFolder";
            this.OpenJsonFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.OpenJsonFolder.Size = new System.Drawing.Size(262, 22);
            this.OpenJsonFolder.Text = "打开文件夹";
            this.OpenJsonFolder.Click += new System.EventHandler(this.OpenJsonFolde_Click);
            // 
            // SaveCurrentJson
            // 
            this.SaveCurrentJson.Name = "SaveCurrentJson";
            this.SaveCurrentJson.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveCurrentJson.Size = new System.Drawing.Size(262, 22);
            this.SaveCurrentJson.Text = "保存当前文件修改(todo)";
            this.SaveCurrentJson.Click += new System.EventHandler(this.SaveJson);
            // 
            // SaveAllJson
            // 
            this.SaveAllJson.Name = "SaveAllJson";
            this.SaveAllJson.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAllJson.Size = new System.Drawing.Size(262, 22);
            this.SaveAllJson.Text = "保存所有修改(todo)";
            this.SaveAllJson.Click += new System.EventHandler(this.SaveAllJsons);
            // 
            // AutoSaveHook
            // 
            this.AutoSaveHook.Name = "AutoSaveHook";
            this.AutoSaveHook.Size = new System.Drawing.Size(262, 22);
            this.AutoSaveHook.Text = "自动保存";
            this.AutoSaveHook.Click += new System.EventHandler(this.AutoSaveToolStripMenuItem_Click);
            // 
            // AutoFormHook
            // 
            this.AutoFormHook.Name = "AutoFormHook";
            this.AutoFormHook.Size = new System.Drawing.Size(262, 22);
            this.AutoFormHook.Text = "自动同步表格";
            this.AutoFormHook.Click += new System.EventHandler(this.AutoForm_ToolStripMenuItem_Click);
            // 
            // 导出当前Json类型文件ToolStripMenuItem
            // 
            this.导出当前Json类型文件ToolStripMenuItem.Name = "导出当前Json类型文件ToolStripMenuItem";
            this.导出当前Json类型文件ToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.导出当前Json类型文件ToolStripMenuItem.Text = "导出当前Json类型文件(todo)";
            this.导出当前Json类型文件ToolStripMenuItem.Click += new System.EventHandler(this.ExpertJsonToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClealCaches,
            this.OpenCachesFolder,
            this.修改行数ToolStripMenuItem,
            this.修改列数ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // ClealCaches
            // 
            this.ClealCaches.Name = "ClealCaches";
            this.ClealCaches.Size = new System.Drawing.Size(196, 22);
            this.ClealCaches.Text = "清空缓存(todo)";
            this.ClealCaches.Click += new System.EventHandler(this.ClearCache_ItemClicked);
            // 
            // OpenCachesFolder
            // 
            this.OpenCachesFolder.Name = "OpenCachesFolder";
            this.OpenCachesFolder.Size = new System.Drawing.Size(196, 22);
            this.OpenCachesFolder.Text = "打开缓存文件夹(todo)";
            this.OpenCachesFolder.Click += new System.EventHandler(this.OpenCacheFolder_Clicked);
            // 
            // 修改行数ToolStripMenuItem
            // 
            this.修改行数ToolStripMenuItem.Name = "修改行数ToolStripMenuItem";
            this.修改行数ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.修改行数ToolStripMenuItem.Text = "修改行数";
            this.修改行数ToolStripMenuItem.Click += new System.EventHandler(this.ChangeRowToolStripMenuItem_Click);
            // 
            // 修改列数ToolStripMenuItem
            // 
            this.修改列数ToolStripMenuItem.Name = "修改列数ToolStripMenuItem";
            this.修改列数ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.修改列数ToolStripMenuItem.Text = "修改列数";
            this.修改列数ToolStripMenuItem.Click += new System.EventHandler(this.ChangeColumnToolStripMenuItem_Click);
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
            this.SerializeJson.Name = "SerializeJson";
            this.SerializeJson.Size = new System.Drawing.Size(44, 21);
            this.SerializeJson.Text = "视图";
            this.SerializeJson.Click += new System.EventHandler(this.SerializeJson_Click);
            // 
            // 生成ToolStripMenuItem
            // 
            this.生成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按行生成Json文件ToolStripMenuItem,
            this.AutoAddEditorToolStripMenuItem});
            this.生成ToolStripMenuItem.Name = "生成ToolStripMenuItem";
            this.生成ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.生成ToolStripMenuItem.Text = "生成";
            // 
            // 按行生成Json文件ToolStripMenuItem
            // 
            this.按行生成Json文件ToolStripMenuItem.Name = "按行生成Json文件ToolStripMenuItem";
            this.按行生成Json文件ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.按行生成Json文件ToolStripMenuItem.Text = "按行生成Json文件";
            this.按行生成Json文件ToolStripMenuItem.Click += new System.EventHandler(this.CreatJsonByRowToolStripMenuItem_Click);
            // 
            // AutoAddEditorToolStripMenuItem
            // 
            this.AutoAddEditorToolStripMenuItem.Name = "AutoAddEditorToolStripMenuItem";
            this.AutoAddEditorToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.AutoAddEditorToolStripMenuItem.Text = "自动添加到Json编辑器";
            this.AutoAddEditorToolStripMenuItem.Click += new System.EventHandler(this.AutoAddEditorToolStripMenuItem_Click);
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
            this.解析Json文件ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.解析Json文件ToolStripMenuItem.Text = "解析Json文件";
            this.解析Json文件ToolStripMenuItem.Click += new System.EventHandler(this.SerializeJsonToolStripMenuItem_Click);
            // 
            // 解析Excel文件ToolStripMenuItem
            // 
            this.解析Excel文件ToolStripMenuItem.Name = "解析Excel文件ToolStripMenuItem";
            this.解析Excel文件ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.解析Excel文件ToolStripMenuItem.Text = "解析Excel文件";
            this.解析Excel文件ToolStripMenuItem.Click += new System.EventHandler(this.SerializeExcelToolStripMenuItem_Click);
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
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
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
            // MainReoGrid
            // 
            this.MainReoGrid.AllowDrop = true;
            this.MainReoGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainReoGrid.ColumnHeaderContextMenuStrip = null;
            this.MainReoGrid.ContextMenuStrip = this.FormCell;
            this.MainReoGrid.LeadHeaderContextMenuStrip = null;
            this.MainReoGrid.Location = new System.Drawing.Point(318, 80);
            this.MainReoGrid.Name = "MainReoGrid";
            this.MainReoGrid.RowHeaderContextMenuStrip = null;
            this.MainReoGrid.Script = null;
            this.MainReoGrid.SheetTabContextMenuStrip = null;
            this.MainReoGrid.SheetTabNewButtonVisible = true;
            this.MainReoGrid.SheetTabVisible = true;
            this.MainReoGrid.SheetTabWidth = 60;
            this.MainReoGrid.ShowScrollEndSpacing = true;
            this.MainReoGrid.Size = new System.Drawing.Size(854, 656);
            this.MainReoGrid.TabIndex = 10;
            this.MainReoGrid.Text = "reoGridControl1";
            this.MainReoGrid.Click += new System.EventHandler(this.MainReoGrid_Click);
            this.MainReoGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDragDrop);
            this.MainReoGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDragEnter);
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
            this.label1.Location = new System.Drawing.Point(316, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Form";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(0, 80);
            this.TreeView.Name = "TreeView";
            treeNode1.Name = "节点9";
            treeNode1.Text = "节点9";
            treeNode2.Name = "节点10";
            treeNode2.Text = "节点10";
            treeNode3.Name = "节点11";
            treeNode3.Text = "节点11";
            treeNode4.Name = "节点12";
            treeNode4.Text = "节点12";
            treeNode5.BackColor = System.Drawing.Color.White;
            treeNode5.Name = "节点7";
            treeNode5.Text = "节点7";
            treeNode6.Name = "节点8";
            treeNode6.Text = "节点8";
            treeNode7.Name = "节点3";
            treeNode7.Text = "节点3";
            treeNode8.Name = "节点4";
            treeNode8.Text = "节点4";
            treeNode9.Name = "节点0";
            treeNode9.Text = "节点0";
            treeNode10.Name = "节点5";
            treeNode10.Text = "节点5";
            treeNode11.Name = "节点6";
            treeNode11.Text = "节点6";
            treeNode12.Name = "节点1";
            treeNode12.Text = "节点1";
            treeNode13.Name = "节点2";
            treeNode13.Text = "节点2";
            this.TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode12,
            treeNode13});
            this.TreeView.PathSeparator = "_";
            this.TreeView.Size = new System.Drawing.Size(287, 656);
            this.TreeView.TabIndex = 15;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // JsonEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainReoGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "JsonEditor";
            this.Text = "Json编辑器";
            this.Load += new System.EventHandler(this.JsonEditorLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.FormCell.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openJsonFile;
        private System.Windows.Forms.ToolStripMenuItem OpenJsonFolder;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar EditorProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel 进度;
        private System.Windows.Forms.ToolStripStatusLabel 状态;
        private System.Windows.Forms.ToolStripStatusLabel EditorState;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClealCaches;
        private System.Windows.Forms.ToolStripMenuItem OpenCachesFolder;
        private System.Windows.Forms.ToolStripMenuItem AutoSaveHook;
        private System.Windows.Forms.ToolStripMenuItem SerializeJson;
        private unvell.ReoGrid.ReoGridControl MainReoGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem AutoFormHook;
        private System.Windows.Forms.ToolStripMenuItem 自适应宽高ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip FormCell;
        private System.Windows.Forms.ToolStripMenuItem 查看详细内容ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出当前Json类型文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解析Json文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解析Excel文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按行生成Json文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoAddEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改行数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改列数ToolStripMenuItem;
        public System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ToolStripMenuItem SaveCurrentJson;
        private System.Windows.Forms.ToolStripMenuItem SaveAllJson;
    }
}


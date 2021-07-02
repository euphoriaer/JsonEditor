
namespace JsonShow
{
    partial class JsonEditors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonEditors));
            this.ShowJsonList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFilesfromList = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenJsonFileInExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowContent = new System.Windows.Forms.RichTextBox();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenJsonFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCurrentJson = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllJson = new System.Windows.Forms.ToolStripMenuItem();
            this.自动保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearJsonList = new System.Windows.Forms.ToolStripMenuItem();
            this.ClealCaches = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenCachesFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.进度 = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.状态 = new System.Windows.Forms.ToolStripStatusLabel();
            this.EditorState = new System.Windows.Forms.ToolStripStatusLabel();
            this.Json = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.ShowJsonList.Size = new System.Drawing.Size(328, 441);
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
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 92);
            // 
            // DeleteJsonFiles
            // 
            this.DeleteJsonFiles.Name = "DeleteJsonFiles";
            this.DeleteJsonFiles.Size = new System.Drawing.Size(180, 22);
            this.DeleteJsonFiles.Text = "删除文件";
            this.DeleteJsonFiles.Click += new System.EventHandler(this.DeleteJsonFiles_Click);
            // 
            // DeleteFilesfromList
            // 
            this.DeleteFilesfromList.Name = "DeleteFilesfromList";
            this.DeleteFilesfromList.Size = new System.Drawing.Size(180, 22);
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
            // ShowContent
            // 
            this.ShowContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowContent.Font = new System.Drawing.Font("黑体", 14.25F);
            this.ShowContent.Location = new System.Drawing.Point(413, 80);
            this.ShowContent.Name = "ShowContent";
            this.ShowContent.Size = new System.Drawing.Size(531, 448);
            this.ShowContent.TabIndex = 3;
            this.ShowContent.Text = "";
            this.ShowContent.TextChanged += new System.EventHandler(this.ShowContent_TextChanged);
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
            this.选项ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openJsonFile,
            this.OpenJsonFolder,
            this.SaveCurrentJson,
            this.SaveAllJson,
            this.自动保存ToolStripMenuItem});
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
            this.openJsonFile.Click += new System.EventHandler(this.OpenFile);
            // 
            // OpenJsonFolder
            // 
            this.OpenJsonFolder.Name = "OpenJsonFolder";
            this.OpenJsonFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.OpenJsonFolder.Size = new System.Drawing.Size(226, 22);
            this.OpenJsonFolder.Text = "打开文件夹";
            this.OpenJsonFolder.Click += new System.EventHandler(this.OpenJsonFolde);
            // 
            // SaveCurrentJson
            // 
            this.SaveCurrentJson.Name = "SaveCurrentJson";
            this.SaveCurrentJson.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveCurrentJson.Size = new System.Drawing.Size(226, 22);
            this.SaveCurrentJson.Text = "保存当前文件修改";
            this.SaveCurrentJson.Click += new System.EventHandler(this.SaveCurJson);
            // 
            // SaveAllJson
            // 
            this.SaveAllJson.Name = "SaveAllJson";
            this.SaveAllJson.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAllJson.Size = new System.Drawing.Size(226, 22);
            this.SaveAllJson.Text = "保存所有修改";
            this.SaveAllJson.Click += new System.EventHandler(this.SaveAllJsonFiile);
            // 
            // 自动保存ToolStripMenuItem
            // 
            this.自动保存ToolStripMenuItem.Name = "自动保存ToolStripMenuItem";
            this.自动保存ToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.自动保存ToolStripMenuItem.Text = "自动保存";
            this.自动保存ToolStripMenuItem.Click += new System.EventHandler(this.AutoSaveToolStripMenuItem_Click);
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
            this.ClearJsonList.Click += new System.EventHandler(this.ClearJsonLists);
            // 
            // ClealCaches
            // 
            this.ClealCaches.Name = "ClealCaches";
            this.ClealCaches.Size = new System.Drawing.Size(160, 22);
            this.ClealCaches.Text = "清空缓存";
            this.ClealCaches.Click += new System.EventHandler(this.ClearCache);
            // 
            // OpenCachesFolder
            // 
            this.OpenCachesFolder.Name = "OpenCachesFolder";
            this.OpenCachesFolder.Size = new System.Drawing.Size(160, 22);
            this.OpenCachesFolder.Text = "打开缓存文件夹";
            this.OpenCachesFolder.Click += new System.EventHandler(this.OpenCacheFolder);
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.进度,
            this.EditorProgressBar,
            this.状态,
            this.EditorState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "文件内容";
            // 
            // JsonEditors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Json);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.ShowContent);
            this.Controls.Add(this.ShowJsonList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "JsonEditors";
            this.Text = "Json编辑器";
            this.Load += new System.EventHandler(this.JsonEditorLoad);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox ShowJsonList;
        private System.Windows.Forms.RichTextBox ShowContent;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem ClealCaches;
        private System.Windows.Forms.ToolStripMenuItem OpenCachesFolder;
        private System.Windows.Forms.ToolStripMenuItem 自动保存ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteJsonFiles;
        private System.Windows.Forms.ToolStripMenuItem DeleteFilesfromList;
        private System.Windows.Forms.ToolStripMenuItem OpenJsonFileInExplore;
    }
}


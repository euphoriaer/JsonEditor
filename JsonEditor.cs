using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace JsonShow
{
    public partial class JsonEditors : Form
    {  //Key:文件名name无后缀，Value:文件对象Fileinfo
        private Dictionary<string, FileInfo> cacheDic = new Dictionary<string, FileInfo>();
        private Dictionary<string, FileInfo> jsonDic = new Dictionary<string, FileInfo>();
        private Dictionary<string, FileInfo> searDic = new Dictionary<string, FileInfo>();
        private bool autoSave = false;
        private bool autoCellSize = false;
        private bool autoForm = true;
        private string cachePath = Application.StartupPath + @"\Cache\";
        private Worksheet mainWorksheet;

        //当前启动目录为缓存文件目录
        //Dictionary<string jsonName, FileInfo jsonFile> jsonDic=new
        public JsonEditors()
        {
            InitializeComponent();
            //设置文本风格
            SetFont();
            AutoFormHook.Checked = true;
            mainWorksheet = MainReoGrid.CurrentWorksheet;
        }

        private void SetFont()
        {
            MainReoGrid.CurrentWorksheet.SetRangeStyles("A1:Z100", new WorksheetRangeStyle
            {
                Flag = PlainStyleFlag.HorizontalAlign,
                HAlign = ReoGridHorAlign.Center,
            });
        }

        private void AutoCellSize(Worksheet worksheet)
        {
            if (autoCellSize)
            {
                for (int i = 0; i < worksheet.ColumnCount; i++)
                {
                    worksheet.AutoFitColumnWidth(i, false);
                }
            }
        }

        private void AutoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            autoSave = (sender as ToolStripMenuItem).Checked;
        }

        private void CacheJsonFile(string cacheName, string cacheContent)
        {
            //todo 缓存优化，
            //1.只存修改的部分text
            //2.每次打开文件先从缓存读(List列表内容）
            //3.缓存缓存列表，启动读取

            DirectoryInfo cacheDir = Directory.CreateDirectory(cachePath);
            string tempCacheJsonPath = cacheDir.FullName + cacheName;
            File.WriteAllText(tempCacheJsonPath, cacheContent);
            if (!cacheDic.ContainsKey(cacheName))//不存在就加入到缓存列表
            {
                FileInfo cacheFile = new FileInfo(tempCacheJsonPath);
                cacheDic.Add(cacheName, cacheFile);
            }

            try
            {
                //加到缓存后，表格重新读取
                mainWorksheet = JsonTools.DeSerializeToForm(cacheDic[cacheName], MainReoGrid);
                //设置文本风格
                SetFont();
                //设置自适应宽高
                AutoCellSize(mainWorksheet);
                //添加RichContent同步
                SheetChangedEvent(mainWorksheet);
            }
            catch (Exception e)
            {
                MessageBox.Show("Json文件结构被破坏,表格无法显示");
                Console.WriteLine(e);
            }
        }

        private bool CheckValidity()
        {
            if (string.IsNullOrEmpty(RichContent.Text))
            {
                return true;
            }
            if (ShowJsonList.SelectedItem == null)
            {
                return true;
            }

            return false;
        }

        private void ClearCache_ItemClicked(object sender, EventArgs e)
        {
            DirectoryInfo tempDirectoryInfo = new DirectoryInfo(cachePath);
            FileInfo[] cacheJson = tempDirectoryInfo.GetFiles();
            foreach (var fileInfo in cacheJson)
            {
                fileInfo.Delete();
            }
            cacheDic.Clear();
        }

        private void ClearJsonLists_ItemClicked(object sender, EventArgs e)
        {
            RichContent.Text = "";
            ShowJsonList.Items.Clear();
            jsonDic.Clear();
            cacheDic.Clear();
        }

        private void DeleteFilesfromList_Click(object sender, EventArgs e)
        {
            var tempJsonObjs = ShowJsonList.SelectedItems;
            foreach (var tempJsonObj in tempJsonObjs)
            {
                string tempName = tempJsonObj as string;
                Debug.WriteLine(tempName);
                jsonDic.Remove(tempName);
                cacheDic.Remove(tempName);
            }
            RefreshListBox();
        }

        private void DeleteJsonFiles_Click(object sender, EventArgs e)
        {
            var tempJsonObjs = ShowJsonList.SelectedItems;
            foreach (var jsonObj in tempJsonObjs)
            {
                string tempName = jsonObj as string;
                Debug.WriteLine(tempName);
                Debug.WriteLine(jsonDic[tempName].FullName);
                File.Delete(jsonDic[tempName].FullName);
                jsonDic.Remove(tempName);
                cacheDic.Remove(tempName);
            }

            RefreshListBox();
        }

        private void JsonEditorLoad(object sender, EventArgs e)
        {
            SearchText.KeyDown += ((o, key) =>
            {
                if (key.KeyCode == (Keys.Enter) && SearchText.Focused)
                {
                    Debug.WriteLine("按下了Enter，开始搜索");
                    SearchButton_Click(sender, e);
                }
            });
        }

        private void JsonShowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileInfo tempJsonFile;
            ListBox tempListBox = sender as ListBox;
            //如果缓存里有，就展示缓存内容
            if (tempListBox.SelectedItem == null)
            {
                return;
            }

            if (cacheDic.ContainsKey(tempListBox.SelectedItem.ToString()))
            {
                tempJsonFile = cacheDic[tempListBox.SelectedItem.ToString()];
            }
            else
            {
                tempJsonFile = jsonDic[tempListBox.SelectedItem.ToString()];
            }
            mainWorksheet = JsonTools.DeSerializeToForm(tempJsonFile, MainReoGrid);
            //设置文本风格
            SetFont();
            //设置自适应宽高
            AutoCellSize(mainWorksheet);
            //添加RichContent同步
            SheetChangedEvent(mainWorksheet);
            //立即修改Rich
            RichContent.Text = File.ReadAllText(tempJsonFile.FullName);
        }

        private void SheetChangedEvent(Worksheet destinationWorksheet)
        {
            destinationWorksheet.CellDataChanged += ((send, args) =>
            {
                string selectName = ShowJsonList.SelectedItem.ToString();
                string json = JsonTools.SerializeToString(MainReoGrid.CurrentWorksheet);
                Debug.WriteLine("json：" + json);
                RichContent.Text = json;
                //如果勾选了自动保存，则同时写入文件
                AutoSave();
            });
        }

        /// <summary>
        /// 解析Json字符串
        /// </summary>
        /// <param name="jsonStr">需要解析的Json字符串</param>
        /// <returns>返回解析好的Hashtable表</returns>

        private void OpenCacheFolder_Clicked(object sender, EventArgs e)
        {
            DialogTools.OpenExplorer(cachePath);
        }

        /// <summary>
        /// Handles the Click event of the 打开文件ToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenFile_ItemClicked(object sender, EventArgs e)
        {
            bool isOk = false;
            string[] paths = DialogTools.OpenFiles(out isOk, "Josn文件|*.json|全部|*.*");
            if (isOk)
            {
                foreach (string path in paths)
                {
                    string tempJsonName = Path.GetFileNameWithoutExtension(path);
                    FileInfo tempJsonfile = new FileInfo(path);
                    if (jsonDic.ContainsKey(tempJsonName) == false)
                    {
                        jsonDic.Add(tempJsonName, tempJsonfile);

                        ShowJsonList.Items.Add(tempJsonName);
                    }
                }
            }
        }

        private void OpenJsonFileInExplore_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            string tempJsonPath = jsonDic[ShowJsonList.SelectedItem.ToString()].FullName;
            psi.Arguments = "/e,/select," + tempJsonPath;
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        /// Handles the Click event of the 打开Json文件夹ToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenJsonFolde_Click(object sender, EventArgs e)
        {
            string path = DialogTools.OpenFolder();
            DirectoryInfo jsonPath = new DirectoryInfo(path);
            FileInfo[] jsonFiles = jsonPath.GetFiles("*.json");
            foreach (var jsonFile in jsonFiles)
            {
                string tempJsonName = Path.GetFileNameWithoutExtension(jsonFile.Name);
                if (jsonDic.ContainsKey(tempJsonName) == false)
                {
                    ShowJsonList.Items.Add(tempJsonName);
                    jsonDic.Add(tempJsonName, jsonFile);
                }
            }
        }

        private void RefreshListBox()
        {
            //清空列表 重新添加
            RichContent.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var jsonDicKey in jsonDic.Keys)
            {
                ShowJsonList.Sorted = true;
                ShowJsonList.Items.Add(jsonDicKey);
            }
        }

        private void SaveAllJsons(object sender, EventArgs e)
        {
            try
            {
                foreach (var cacheDicKey in cacheDic.Keys)
                {
                    string tempContent = File.ReadAllText(cacheDic[cacheDicKey].FullName);
                    File.WriteAllText(jsonDic[cacheDicKey].FullName, tempContent);
                }

                EditorState.Text = "已保存";
            }
            catch (Exception exception)
            {
            }
        }

        private void SaveJson(object sender, EventArgs e)
        {
            try
            {
                string tempJsonName = ShowJsonList.SelectedItem.ToString();
                FileInfo tempJsonFile = jsonDic[tempJsonName];
                //如果缓存存在，将缓存内容保存到Json
                if (cacheDic.ContainsKey(tempJsonName))
                {
                    string tempCacheText = File.ReadAllText(cacheDic[tempJsonName].FullName);
                    File.WriteAllText(tempJsonFile.FullName, tempCacheText);
                    EditorState.Text = "缓存内容已写入：" + tempJsonFile.FullName;
                    return;
                }
                File.WriteAllText(tempJsonFile.FullName, RichContent.Text);
                EditorState.Text = "未修改";
            }
            catch (Exception exception)
            {
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            searDic.Clear();
            ShowJsonList.ClearSelected();
            string searchTarget = SearchText.Text;
            if (String.IsNullOrEmpty(searchTarget))
            {
                ShowAllJson();
                return;
            }

            //从所有Json文件搜索
            foreach (var jsonDicKey in jsonDic.Keys)
            {
                var isFind = jsonDicKey.IndexOf(searchTarget, StringComparison.CurrentCultureIgnoreCase);

                if (isFind >= 0)
                {
                    string itemName = jsonDicKey;
                    if (!searDic.ContainsKey(itemName))
                    {
                        searDic.Add(itemName, jsonDic[itemName]);
                    }
                }
            }

            #region search current Listbox

            //// 模糊搜索 从当前列表搜索
            //for (int i = 0; i < ShowJsonList.Items.Count; i++)
            //{
            //    var isFind = ShowJsonList.Items[i].ToString().IndexOf(searchTarget, StringComparison.CurrentCultureIgnoreCase);
            //    if (isFind >= 0)
            //    {
            //        string itemName = ShowJsonList.Items[i].ToString();
            //        ShowJsonList.SetSelected(i, true);
            //        if (!searDic.ContainsKey(itemName))
            //        {
            //            searDic.Add(itemName, jsonDic[itemName]);
            //        }
            //    }
            //    Debug.WriteLine("source: " + ShowJsonList.Items[i].ToString() +
            //                    "   searchTatget: " + searchTarget + "  " +
            //                    "FindNumber: " + isFind);
            //}

            #endregion search current Listbox

            //清空列表 重新添加
            RichContent.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var SearDictionaryKey in searDic.Keys)
            {
                ShowJsonList.Sorted = true;
                ShowJsonList.Items.Add(SearDictionaryKey);
            }
        }

        private void ShowAllJson()
        {
            RichContent.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var jsonDicValue in jsonDic.Keys)
            {
                ShowJsonList.Items.Add(jsonDicValue);
            }
        }

        private void RichContent_TextChanged(object sender, EventArgs e)
        {
            if (!RichContent.Focused)
            {
                return;
            }
            AutoSave();
            //设置自适应宽高
            AutoCellSize(mainWorksheet);
        }

        private void AutoSave()
        {
            if (CheckValidity())
            {
                return;
            }

            string tempJsonName;
            if (autoSave)
            {
                //自动保存
                tempJsonName = ShowJsonList.SelectedItem.ToString(); //获取选择的json文件
                //将修改的内容写进Json文件中。
                File.WriteAllText(jsonDic[tempJsonName].FullName, RichContent.Text);
                //File.WriteAllText(cacheDic[tempJsonName].FullName,RichContent.Text);
                //return;
            }

            tempJsonName = ShowJsonList.SelectedItem.ToString();
            //将富文本修改的内容存到缓存里，点击保存才存到Json中
            CacheJsonFile(tempJsonName, RichContent.Text);
        }

        private void SerializeJson_Click(object sender, EventArgs e)
        {
            new SerializeJsonForm().Show(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void MainReoGrid_Click(object sender, EventArgs e)
        {
        }

        private void AutoForm_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            autoForm = (sender as ToolStripMenuItem).Checked;
        }

        private void AutoCellSize_MenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            autoCellSize = (sender as ToolStripMenuItem).Checked;
        }
    }
}
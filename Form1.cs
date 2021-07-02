using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace JsonShow
{
    public partial class JsonEditors : Form
    {  //文件名name无后缀，文件对象Fileinfo
        private bool autoSave = false;
        private Dictionary<string, FileInfo> cacheDic = new Dictionary<string, FileInfo>();
        private string cachePath = Application.StartupPath + @"\Cache\";
        private Dictionary<string, FileInfo> jsonDic = new Dictionary<string, FileInfo>();
        private Dictionary<string, FileInfo> searDictionary = new Dictionary<string, FileInfo>();

        //当前启动目录为缓存文件目录
        //Dictionary<string jsonName, FileInfo jsonFile> jsonDic=new
        public JsonEditors()
        {
            InitializeComponent();
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
        }

        private bool CheckValidity()
        {
            if (!ShowContent.Focused)
            {
                return true;
            }

            if (string.IsNullOrEmpty(ShowContent.Text))
            {
                return true;
            }
            if (ShowJsonList.SelectedItem == null)
            {
                return true;
            }

            return false;
        }

        private void ClearCache(object sender, EventArgs e)
        {
            DirectoryInfo tempDirectoryInfo = new DirectoryInfo(cachePath);
            FileInfo[] cacheJson = tempDirectoryInfo.GetFiles();
            foreach (var fileInfo in cacheJson)
            {
                fileInfo.Delete();
            }
            cacheDic.Clear();
        }

        private void ClearJsonLists(object sender, EventArgs e)
        {
            ShowContent.Text = "";
            ShowJsonList.Items.Clear();
            jsonDic.Clear();
            cacheDic.Clear();
        }

        private void JsonEditorLoad(object sender, EventArgs e)
        {
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

            ShowContent.Text = File.ReadAllText(tempJsonFile.FullName);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void OpenCacheFolder(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + cachePath;
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        /// Handles the Click event of the 打开文件ToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Multiselect = true;
            fileDialog.CheckFileExists = true;
            fileDialog.InitialDirectory = Application.StartupPath;
            fileDialog.Filter = "Josn文件|*.json|全部|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileDialogFileName in fileDialog.FileNames)
                {
                    string tempJsonName = Path.GetFileNameWithoutExtension(fileDialogFileName);
                    FileInfo tempJsonfile = new FileInfo(fileDialogFileName);
                    if (jsonDic.ContainsKey(tempJsonName) == false)
                    {
                        jsonDic.Add(tempJsonName, tempJsonfile);

                        ShowJsonList.Items.Add(tempJsonName);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the 打开Json文件夹ToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpenJsonFolde(object sender, EventArgs e)
        {
            CommonOpenFileDialog open = new CommonOpenFileDialog();
            open.IsFolderPicker = true;
            if (open.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = open.FileName;
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
        }

        private void SaveAllJsonFiile(object sender, EventArgs e)
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

        private void SaveCurJson(object sender, EventArgs e)
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
                File.WriteAllText(tempJsonFile.FullName, ShowContent.Text);
                EditorState.Text = "未修改";
            }
            catch (Exception exception)
            {
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            searDictionary.Clear();
            ShowJsonList.ClearSelected();
            string searchTarget = SearchText.Text;
            if (String.IsNullOrEmpty(searchTarget))
            {
                ShowAllJson();
                return;
            }
            // 模糊搜索 从当前列表搜索
            for (int i = 0; i < ShowJsonList.Items.Count; i++)
            {
                var isFind = ShowJsonList.Items[i].ToString().IndexOf(searchTarget, StringComparison.CurrentCultureIgnoreCase);
                if (isFind >= 0)
                {
                    string itemName = ShowJsonList.Items[i].ToString();
                    ShowJsonList.SetSelected(i, true);
                    if (!searDictionary.ContainsKey(itemName))
                    {
                        searDictionary.Add(itemName, jsonDic[itemName]);
                    }
                }
                Debug.WriteLine("source: " + ShowJsonList.Items[i].ToString() +
                                "   searchTatget: " + searchTarget + "  " +
                                "FindNumber: " + isFind);
            }

            //清空列表 重新添加
            ShowContent.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var SearDictionaryKey in searDictionary.Keys)
            {
                ShowJsonList.Sorted = true;
                ShowJsonList.Items.Add(SearDictionaryKey);
            }
        }

        private void RefreshListBox()
        {
            //清空列表 重新添加
            ShowContent.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var jsonDicKey in jsonDic.Keys)
            {
                ShowJsonList.Sorted = true;
                ShowJsonList.Items.Add(jsonDicKey);
            }
        }

        private void ShowAllJson()
        {
            ShowContent.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var jsonDicValue in jsonDic.Keys)
            {
                ShowJsonList.Items.Add(jsonDicValue);
            }
        }

        private void ShowContent_TextChanged(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                return;
            }
            string tempJsonName;
            if (autoSave)
            {
                //自动保存
                tempJsonName = ShowJsonList.SelectedItem.ToString();//获取选择的json文件
                //将修改的内容写进Json文件中。
                File.WriteAllText(jsonDic[tempJsonName].FullName, ShowContent.Text);
                return;
            }

            tempJsonName = ShowJsonList.SelectedItem.ToString();
            //将富文本修改的内容存到缓存里，点击保存才存到Json中
            CacheJsonFile(tempJsonName, ShowContent.Text);
        }

        private void AutoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            autoSave = (sender as ToolStripMenuItem).Checked;
        }

        private void ReNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = ShowJsonList.SelectedItem.ToString();
        }

        private void OpenJsonFileInExplore_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            string tempJsonPath = jsonDic[ShowJsonList.SelectedItem.ToString()].FullName;
            psi.Arguments = "/e,/select," + tempJsonPath;
            System.Diagnostics.Process.Start(psi);
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
    }
}
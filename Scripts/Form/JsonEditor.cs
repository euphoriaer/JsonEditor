using JsonShow.Scripts.Tools;
using LiteDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using unvell.ReoGrid;
using JsonSerializer = LiteDB.JsonSerializer;

namespace JsonShow
{
    public partial class JsonEditor : Form
    {
        public Dictionary<string, FileInfo> jsonDic = new Dictionary<string, FileInfo>();

        public string[] skipKey = new[] { "_id", "Path" };

        private bool autoCellSize = false;

        private bool autoForm = true;

        private bool autoSave = true;

        //Key:文件名name无后缀，Value:文件对象Fileinfo
        private Dictionary<string, FileInfo> cacheDic = new Dictionary<string, FileInfo>();

        private string cachePath = Application.StartupPath + @"\Cache\";
        private string dbName = "json.db";
        private Worksheet mainWorksheet;
        private string porjectName = "Default.project";
        private bool richOpen = false;
        private RichTextBox richTextBox;
        private Dictionary<string, FileInfo> searDic = new Dictionary<string, FileInfo>();

        public JsonEditor()
        {
            InitializeComponent();
            DefaultOnceLoad();
            this.FormClosing += CloseForm;
            ShowJsonList.MouseClick += (e, se) =>
            {
                //todo  C# listbox 单击空白区检测

                //if (ShowJsonList.SelectedItems.Count <= 0) //这这判断是否点了空白区，点了空白区进到if里
                //    MessageBox.Show("选种items");

                var index = ShowJsonList.IndexFromPoint(se.X, se.Y);
                ShowJsonList.SelectedIndex = index;
                if (index == -1)
                {
                    Debug.WriteLine("C# listbox 单击空白区检测:  " + index);
                }
                else
                {
                    richTextBox.ReadOnly = false;
                }
            };
            richTextBox = JsonEditorRich;
            //设置文本风格
            SetFont();
            AutoFormHook.Checked = true;
            AutoSaveHook.Checked = true;
            mainWorksheet = MainReoGrid.CurrentWorksheet;
        }

        private void ExpertJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todo 导出时，递归查找所有相关表，按父子关系全部导出，使用无实体导出
            bool isOk;
            string savePath = DialogTools.SaveFile(out isOk);
            if (!isOk)
            {
                return;
            }
            string prefix = SortList.SelectedItem.ToString();
            var jsonNames = ShowJsonList.Items;
            stringList stringList = new stringList();
            foreach (var jsonName in jsonNames)
            {
                FileInfo jsonFileInfo = jsonDic[jsonName as string];
                string json = File.ReadAllText(jsonFileInfo.FullName);
                object jObject = JsonTools.DeSerializeToObject(json);
                stringList.content.Add(jObject);
            }

            string expertJson = JsonTools.SerializeToString(stringList);
            Debug.WriteLine("expertJson:  " + expertJson);

            File.WriteAllText(savePath, expertJson);
        }

        private void SortList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SortList.SelectedItem == null)
            {
                return;
            }
            string searchPrefix = SortList.SelectedItem.ToString();

            searDic.Clear();
            ShowJsonList.ClearSelected();
            if (String.IsNullOrEmpty(searchPrefix))
            {
                ShowAllJson();
                return;
            }

            string[] itemNames = SearchAllByPrefix(searchPrefix);
            foreach (var itemName in itemNames)
            {
                if (!searDic.ContainsKey(itemName))
                {
                    searDic.Add(itemName, jsonDic[itemName]);
                }
            }

            //清空列表 重新添加
            richTextBox.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var SearDictionaryKey in searDic.Keys)
            {
                ShowJsonList.Sorted = true;
                ShowJsonList.Items.Add(SearDictionaryKey);
            }
        }

        #region EditorItem

        private void AutoCellSize_MenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            autoCellSize = (sender as ToolStripMenuItem).Checked;
        }

        private void AutoForm_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            autoForm = (sender as ToolStripMenuItem).Checked;
        }

        private void AutoSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            autoSave = (sender as ToolStripMenuItem).Checked;
        }

        private void CellLookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CellPosition cellPosition = MainReoGrid.CurrentWorksheet.FocusPos;
            Cell cell = MainReoGrid.CurrentWorksheet.Cells[cellPosition];
            string cellContent = GetCellContent(cell);
            if (string.IsNullOrEmpty(cellContent))
            {
                return;
            }
            string cellColumnName = GetColumnName(cell);
            string cellJson = GetCurrentCellJson(cellColumnName, cellContent);
            if (string.IsNullOrEmpty(cellJson) || cellJson == "null")
            {
                return;
            }
            string sheetName = MainReoGrid.CurrentWorksheet.Cells[0, cell.Column].DisplayText;
            var sheet = CreatSheetWork(sheetName);

            JsonTools.DeSerializeToForm(cellJson, sheet, skipKey);
            //设置文本风格
            SetFont(sheet);
            //设置自适应宽高
            AutoCellSize(sheet);
            //添加单元格修改事件
            SheetChangedEventNewForm(sheet);

            //立即修改Rich,
            if (richTextBox != null)
            {
                string tempFormat = JsonTools.Format(cellJson);
                richTextBox.Text = tempFormat;
            }

            richTextBox.ReadOnly = true;
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
            richTextBox.Text = "";
            ShowJsonList.Items.Clear();
            jsonDic.Clear();
            cacheDic.Clear();
            SortList.Items.Clear();
        }

        private Worksheet CreatSheetWork(string sheetName)
        {
            var tempWork = MainReoGrid.Worksheets.Where(p => p.Name == sheetName);
            if (tempWork.Count() == 0)
            {
                var newSheet = MainReoGrid.CreateWorksheet(sheetName);
                SetFont(newSheet);
                MainReoGrid.AddWorksheet(newSheet);
                MainReoGrid.CurrentWorksheet = newSheet;
            }
            else
            {
                MainReoGrid.CurrentWorksheet = tempWork.First();
            }
            return tempWork.First();
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

        private void JsonContentEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richOpen)
            {
                return;
            }
            Debug.WriteLine("OpenRich");
            var rich = new Rich();
            rich.Show();
            rich.Content.TextChanged += richTextBox_TextChanged;
            rich.Shown += (m, n) =>
            {
                richOpen = true;
            };
            rich.Closed += (obj, ev) =>
            {
                richOpen = false;
                return;
            };
            richTextBox = rich.Content;
        }

        private void JsonCreateEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SerializeJsonForm(this).Show(this);
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
            if (tempListBox.SelectedItem == null)
            {
                return;
            }

            //如果缓存里有，就展示缓存内容
            if (cacheDic.ContainsKey(tempListBox.SelectedItem.ToString()))
            {
                tempJsonFile = cacheDic[tempListBox.SelectedItem.ToString()];
            }
            else
            {
                tempJsonFile = jsonDic[tempListBox.SelectedItem.ToString()];
            }

            var listSheet = CreatSheetMemory(tempListBox.SelectedItem.ToString());
            string json = File.ReadAllText(tempJsonFile.FullName);
            listSheet = JsonTools.DeSerializeToForm(json, listSheet, tempListBox.SelectedItem.ToString());
            //设置文本风格
            SetFont();
            //设置自适应宽高
            AutoCellSize(listSheet);
            //添加单元格的数据同步
            SheetChangedEventListBox(listSheet);

            //立即修改Rich
            if (richTextBox != null)
            {
                richTextBox.Text = File.ReadAllText(tempJsonFile.FullName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 解析Json字符串
        /// </summary>
        /// <param name="jsonStr">需要解析的Json字符串</param>
        /// <returns>返回解析好的Hashtable表</returns>
        private void MainReoGrid_Click(object sender, EventArgs e)
        {
        }

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
            bool isOK;
            string path = DialogTools.OpenFolder(out isOK);
            if (isOK == false)
            {
                return;
            }
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

        private void OpenProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool isOk = false;
            string[] projectfiles= DialogTools.OpenFiles(out isOk, "project文件|*.project|全部|*.*");
            if (!isOk)
            {
                return;
            }
            ClearJsonLists_ItemClicked(sender,e);
            string json = File.ReadAllText(projectfiles[0]);
            Project projectObj = JsonConvert.DeserializeObject<Project>(json);
            foreach (var entity in projectObj.showJsonList)
            {
               
                jsonDic.Add(entity.Key, entity.Value);
            }

            foreach (var item in projectObj.sortList)
            {
                SortList.Items.Add(item);
            }
            Debug.WriteLine("载入数据完成");

            //直接读取列表与缓存（避免每次都要全选json文件），目前关闭后缓存不会被再读取（相当于删除），防止数据混乱
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!richTextBox.Focused)
            {
                return;
            }
            if (CheckValidity())
            {
                return;
            }

            string tempJsonName;
            tempJsonName = ShowJsonList.SelectedItem.ToString();
            //将富文本修改的内容存到缓存里，点击保存才存到Json中
            Cache(tempJsonName, richTextBox.Text);
            //将富文本内容放到 form中
            RefreshForm(richTextBox.Text);
            AutoCellSize(mainWorksheet);
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

                File.WriteAllText(tempJsonFile.FullName, richTextBox.Text);
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

            string[] itemNames = SearchAllList(searchTarget);
            foreach (var itemName in itemNames)
            {
                if (!searDic.ContainsKey(itemName))
                {
                    searDic.Add(itemName, jsonDic[itemName]);
                }
            }

            //清空列表 重新添加
            richTextBox.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var SearDictionaryKey in searDic.Keys)
            {
                ShowJsonList.Sorted = true;
                ShowJsonList.Items.Add(SearDictionaryKey);
            }
        }

        private void SerializeJson_Click(object sender, EventArgs e)
        {
        }

        #endregion EditorItem

        #region Function

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

        private void AutoSaveCache()
        {
            if (!autoSave)
            {
                return;
            }
            foreach (var cacheEntity in cacheDic)
            {
                string cacheJson = File.ReadAllText(cacheEntity.Value.FullName);
                string jsonPath = jsonDic[cacheEntity.Key].FullName;
                File.WriteAllText(jsonPath, cacheJson);
            }
        }

        private void Cache(string cacheName, string cacheContent)
        {
            DirectoryInfo cacheDir = Directory.CreateDirectory(cachePath);
            string tempCacheJsonPath = cacheDir.FullName + cacheName;
            File.WriteAllText(tempCacheJsonPath, cacheContent);
            if (!cacheDic.ContainsKey(cacheName)) //不存在就加入到缓存列表
            {
                FileInfo cacheFile = new FileInfo(tempCacheJsonPath);
                cacheDic.Add(cacheName, cacheFile);
            }

            AutoSaveCache();
        }

        private bool CheckValidity()
        {
            if (string.IsNullOrEmpty(richTextBox.Text))
            {
                return true;
            }

            if (ShowJsonList.SelectedItem == null)
            {
                return true;
            }

            return false;
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("关闭窗体,保存项目");
            Project project = new Project();
            project.showJsonList = jsonDic;
            foreach (var item in SortList.Items)
            {
                project.sortList.Add(item as string);
            }

            project.SaveProject(porjectName);
            Debug.WriteLine("保存项目完成");
        }

        private Worksheet CreatSheetMemory(string sheetName)
        {
            var tempWork = MainReoGrid.Worksheets.Where(p => p.Name == sheetName);
            if (tempWork.Count() == 0)
            {
                var newSheet = MainReoGrid.CreateWorksheet(sheetName);
                SetFont(newSheet);
                MainReoGrid.CurrentWorksheet = newSheet;
            }
            else
            {
                MainReoGrid.CurrentWorksheet = tempWork.First();
            }
            return MainReoGrid.CurrentWorksheet;
        }

        private string GetCellContent(Cell cell)
        {
            string id = cell.DisplayText;
            Debug.WriteLine("获取选择的单元格内容(id)：" + id);
            return id;
        }

        private string GetColumnName(Cell cell)
        {
            string[] cellCol = MainReoGrid.CurrentWorksheet.Cells[0, cell.Column].DisplayText.Split('_');
            Debug.WriteLine("获取选择的单元格列名(集合)：" + cellCol[0]);
            return cellCol[0];
        }

        private string GetCurrentCellJson(string cellColumnName, string cellContent)
        {
            //var data= LiteDBTools.SearchByID(id, cellCol[0], dbName);
            //todo Name能否修改，指定为集合第二列为Key（存的时候使用的集合第二列）
            string cmd = string.Format("$.Name = '{0}'", cellContent);
            BsonDocument data = LiteDBTools.SearchFirst(cmd, cellColumnName, dbName);

            string json = LiteDB.JsonSerializer.Serialize(data);
            //todo 格式化字符串
            //string json2 = JsonTools.SerializeToString(json);
            //Debug.WriteLine("读取的数据库文件："+json2);
            return json;
        }

        private void DefaultOnceLoad()
        {
            Debug.WriteLine("打开窗体，载入数据");
            Project project = new Project();
            if (!File.Exists(project.defaultSavePath + porjectName))
            {
                return;
            }
            string json = project.OpenProject(porjectName);
            if (string.IsNullOrEmpty(json))
            {
                return;
            }
            Project projectObj = JsonConvert.DeserializeObject<Project>(json);
            foreach (var entity in projectObj.showJsonList)
            {
                jsonDic.Add(entity.Key, entity.Value);
            }

            foreach (var item in projectObj.sortList)
            {
                SortList.Items.Add(item);
            }
            Debug.WriteLine("载入数据完成");
        }

        private void RefreshForm(string cacheContent)
        {
            try
            {
                //加到缓存后，表格重新读取 todo ? 为什么要重读表格 因为RichText修改，所以要重读
                var listSheet = CreatSheetMemory(ShowJsonList.SelectedItem.ToString());
                mainWorksheet = JsonTools.DeSerializeToForm(cacheContent, MainReoGrid.CurrentWorksheet,
                    ShowJsonList.SelectedItem.ToString());

                //设置文本风格
                SetFont();
                //设置自适应宽高
                AutoCellSize(mainWorksheet);

                ////添加数据库同步
                //SheetChangedEventNewForm(mainWorksheet);
            }
            catch (Exception e)
            {
                MessageBox.Show("Json文件结构被破坏,表格无法显示");
                Console.WriteLine(e);
            }
        }

        private void RefreshListBox()
        {
            //清空列表 重新添加
            richTextBox.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var jsonDicKey in jsonDic.Keys)
            {
                ShowJsonList.Sorted = true;
                ShowJsonList.Items.Add(jsonDicKey);
            }
        }

        private string[] SearchAllByPrefix(string searchPrefix)
        {
            //从所有Json文件搜索 特定前缀
            List<string> searchList = new List<string>();
            foreach (var jsonDicKey in jsonDic.Keys)
            {
                string prefix = jsonDicKey.Split('_')[0];
                if (prefix == searchPrefix)
                {
                    searchList.Add(jsonDicKey);
                }
            }
            return searchList.ToArray();
        }

        private string[] SearchAllList(string searchTarget)
        {
            //从所有Json文件搜索
            List<string> searchList = new List<string>();
            foreach (var jsonDicKey in jsonDic.Keys)
            {
                var isFind = jsonDicKey.IndexOf(searchTarget, StringComparison.CurrentCultureIgnoreCase);

                if (isFind >= 0)
                {
                    searchList.Add(jsonDicKey);
                }
            }
            return searchList.ToArray();
        }

        private string[] SearchCurrentList(string searchTarget)
        {
            // 模糊搜索 从当前列表搜索
            List<string> searchList = new List<string>();
            for (int i = 0; i < ShowJsonList.Items.Count; i++)
            {
                var isFind = ShowJsonList.Items[i].ToString().IndexOf(searchTarget, StringComparison.CurrentCultureIgnoreCase);
                if (isFind >= 0)
                {
                    searchList.Add(ShowJsonList.Items[i].ToString());
                }
                Debug.WriteLine("source: " + ShowJsonList.Items[i].ToString() +
                                "   searchTatget: " + searchTarget + "  " +
                                "FindNumber: " + isFind);
            }

            return searchList.ToArray();
        }

        /// <summary>
        /// Sets the CurrentWorksheet font.
        /// </summary>
        private void SetFont()
        {
            MainReoGrid.CurrentWorksheet.SetRangeStyles("A1:Z100", new WorksheetRangeStyle
            {
                Flag = PlainStyleFlag.HorizontalAlign,
                HAlign = ReoGridHorAlign.Center,
            });
        }

        private void SetFont(Worksheet sheet)
        {
            sheet.SetRangeStyles("A1:Z100", new WorksheetRangeStyle
            {
                Flag = PlainStyleFlag.HorizontalAlign,
                HAlign = ReoGridHorAlign.Center,
            });
        }

        private void SheetChangedEventListBox(Worksheet destinationWorksheet)
        {//点击listbox 从而生成的sheet 单元格，修改事件
            destinationWorksheet.CellDataChanged += ((send, args) =>
            {
                //string selectName = ShowJsonList.SelectedItem.ToString();
                string json = JsonTools.SerializeToString(MainReoGrid.CurrentWorksheet);
                Debug.WriteLine("RichBoxJson：" + json);
                richTextBox.Text = json;
                //写入缓存
                Cache(ShowJsonList.SelectedItem.ToString(), json);
                Debug.WriteLine("当前选择的SheetName：" + MainReoGrid.CurrentWorksheet.Name);
                string collectName = MainReoGrid.CurrentWorksheet.Name.Split('_')[0];
                Debug.WriteLine("集合名：" + collectName);
                string name = MainReoGrid.CurrentWorksheet[1, 0].ToString();
                UpDateDB(name, collectName, destinationWorksheet);
            });
        }

        private void SheetChangedEventNewForm(Worksheet destinationWorksheet)
        {   //右键查看详情 从而生成的sheet 单元格，修改事件
            destinationWorksheet.CellDataChanged += ((send, args) =>
            {
                string afterAllJson = JsonTools.SerializeToString(MainReoGrid.CurrentWorksheet);
                Debug.WriteLine("afterJson：" + afterAllJson);
                richTextBox.Text = afterAllJson;

                // 获取修改目标的Bson 第二行第一列为 Name
                string name = MainReoGrid.CurrentWorksheet[1, 0].ToString();

                //根据当前的sheetName 获取集合名
                string collect = MainReoGrid.CurrentWorksheet.Name.Split('_')[0];
                //更新数据库
                BsonDocument newBson = null;
                try
                {
                    //Error 超出索引？
                    newBson = UpDateDB(name, collect, destinationWorksheet);
                }
                catch (Exception e)
                {
                    return;
                }

                //数据库内容写入缓存
                string afterJson = JsonSerializer.Serialize(newBson);
                var afterDic = JsonTools.DeSerializeToDictionary(afterJson);
                string afterJsonPath = afterDic["Path"];
                string cacheJson = JsonTools.SerializeToString(afterDic, skipKey);
                string cacheName = Path.GetFileNameWithoutExtension(afterJsonPath);

                //CacheJsonFile(cacheName, cacheJson);
                Cache(cacheName, cacheJson);
                string fjson = JsonTools.Format(afterJson);
                Debug.WriteLine("写入缓存：" + cacheJson);

                //如果勾选了自动保存，则同时写入文件，bson.Last()
                //todo 可能出现有缓存，但是列表没有对应文件（数据库中），所以通过数据库索引到文件目录,而不用AutoSave
                if (autoSave)
                {
                    File.WriteAllText(afterJsonPath, cacheJson);
                }
            });
        }

        private void ShowAllJson()
        {
            richTextBox.Text = "";
            ShowJsonList.Items.Clear();
            foreach (var jsonDicValue in jsonDic.Keys)
            {
                ShowJsonList.Items.Add(jsonDicValue);
            }
        }

        private BsonDocument UpDateDB(string name, string collectName, Worksheet sheet)
        {
            string cmd = string.Format("$.Name = '{0}'", name);

            //找到Bson数据，赋值新的
            BsonDocument beforeBson = LiteDBTools.SearchFirst(cmd, collectName, dbName);
            BsonDocument newBson = new BsonDocument();
            var pos = sheet.FocusPos;
            var cell = sheet[pos];
            CellPosition cellPos = new CellPosition(pos.Row - 1, pos.Col);

            string key = MainReoGrid.CurrentWorksheet[cellPos].ToString();

            foreach (var bsonEntity in beforeBson)
            {
                if (bsonEntity.Key == key)
                {
                    newBson.Add(bsonEntity.Key, cell.ToString());
                }
                else
                {
                    newBson.Add(bsonEntity);
                }
            }

            //更新数据库
            LiteDBTools.Update(newBson, collectName, dbName);
            Debug.WriteLine("数据库 更新完成: ");

            return newBson;
        }

        #endregion Function
    }

    public class stringList
    {
        public List<object> content = new List<object>();
    }
}
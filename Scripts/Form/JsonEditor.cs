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
    public struct FilePath
    {
        private string path;

        public string Path { get => path; set => path = value; }
    }

    public struct TreePath
    {
        private string path;

        public string Path { get => path; set => path = value; }
    }

    public partial class JsonEditor : Form
    {
        #region Attribute

        public Dictionary<string, FileInfo> jsonDic = new Dictionary<string, FileInfo>();

        public string[] skipKey = new[] { "_id", "Path" };
        private bool autoCellSize = false;
        private bool autoForm = true;
        private bool AutoMainEditor = true;
        private bool autoSave = true;
        private string cachePath = Application.StartupPath + @"\Cache\";
        private string dbAssemble = "Game";
        private string dbKey = "TreePath";
        private string dbName = "json.db";
        private string dbProject = Application.StartupPath + @"\Project\";
        private Worksheet mainWorksheet;
        private string porjectName = "Default.project";
        private bool richOpen = false;
        private TreeNode root;

        //Key:文件名name无后缀，Value:文件对象Fileinfo
        private Dictionary<string, FileInfo> searDic = new Dictionary<string, FileInfo>();

        #endregion Attribute

        #region EditorItem

        private List<TreeNode> nodeList = new List<TreeNode>();

        public JsonEditor()
        {
            InitializeComponent();
            DefaultOnceLoad();

            TreeViewInit();
            this.FormClosing += CloseForm;
            AutoAddEditorToolStripMenuItem.Checked = true;
            //设置文本风格
            SetFont();
            mainWorksheet = MainReoGrid.CurrentWorksheet;
        }

        private void AutoAddEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            AutoMainEditor = (sender as ToolStripMenuItem).Checked;
        }

        private void AutoCellSize_MenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            autoCellSize = (sender as ToolStripMenuItem).Checked;
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
        }

        private void ChangeColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var column = new Dialog();
            var isOK = column.ShowDialog();
            if (isOK == DialogResult.OK)
            {
                MainReoGrid.CurrentWorksheet.ColumnCount = int.Parse(column.content);
            }
        }

        private void ChangeRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowNumber = new Dialog();
            var isOK = rowNumber.ShowDialog();
            if (isOK == DialogResult.OK)
            {
                MainReoGrid.CurrentWorksheet.RowCount = int.Parse(rowNumber.content);
            }
        }

        private void ClearJsonLists_ItemClicked(object sender, EventArgs e)
        {
            jsonDic.Clear();
        }

        /// <summary>
        /// 根据路径创建节点，路径不存在则创建
        /// </summary>
        /// <param name="fullpath">The fullpath</param>
        private void CreateChildNodeByPath(TreeNode parent, string fullpath)
        {
            if (string.IsNullOrEmpty(fullpath) || fullpath == "_")
            {
                return;//递归结束
            }

            string[] names = fullpath.Split('_');

            //查找当前层级是否存在同名节点
            TreeNode currentNode = null;
            foreach (TreeNode parentNode in parent.Nodes)
            {
                if (parentNode.Text == names[0])
                {
                    currentNode = parentNode;
                }
            }
            if (currentNode != null)
            {
                //存在,修改字符串,进入下一级
                int startName = 1;
                string newFullPath = "";
                for (int i = startName; i < names.Length; i++)
                {
                    newFullPath += names[i] + @"_";
                }

                CreateChildNodeByPath(currentNode, newFullPath);
            }
            else
            {
                //不存在，创建，
                TreeNode newNode = new TreeNode();
                newNode.Text = names[0];
                parent.Nodes.Add(newNode);
                //修改字符串，进入下一级
                int startName = 1;
                string newFullPath = "";
                for (int i = startName; i < names.Length; i++)
                {
                    newFullPath += names[i] + @"_";
                }
                CreateChildNodeByPath(newNode, newFullPath);
            }
        }

        private void CreatJsonByRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // todo 根据SerializeTostring 重构
            var worksheets = MainReoGrid.Worksheets;
            bool OnceDB = true;
            bool isOK = false;
            string path = DialogTools.ChooseFolder(out isOK);

            // string pathAndName = DialogTools.SaveFile(out isOK);
            if (!isOK)
            {
                return;
            }
            string jsonDirs = path;

            foreach (var worksheet in worksheets)
            {
                //获取第一列，作为文件名
                int column = 0;
                List<string> jsonPaths = new List<string>();

                string collectName = null;
                for (int row = 1; row < worksheet.RowCount; row++)
                {
                    if (worksheet[row, column] == null)
                    {
                        break;
                    }
                    string fileName = worksheet[row, column].ToString();
                    string jsonPath = jsonDirs + @"\" + fileName + ".json";
                    jsonPaths.Add(jsonPath);
                    if (AutoMainEditor && !jsonDic.ContainsKey(fileName))
                    {
                        FileInfo json = new FileInfo(jsonPath);
                        jsonDic.Add(fileName, json);
                    }
                    //设置集合名
                    collectName = fileName.Split('_')[0];
                }

                //序列化为文件  不带_ID与FilePath
                FileInfo[] jsons = JsonTools.SerializeToFile(worksheet, jsonPaths.ToArray());

                //添加到数据库
                string dbName = "json.db";
                foreach (string jsonPath in jsonPaths)
                {
                    if (OnceDB == true)//是第一次就创建，不是就插入
                    {
                        //第一次要确定索引
                        CreatDbByJsson(jsonPath, dbName, collectName);
                        OnceDB = false;
                    }
                    else
                    {
                        InsertDB(jsonPath, dbName, collectName);
                    }
                }
            }
            //TreeViewInit();
            DialogTools.OpenExplorer(jsonDirs);
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

        private void ExpertJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todo 导出时，递归查找所有相关表，按父子关系全部导出，使用无实体导出
            //bool isOk;
            //string savePath = DialogTools.SaveFile(out isOk);
            //if (!isOk)
            //{
            //    return;
            //}
            //string prefix = SortList.SelectedItem.ToString();
            //var jsonNames = ShowJsonList.Items;
            //stringList stringList = new stringList();
            //foreach (var jsonName in jsonNames)
            //{
            //    FileInfo jsonFileInfo = jsonDic[jsonName as string];
            //    string json = File.ReadAllText(jsonFileInfo.FullName);
            //    object jObject = JsonTools.DeSerializeToObject(json);
            //    stringList.content.Add(jObject);
            //}

            //string expertJson = JsonTools.SerializeToString(stringList);
            //Debug.WriteLine("expertJson:  " + expertJson);

            //File.WriteAllText(savePath, expertJson);
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the 打开文件ToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>

        private void OpenProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOk = false;
            string[] projectfiles = DialogTools.OpenFiles(out isOk, "project文件|*.project|全部|*.*");
            if (!isOk)
            {
                return;
            }
            ClearJsonLists_ItemClicked(sender, e);
            string json = File.ReadAllText(projectfiles[0]);
            Project projectObj = JsonConvert.DeserializeObject<Project>(json);
            foreach (var entity in projectObj.showNodes)
            {
                jsonDic.Add(entity.Key, entity.Value);
            }

            Debug.WriteLine("载入数据完成");
            //todo  所有数据初始化提取出来，form加载与打开项目时使用
            //TreeViewInit();

            //直接读取列表与缓存（避免每次都要全选json文件），目前关闭后缓存不会被再读取（相当于删除），防止数据混乱
        }

        private void ReNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeView.SelectedNode.BeginEdit();
        }

        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorksheetCollection sheets = MainReoGrid.Worksheets;
            List<string> nodesPaths = new List<string>();
            string dbGamePath = dbProject;
            bool isOk = false;//todo 另存为项目
            //string dbGamePath = DialogTools.ChooseFolder(out isOk);
            //if (!isOk)
            //{
            //    return;
            //}

            foreach (var sheet in sheets)
            {
                if (sheet.Name == "Sheet1")
                {
                    continue;
                }
                string json = JsonTools.SerializeToString(sheet, row: 1);
                //todo 把json按treepath 存起来
                string treePath = sheet.Name.Replace('_', '/');

                string jsonPath = dbGamePath + treePath;
                //加入jconDic
                FileInfo jsonFileInfo = new FileInfo(jsonPath);
                jsonDic.Add(sheet.Name, jsonFileInfo);
                //加入liteDb
                BsonDocument bson = new BsonDocument();
                BsonValue bsonValue = JsonSerializer.Deserialize(json);
                bson.Add(sheet.Name, bsonValue);
                bson.Add(dbKey, sheet.Name);
                nodesPaths.Add(sheet.Name);
                LiteDBTools.Insert(bson, dbAssemble, dbName, id: dbKey);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            searDic.Clear();
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
        }

        private void SerializeExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOpen = false;
                string[] paths = DialogTools.OpenFiles(out isOpen, "Excel文件|*.xlsx|全部|*.*");
                if (isOpen == false)
                {
                    return;
                }
                MainReoGrid.Load(paths[0]);
            }
            catch (Exception exception)
            {
                MessageBox.Show("请关掉使用的Excel");
            }
        }

        private void SerializeJson_Click(object sender, EventArgs e)
        {
        }

        private void SerializeJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            string[] tempPaths = DialogTools.OpenFiles(out isOpen, "Josn文件|*.json|全部|*.*");
            if (isOpen == false)
            {
                return;
            }
            string content = File.ReadAllText(tempPaths[0]);
            var tempHt = JsonTools.DeSerializeToDictionary(content);
            MainReoGrid.CurrentWorksheet = MainReoGrid.CreateWorksheet();
            mainWorksheet = MainReoGrid.CurrentWorksheet;
            int tempColumn = 0;
            foreach (var dictionaryEntry in tempHt)
            {
                var rowOne = new CellPosition(0, tempColumn);//第一行
                var rowTwo = new CellPosition(1, tempColumn);//第二行
                mainWorksheet[rowOne] = dictionaryEntry.Key as string;
                string m = dictionaryEntry.Value;
                mainWorksheet[rowTwo] = m;
                tempColumn++;
            }
        }

        private void TreeNodecontextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void TreeNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("select node " + TreeView.SelectedNode);
            TreeNode node = new TreeNode();
            node.Text = "新建节点";
            node.ContextMenuStrip = TreeNodecontextMenuStrip;
            TreeView.SelectedNode.Nodes.Add(node);
            TreeView.SelectedNode = node;
            node.BeginEdit();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Debug.WriteLine("选择了节点： " + e.Node);
            Debug.WriteLine("分配给节点的数量： " + e.Node.Nodes.Count);
            Debug.WriteLine("获取第一个子节点： " + e.Node.FirstNode);
            Debug.WriteLine("获取最后一个子节点： " + e.Node.LastNode);
            Debug.WriteLine("获取下一个同级数节点： " + e.Node.NextNode);
            Debug.WriteLine("获取下一个可见树节点： " + e.Node.NextVisibleNode);
            Debug.WriteLine("获取上一个同级树节点： " + e.Node.PrevNode);
            Debug.WriteLine("获取上一个可见树节点： " + e.Node.PrevVisibleNode);
            Debug.WriteLine("节点全路径： " + e.Node.FullPath);
            Worksheet sheet = SearchWorksheet(e.Node.FullPath);
        }

        #endregion EditorItem

        #region Function

        private static void CreatDbByJsson(string jsonPath, string dbName, string assemble)
        {
            BsonDocument bson = new BsonDocument();
            string jsonContent = File.ReadAllText(jsonPath);
            var jsonDic = JsonTools.DeSerializeToDictionary(jsonContent);

            foreach (var dicEntiy in jsonDic)
            {
                bson.Add(dicEntiy.Key, dicEntiy.Value);
            }
            //主动添加一条文件路径，方便之后数据库与实际文件的同步
            bson.Add("Path", jsonPath);
            string id = bson.Keys.ToList()[0].ToString();
            LiteDBTools.Creat(dbName, assemble, bson, id);
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

        private void Cache(string cacheName, string cacheContent)
        {
            //DirectoryInfo cacheDir = Directory.CreateDirectory(cachePath);
            //string tempCacheJsonPath = cacheDir.FullName + cacheName;
            //File.WriteAllText(tempCacheJsonPath, cacheContent);
            //if (!cacheDic.ContainsKey(cacheName)) //不存在就加入到缓存列表
            //{
            //    FileInfo cacheFile = new FileInfo(tempCacheJsonPath);
            //    cacheDic.Add(cacheName, cacheFile);
            //}

            //AutoSaveCache();
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("关闭窗体,保存项目");
            Project project = new Project();
            project.showNodes = jsonDic;

            project.SaveProject(porjectName);
            Debug.WriteLine("保存项目完成");
        }

        /// <summary>
        /// Creats the sheet memory. find or creat
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
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

        private void DefaultOnceLoad()
        {
            Debug.WriteLine("打开窗体，载入数据");
            Project project = new Project();
            if (!File.Exists(dbProject + porjectName))
            {
                return;
            }
            string json = project.OpenProject(porjectName);
            if (string.IsNullOrEmpty(json))
            {
                return;
            }
            Project projectObj = JsonConvert.DeserializeObject<Project>(json);
            foreach (var entity in projectObj.showNodes)
            {
                jsonDic.Add(entity.Key, entity.Value);
            }

            Debug.WriteLine("载入数据完成");
        }

        private void FileDragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];
                // Copy file from external application
                foreach (string srcfile in files)
                {
                    MainReoGrid.Load(srcfile);

                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("请关掉使用的Excel");
            }
        }

        private void FileDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private Worksheet FindWorksheet(string sheetName)
        {
            WorksheetCollection sheets = MainReoGrid.Worksheets;
            foreach (var sheet in sheets)
            {
                if (sheet.Name == sheetName)
                {
                    return sheet;
                }
            }

            return null;
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
            string cmd = string.Format("$.Name = '{0}'", cellContent);
            BsonDocument data = LiteDBTools.SearchFirst(cmd, cellColumnName, dbName);

            string json = LiteDB.JsonSerializer.Serialize(data);
            return json;
        }

        /// <summary>
        /// 通过fullpath 查找treeview节点 节点name属性需要赋过值
        /// </summary>
        /// <param name="nodes">TreeNodeCollection node集合</param>
        /// <param name="fullPath">要查找的节点的fullPath</param>
        /// <returns></returns>
        private TreeNode GetNode(TreeNodeCollection nodes, string fullPath)
        {
            string[] paths = fullPath.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
            TreeNode tn = null;
            if (paths.Length > 0)
            {
                string lastPath = paths[paths.Length - 1];
                var finds = nodes.Find(lastPath, true);
                if (finds.Length > 0)
                {
                    foreach (var item in finds)
                    {
                        if (item.FullPath == fullPath)
                        {
                            tn = item;
                            break;
                        }
                    }
                }
            }
            return tn;
        }

        private void InsertDB(string path, string dbName, string assemble)
        {
            BsonDocument bson = new BsonDocument();
            string jsonContent = File.ReadAllText(path);
            var jsonDic = JsonTools.DeSerializeToDictionary(jsonContent);

            foreach (var dicEntiy in jsonDic)
            {
                bson.Add(dicEntiy.Key, dicEntiy.Value);
            }
            //主动添加一个文件路径
            bson.Add("Path", path);
            //数据插入时会默认添加一个_ID
            LiteDBTools.Insert(bson, assemble, dbName);
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

        private Worksheet SearchWorksheet(string sheetName)
        {
            var tempWork = MainReoGrid.Worksheets.Where(p => p.Name == sheetName);
            if (tempWork.Count() == 0)
            {
                return null;
            }
            else
            {
                MainReoGrid.CurrentWorksheet = tempWork.First();
            }
            return tempWork.First();
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
                string json = JsonTools.SerializeToString(MainReoGrid.CurrentWorksheet, row: 1);
                Debug.WriteLine("RichBoxJson：" + json);

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
                string afterAllJson = JsonTools.SerializeToString(MainReoGrid.CurrentWorksheet, row: 1);
                Debug.WriteLine("afterJson：" + afterAllJson);

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

                if (autoSave)
                {
                    File.WriteAllText(afterJsonPath, cacheJson);
                }
            });
        }

        private void ShowAllJson()
        {
        }

        private void TreeViewInit()
        {
            TreeView.MouseDown += (o, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    TreeNode tn = TreeView.GetNodeAt(e.X, e.Y);
                    if (tn != null)
                    {
                        TreeView.SelectedNode = tn;
                    }
                }
            };
            TreeView.MouseDoubleClick += (o, e) =>
            {
                try
                {
                    string name = TreeView.SelectedNode.FullPath;
                    Worksheet sheet = CreatSheetWork(name);
                    //todo 从数据库查找数据，存在则对sheet赋值
                    string cmd = string.Format("$.{0} = '{1}'", dbKey, sheet.Name);
                    var data = LiteDBTools.SearchFirst(cmd, dbAssemble, dbName);
                    if (data == null)
                    {
                        return;
                    }

                    foreach (var dataEntity in data)
                    {
                        if (dataEntity.Key == sheet.Name)
                        {
                            string json = JsonTools.SerializebyBson(dataEntity.Value);
                            JsonTools.DeSerializeToForm(json, sheet);
                        }
                    }
                }
                catch (Exception exception)
                {
                }
            };

            root = new TreeNode();
            root.Text = "Game";
            root.Tag = "数据";
            TreeView.Nodes.Clear();
            TreeView.Nodes.Add(root);//加入根节点
            root.ContextMenuStrip = TreeNodecontextMenuStrip;

            TreeView.ExpandAll();
            //一级一级 ，根据全路径（前缀）赋值
            foreach (var jsonEntity in jsonDic)
            {
                //解析前缀，找到要创建的路径,除掉Game
                if (jsonEntity.Key == "Game")
                {
                    continue;
                }
                string fullPath = jsonEntity.Key.Split(new string[] { "Game_" }, StringSplitOptions.None)[1];
                CreateChildNodeByPath(root, fullPath);
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

        private void 生成所有节点的Josn文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 生成Json文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todo 根据当前节点的嵌套关系 生成一个Json文件

        }
    }
}
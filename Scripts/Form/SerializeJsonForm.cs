using JsonShow.Scripts.Tools;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace JsonShow
{
    public partial class SerializeJsonForm : Form
    {
        private const int defaultColumn = 20;

        private const int defaultRow = 20;

        private bool AutoMainEditor = true;

        private JsonEditor mainEditor;

        private Worksheet mainWorksheet;

        public SerializeJsonForm(JsonEditor jsonEditor)
        {
            InitializeComponent();
            AutoAddEditor.Checked = true;
            mainEditor = jsonEditor;
            mainWorksheet = CreatReoGrid.CurrentWorksheet;
            Cell cell = mainWorksheet.Cells["A1"];
            //内容居中
            CreatReoGrid.CurrentWorksheet.SetRangeStyles("A1", new WorksheetRangeStyle
            {
                Flag = PlainStyleFlag.HorizontalAlign,
                HAlign = ReoGridHorAlign.Center,
            });

            cell.IsReadOnly = true;
            cell.Data = "FileName";
            CreatReoGrid.WorksheetCreated += ((sender, args) =>
            {
                mainWorksheet = CreatReoGrid.CurrentWorksheet;
            });//

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private static void CreatDbByJsson(string jsonPath, string dbName, string[] colName)
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
            LiteDBTools.Creat(dbName, colName[0], bson, id);
        }

        private void AutoEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            AutoMainEditor = (sender as ToolStripMenuItem).Checked;
        }

        private void CreatJsons(object sender, EventArgs e)
        {
            //mainWorksheet = CreatReoGrid.CurrentWorksheet;

            var worksheets = CreatReoGrid.Worksheets;
            bool isOK = false;
            string pathAndName = DialogTools.SaveFile(out isOK);
            if (!isOK)
            {
                return;
            }
            string jsonDirs = Path.GetDirectoryName(pathAndName);

            foreach (var worksheet in worksheets)
            {
                //获取第一列，作为文件名
                int column = 0;
                List<string> jsonPaths = new List<string>();
                bool OnceDB = true;
                string[] colName = null;
                for (int row = 1; row < worksheet.RowCount; row++)
                {
                    if (worksheet[row, column] == null)
                    {
                        break;
                    }
                    string fileName = worksheet[row, column].ToString();
                    string jsonPath = jsonDirs + @"\" + fileName + ".json";
                    jsonPaths.Add(jsonPath);
                    if (AutoMainEditor && !mainEditor.jsonDic.ContainsKey(fileName))
                    {
                        //添加到主编辑器中
                        mainEditor.ShowJsonList.Items.Add(fileName);
                        FileInfo json = new FileInfo(jsonPath);
                        mainEditor.jsonDic.Add(fileName, json);
                    }
                    //设置集合名
                    colName = fileName.Split('_');
                }
                //序列化为文件  不带_ID与FilePath
                FileInfo[] jsons = JsonTools.SerializeToFile(worksheet, jsonPaths.ToArray());
                //添加到数据库
                string dbName = "json.db";
                foreach (string jsonPath in jsonPaths)
                {
                    if (OnceDB == true)//是第一次就创建，不是就插入
                    {
                        CreatDbByJsson(jsonPath, dbName, colName);
                        OnceDB = false;
                    }
                    else
                    {
                        InsertDB(jsonPath, dbName, colName);
                    }
                }
            }
            DialogTools.OpenExplorer(jsonDirs);
        }

        private void ExcelSerializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOpen = false;
                string[] paths = DialogTools.OpenFiles(out isOpen, "Excel文件|*.xlsx|全部|*.*");
                if (isOpen == false)
                {
                    return;
                }
                CreatReoGrid.Load(paths[0]);
            }
            catch (Exception exception)
            {
                MessageBox.Show("请关掉使用的Excel");
            }
        }

        private void FileDragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];

                // Copy file from external application
                foreach (string srcfile in files)
                {
                    CreatReoGrid.Load(srcfile);

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

        private void InsertDB(string path, string dbName, string[] colName)
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
            LiteDBTools.Insert(bson, colName[0], dbName);
        }

        private void JsonSerializedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            string[] tempPaths = DialogTools.OpenFiles(out isOpen, "Josn文件|*.json|全部|*.*");
            if (isOpen == false)
            {
                return;
            }
            string content = File.ReadAllText(tempPaths[0]);
            var tempHt = JsonTools.DeSerializeToDictionary(content);
            CreatReoGrid.CurrentWorksheet = CreatReoGrid.CreateWorksheet();
            mainWorksheet = CreatReoGrid.CurrentWorksheet;
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

        private void SerializeJsonForm_Load(object sender, EventArgs e)
        {
            mainWorksheet = CreatReoGrid.CurrentWorksheet;
            mainWorksheet.SetCols(defaultColumn);
            mainWorksheet.SetRows(defaultRow);
        }

        private void SetColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var column = new Dialog();
            var isOK = column.ShowDialog();
            if (isOK == DialogResult.OK)
            {
                mainWorksheet.ColumnCount = int.Parse(column.content);
            }
        }

        private void SetRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowNumber = new Dialog();
            var isOK = rowNumber.ShowDialog();
            if (isOK == DialogResult.OK)
            {
                mainWorksheet.RowCount = int.Parse(rowNumber.content);
            }
        }
    }
}
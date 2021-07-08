using System;
using System.Collections.Generic;
using System.IO;
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

        private void AutoEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            AutoMainEditor = (sender as ToolStripMenuItem).Checked;
        }

        private void ColumnAdd(object sender, EventArgs e)
        {
            mainWorksheet.ColumnCount++;
        }

        private void CreatJsons(object sender, EventArgs e)
        {
            mainWorksheet = CreatReoGrid.CurrentWorksheet;
            string pathAndName = DialogTools.SaveFile();
            string dirs = Path.GetDirectoryName(pathAndName);
            //获取第一列，作为文件名
            int column = 0;
            List<string> paths = new List<string>();
            for (int row = 1; row < mainWorksheet.RowCount; row++)
            {
                if (mainWorksheet[row, column] == null)
                {
                    break;
                }
                string name = mainWorksheet[row, column].ToString();
                string path = dirs + @"\" + name + ".json";
                paths.Add(path);
                //添加到主编辑器中
                if (AutoMainEditor)
                {
                    mainEditor.ShowJsonList.Items.Add(name);
                    FileInfo json = new FileInfo(path);
                    mainEditor.jsonDic.Add(name, json);
                }
            }
            //序列化为文件
            JsonTools.SerializeToFile(mainWorksheet, paths.ToArray());
            DialogTools.OpenExplorer(dirs);
        }

        private void DeSerializedJson_Click(object sender, EventArgs e)
        {
        }

        private void ExcelSerializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            string[] paths = DialogTools.OpenFiles(out isOpen, "Excel文件|*.xlsx|全部|*.*");
            if (isOpen == false)
            {
                return;
            }
            CreatReoGrid.Load(paths[0]);
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

        private void RowAdd(object sender, EventArgs e)
        {
            mainWorksheet.RowCount++;
        }

        private void SerializedExcel_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            string[] paths = DialogTools.OpenFiles(out isOpen, "Excel文件|*.xlsx|全部|*.*");
            if (isOpen == false)
            {
                return;
            }
            CreatReoGrid.Load(paths[0]);
        }

        private void SerializeJsonForm_Load(object sender, EventArgs e)
        {
            mainWorksheet = CreatReoGrid.CurrentWorksheet;
            mainWorksheet.SetCols(defaultColumn);
            mainWorksheet.SetRows(defaultRow);
        }

        private void SetColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var column = new DialogContent();
            var isOK = column.ShowDialog();
            if (isOK == DialogResult.OK)
            {
                mainWorksheet.ColumnCount = int.Parse(column.returnContent);
            }
        }

        private void SetRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowNumber = new DialogContent();
            var isOK = rowNumber.ShowDialog();
            if (isOK == DialogResult.OK)
            {
                mainWorksheet.RowCount = int.Parse(rowNumber.returnContent);
            }
        }
    }
}
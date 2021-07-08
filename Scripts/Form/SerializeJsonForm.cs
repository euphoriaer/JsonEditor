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
        private Worksheet mainWorksheet;

        public SerializeJsonForm()
        {
            InitializeComponent();
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

        /// <summary>
        /// 解析Json字符串
        /// </summary>
        /// <param name="jsonStr">需要解析的Json字符串</param>
        /// <returns>返回解析好的Hashtable表</returns>
        //private Dictionary<string, string> DeSerializedToDictionary(string jsonStr)
        //{
        //    Dictionary<string, string> ht = new Dictionary<string, string>();
        //    if (!string.IsNullOrEmpty(jsonStr))
        //    {
        //        JObject jo = (JObject)JsonConvert.DeserializeObject(jsonStr);
        //        foreach (var item in jo)
        //        {
        //            ht.Add(item.Key, item.Value.ToString());
        //        }
        //    }
        //    return ht;
        //}

        //private JObject SerializedToJobject(Dictionary<string, string> resDictionary)
        //{
        //    JObject target = new JObject();

        //    foreach (var DicEntity in resDictionary)
        //    {
        //        target.Add(DicEntity.Key, DicEntity.Value);
        //    }
        //    return target;
        //}

        private void RowAdd(object sender, EventArgs e)
        {
            mainWorksheet.RowCount++;
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
                string path = dirs + @"\" + mainWorksheet[row, column].ToString() + ".json";
                paths.Add(path);
            }
            //序列化为文件
            JsonTools.SerializeToFile(mainWorksheet, paths.ToArray());

            //mainWorksheet = CreatReoGrid.CurrentWorksheet;
            //string pathAndName = DialogTools.SaveFile();
            ////获取JsonKey
            //List<string> titleName = new List<string>();
            //Dictionary<string, string> conbineValue = new Dictionary<string, string>();
            //for (int j = 0; j < mainWorksheet.ColumnCount; j++)
            //{
            //    var pos = new CellPosition(0, j);

            //    if (mainWorksheet[pos] != null)
            //    {
            //        titleName.Add(mainWorksheet[pos].ToString());
            //    }
            //}

            //// 从第二行开始，将每行与JsonKey 组合为Dic文件, 同时序列化，存储
            //for (int row = 1; row < mainWorksheet.RowCount; row++)
            //{
            //    for (int column = 1; column < titleName.Count; column++)//第一个为文件名
            //    {
            //        var pos = new CellPosition(row, column);//每一个数据

            //        if (mainWorksheet[pos] != null)
            //        {
            //            conbineValue.Add(titleName[column], mainWorksheet[pos].ToString());
            //        }
            //    }
            //    //组合Dic中没有Value证明所有数据已全部保存
            //    if (conbineValue.Values.Count <= 0)
            //    {
            //        return;
            //    }
            //    //处理Dic文件为Jobject，
            //    JObject strJObject = JsonTools.SerializeToJobject(conbineValue);
            //    //序列化
            //    string json = JsonConvert.SerializeObject(strJObject);
            //    string formatJson = JsonTools.Format(json);
            //    string dir = Path.GetDirectoryName(pathAndName);
            //    string path = dir + @"\" + mainWorksheet[row, 0].ToString() + ".json";
            //    Debug.WriteLine("保存路径" + path);
            //    File.WriteAllText(path, formatJson);//存到文件中，如果不存在会自动创建
            //    conbineValue.Clear();
            //}
        }

        private void DeSerializedJson_Click(object sender, EventArgs e)
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

        //private string FormatJsonString(string str)
        //{
        //    //格式化json字符串
        //    JsonSerializer serializer = new JsonSerializer();
        //    TextReader tr = new StringReader(str);
        //    JsonTextReader jtr = new JsonTextReader(tr);
        //    object obj = serializer.Deserialize(jtr);
        //    if (obj != null)
        //    {
        //        StringWriter textWriter = new StringWriter();
        //        JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
        //        {
        //            Formatting = Formatting.Indented,
        //            Indentation = 4,
        //            IndentChar = ' '
        //        };
        //        serializer.Serialize(jsonWriter, obj);
        //        return textWriter.ToString();
        //    }
        //    else
        //    {
        //        return str;
        //    }
        //}

        private void SerializeJsonForm_Load(object sender, EventArgs e)
        {
            mainWorksheet = CreatReoGrid.CurrentWorksheet;
            mainWorksheet.SetCols(defaultColumn);
            mainWorksheet.SetRows(defaultRow);
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
    }
}
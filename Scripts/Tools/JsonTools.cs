using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace JsonShow
{
    public static class JsonTools
    {
        /// <summary>
        /// De serialized to dictionary.
        /// </summary>
        /// <param name="json">The json string.</param>
        /// <returns></returns>
        public static Dictionary<string, string> DeSerializeToDictionary(string json)
        {
            Dictionary<string, string> jsonDic = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(json);
                foreach (var item in jo)
                {
                    jsonDic.Add(item.Key, item.Value.ToString());
                }

                return jsonDic;
            }
            catch (Exception e)
            {
                MessageBox.Show("无法解析为表格");
            }

            return jsonDic;
        }

        /// <summary>
        /// Des the serialize to form. 不在标题栏出现sheet
        /// </summary>
        /// <param name="json">The json.</param>
        /// <param name="showGrid">The show grid.</param>
        /// <returns></returns>
        public static Worksheet DeSerializeToForm(FileInfo json, ReoGridControl showGrid)
        {
            string content = File.ReadAllText(json.FullName);
            var jsonDic = JsonTools.DeSerializeToDictionary(content);

            showGrid.CurrentWorksheet = showGrid.CreateWorksheet();
            Worksheet worksheet = showGrid.CurrentWorksheet;
            int tempColumn = 0;
            foreach (var dictionaryEntry in jsonDic)
            {
                var rowOne = new CellPosition(0, tempColumn); //第一行
                var rowTwo = new CellPosition(1, tempColumn); //第二行
                worksheet[rowOne] = dictionaryEntry.Key as string;
                string m = dictionaryEntry.Value;
                worksheet[rowTwo] = m;
                tempColumn++;
            }

            return worksheet;
        }

        /// <summary>
        /// De the serialize to form.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <param name="sheet">The sheet.</param>
        /// <param name="skipKeys">The skip keys.</param>
        /// <returns></returns>
        public static Worksheet DeSerializeToForm(string json, Worksheet sheet, params string[] skipKeys)
        {
            string content = json;
            var jsonDic = JsonTools.DeSerializeToDictionary(content);
            if (skipKeys != null)
            {
                foreach (var skipKey in skipKeys)
                {
                    if (jsonDic.ContainsKey(skipKey))
                    {
                        jsonDic.Remove(skipKey);
                    }
                }
            }

            //showGrid.CurrentWorksheet = showGrid.CreateWorksheet("");
            Worksheet worksheet = sheet;
            int tempColumn = 0;
            foreach (var dictionaryEntry in jsonDic)
            {
                var rowOne = new CellPosition(0, tempColumn); //第一行
                var rowTwo = new CellPosition(1, tempColumn); //第二行
                worksheet[rowOne] = dictionaryEntry.Key as string;
                string m = dictionaryEntry.Value;
                worksheet[rowTwo] = m;
                tempColumn++;
            }

            return worksheet;
        }

        /// <summary>
        /// Formats the json string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static string Format(string json)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(json);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return json;
            }
        }

        /// <summary>
        /// Serializes to file. 从第二行开始，第二列
        /// </summary>
        /// <param name="destinationWorksheet">The destination worksheet.</param>
        /// <param name="savePath">The save path.</param>
        /// <returns></returns>
        public static FileInfo[] SerializeToFile(Worksheet destinationWorksheet, string[] savePath)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            //获取JsonKey
            List<string> conbineKey = new List<string>();
            Dictionary<string, string> conbineValue = new Dictionary<string, string>();
            for (int j = 0; j < destinationWorksheet.ColumnCount; j++)
            {
                var pos = new CellPosition(0, j);

                if (destinationWorksheet[pos] != null)
                {
                    conbineKey.Add(destinationWorksheet[pos].ToString());
                }
            }

            int startRow = 1;
            int startColumn = 1;
            for (int row = startRow, pathIndex = 0; row < destinationWorksheet.RowCount; row++, pathIndex++)
            {
                // 从二行开始，将与JsonKey 组合为Dic文件
                for (int column = startColumn; column < conbineKey.Count; column++)
                {
                    var pos = new CellPosition(row, column);//每一个数据

                    if (destinationWorksheet[pos] != null && !conbineValue.ContainsKey(conbineKey[column]))
                    {
                        conbineValue.Add(conbineKey[column], destinationWorksheet[pos].ToString());
                    }
                }
                // 组合Dic中没有Value证明所有数据已全部保存
                if (conbineValue.Values.Count <= 0)
                {
                    break;
                }

                //处理Dic文件为Jobject，
                JObject strJObject = JsonTools.SerializeToJobject(conbineValue);
                //序列化
                string jstr = JsonConvert.SerializeObject(strJObject);
                //格式化
                string fJsonString = JsonTools.Format(jstr);
                string path = savePath[pathIndex];
                File.WriteAllText(path, fJsonString);//存到文件中，如果不存在会自动创建
                Debug.WriteLine("保存文件路径为：" + path);
                FileInfo jsonFile = new FileInfo(path);
                fileInfos.Add(jsonFile);
                conbineValue.Clear();
            }

            return fileInfos.ToArray();
        }

        public static JObject SerializeToJobject(Dictionary<string, string> source)
        {
            JObject target = new JObject();

            foreach (var DicEntity in source)
            {
                target.Add(DicEntity.Key, DicEntity.Value);
            }
            return target;
        }
        public static JObject SerializeToJobject<T,N>(IDictionary<T, N> source, params string[] skipKeys)
        {
            JObject target = new JObject();

            foreach (var DicEntity in source)
            {
                string key = DicEntity.Key as string;
                string value = DicEntity.Value as string;
                var m=skipKeys.Where(p => p == key);
                if (m.Count()>0)
                {
                    continue;
                }
                target.Add(DicEntity.Key as string, value);
            }
            return target;
        }

        public static string SerializeToString(Worksheet source)
        {
            //获取JsonKey
            List<string> titleName = new List<string>();
            Dictionary<string, string> conbineValue = new Dictionary<string, string>();
            for (int j = 0; j < source.ColumnCount; j++)
            {
                var pos = new CellPosition(0, j);

                if (source[pos] != null)
                {
                    titleName.Add(source[pos].ToString());
                }
            }

            //for (int i = 1; i < destinationWorksheet.RowCount; i++)
            //{
            // 第二行，将与JsonKey 组合为Dic文件, 同时序列化，存储
            for (int j = 0; j < titleName.Count; j++)
            {
                var pos = new CellPosition(1, j);//每一个数据

                if (source[pos] != null)
                {
                    conbineValue.Add(titleName[j], source[pos].ToString());
                }
            }

            //处理Dic文件为Jobject，
            JObject strJObject = JsonTools.SerializeToJobject(conbineValue);
            //序列化
            string jstr = JsonConvert.SerializeObject(strJObject);
            //格式化
            string fJsonString = Format(jstr);
            Debug.WriteLine(fJsonString);
            conbineValue.Clear();
            return fJsonString;
        }

        //public static
    }
}
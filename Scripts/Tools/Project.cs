using JsonShow;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class Project
{
    public string defaultSavePath = Application.StartupPath + @"\Project\";

    public Dictionary<string,FileInfo> showJsonList = new Dictionary<string, FileInfo>();
    private Project project;

    public Project()
    {
        Directory.CreateDirectory(defaultSavePath);
        project = this;
    }

    public string OpenProject(string PorjectName)
    {
        defaultSavePath = defaultSavePath + PorjectName;
        string content = File.ReadAllText(defaultSavePath);
        return content;
    }

    public void SaveProject(string PorjectName)
    {
        defaultSavePath = defaultSavePath + PorjectName;
        string content = JsonTools.SerializeToString(project);
        File.WriteAllText(defaultSavePath, content);
    }
}
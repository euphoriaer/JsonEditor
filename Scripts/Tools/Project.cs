﻿using JsonShow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class Project
{
    //public Dictionary<string, FileInfo> showNodes = new Dictionary<string, FileInfo>();
    public  string[] nodes;
    private static string defaultSavePath = Application.StartupPath + @"\Project\";
    private Project project;

    public Project()
    {
        Directory.CreateDirectory(defaultSavePath);
        project = this;
    }

    public string OpenProject(string PorjectName)
    {
        string Path = defaultSavePath + PorjectName;
        string content = File.ReadAllText(Path);
        return content;
    }

    public void SaveProject(string PorjectName)
    {
        string Path = defaultSavePath + PorjectName;
        string content = JsonTools.SerializeToString(project);
        File.WriteAllText(Path, content);
    }
}
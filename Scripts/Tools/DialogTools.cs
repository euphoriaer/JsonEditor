using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.Windows.Forms;

public static class DialogTools
{
    public static string[] OpenFiles(out bool isOk, string filter)
    {
        List<string> fullNames = new List<string>();
        OpenFileDialog fileDialog = new OpenFileDialog();

        fileDialog.Multiselect = true;
        fileDialog.CheckFileExists = true;
        fileDialog.InitialDirectory = Application.StartupPath;
        fileDialog.Filter = filter;
        if (fileDialog.ShowDialog() == DialogResult.OK)
        {
            foreach (var fileDialogFileName in fileDialog.FileNames)
            {
                fullNames.Add(fileDialogFileName);
            }

            isOk = true;
        }
        else
        {
            isOk = false;
        }
        return fullNames.ToArray();
    }

    public static string SaveFile(out bool isOk)
    {
        //string localFilePath, fileNameExt, newFileName, FilePath;
        SaveFileDialog sfd = new SaveFileDialog();

        //设置文件类型
        sfd.Filter = "json（*.json）|*.json";

        //设置默认文件类型显示顺序
        sfd.FilterIndex = 1;

        //保存对话框是否记忆上次打开的目录
        sfd.RestoreDirectory = true;

        //设置默认的文件名
        sfd.FileName = "";// in wpf is  sfd.FileName = "YourFileName";

        //点了保存按钮进入
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            string localFilePath = sfd.FileName.ToString(); //获得文件路径
            isOk = true;
            return localFilePath;
        }
        else
        {
            isOk = false;
        }

        return null;
    }

    public static string SaveFloder(out bool isOk)
    {
        //string localFilePath, fileNameExt, newFileName, FilePath;
        SaveFileDialog sfd = new SaveFileDialog();

        //设置文件类型
        sfd.Filter = "json（*.json）|*.json";

        //设置默认文件类型显示顺序
        sfd.FilterIndex = 1;

        //保存对话框是否记忆上次打开的目录
        sfd.RestoreDirectory = true;

        //设置默认的文件名
        sfd.FileName = "选择保存的文件夹";// in wpf is  sfd.FileName = "YourFileName";

        //点了保存按钮进入
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            string localFilePath = sfd.FileName.ToString(); //获得文件路径
            isOk = true;
            return localFilePath;
        }
        else
        {
            isOk = false;
        }

        return null;
    }


    public static string OpenFolder(out bool isOk)
    {
        CommonOpenFileDialog open = new CommonOpenFileDialog();
        open.IsFolderPicker = true;
        if (open.ShowDialog() == CommonFileDialogResult.Ok)
        {
            string path = open.FileName;
            isOk = true;
            return path;
        }

        isOk = false;
        return null;
    }

    public static void OpenExplorer(string openPath)
    {
        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
        psi.Arguments = "/e,/select," + openPath;
        System.Diagnostics.Process.Start(psi);
    }
}
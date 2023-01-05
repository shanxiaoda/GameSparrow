using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
public class Tsc
{
    [InitializeOnEnterPlayMode]
    public static void compileTS()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "src", "tsproj");
        string root = Directory.GetDirectoryRoot(path);
        var list = new List<string>();
        list.Add(root[0] + ":");//切换盘符
        list.Add("cd " + path);//
        list.Add("tsc");
        string cmd = string.Join(" && ", list);
        UnityEngine.Debug.Log("命令是:" + cmd);
        Process p = new Process();
        ProcessStartInfo _procStartInfo = new ProcessStartInfo("cmd.exe", @"/c " + cmd);
        p.StartInfo = _procStartInfo;
        _procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        p.Start();
        p.Close();
        UnityEngine.Debug.Log("编译tsc成功");
    }
}
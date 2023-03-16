using System;
using System.Collections.Generic;
using System.IO;
using Puerts;
using UnityEditor;
using UnityEngine;

public class MyLoader : ILoader, IModuleChecker
{
    /*
    * 允许自定义位置
    */
    public static string[] jsPathList = { "Assets", "src", "tsproj", "js" };
    private string jsPath;
    /** js代码是通过ab包加载的 **/
    private string abPath;
    public MyLoader()
    {
        jsPath = Path.Combine(jsPathList);
        abPath = String.Join("/", jsPathList);
    }

    public string ReadFile(string filepath, out string debugpath)
    {
        debugpath = filepath;
        if (filepath.StartsWith("puerts/"))
        {
            filepath = filepath.Replace(Path.GetExtension(filepath), "");
            var textAsset = Resources.Load<UnityEngine.TextAsset>(filepath);
            return textAsset ? textAsset.text : "";
        }
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            return "";
            // return Main.ab.LoadAsset<UnityEngine.TextAsset>(abPath + "/" + filepath).text;
        }
        else
        {
            string path = Path.Combine(jsPath, filepath);
            FileInfo fileInfo = new FileInfo(path);
            debugpath = fileInfo.FullName;
            using (StreamReader sr = fileInfo.OpenText())
            {
                string res = sr.ReadToEnd();
                sr.Close();
                return res;
            }
        }
    }

    public bool IsESM(string filepath)
    {
        return true;
    }

    public bool FileExists(string filepath)
    {
        return true;
    }
}
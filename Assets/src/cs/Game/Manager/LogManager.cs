using UnityEngine;
public class LogManager
{
    public void init()
    {
        Application.logMessageReceived += HandleLog;
    }

    public static int logCount = 0;
    public static string log = "";
    static void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            // logCount += 1;
            // log += logCount + ": ";
            // log += logString;
            // log += "\n";
            // log += stackTrace;
            // log += "\n";
            // log += SystemInfo.processorType;
        }
    }
}
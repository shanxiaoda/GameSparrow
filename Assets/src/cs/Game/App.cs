using UnityEngine;

public class App
{
    public static UpdateManager updateManager = new UpdateManager();
    public static LogManager logManager = new LogManager();
    public static LoaderManager loaderManager = new LoaderManager();
    public static JsEnvManager jsEnvManager = new JsEnvManager();

    //第一时间初始化
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    public static void init()
    {
        Application.runInBackground = true;
        App.logManager.init();
        App.jsEnvManager.init();
        App.updateManager.init();
    }
}
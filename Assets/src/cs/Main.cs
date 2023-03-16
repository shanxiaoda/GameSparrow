using System;
using UnityEngine;
public class Main
{
    public static Action action;
    public static InitParam initParam = new InitParam();

    [RuntimeInitializeOnLoadMethod]
    public static void init()
    {
        App.jsEnvManager.jsEnv.ExecuteModule<Action>("Main.mjs", "Init")();
        //这里是框架使用者自定义的地方
        Action<InitParam> action = App.jsEnvManager.jsEnv.ExecuteModule<Action<InitParam>>("Game/ActionUtils.mjs", "setUpdateAction");
        action(initParam);
    }
}

// c# 之间 js 初始化参数
public class InitParam
{
    public Action updateAction;
    public Action fixedUpdateAction;
    public Action lateUpdateAction;
}

public static class Logging
{
    [System.Diagnostics.Conditional("ENABLE_LOG")]
    static public void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }
}
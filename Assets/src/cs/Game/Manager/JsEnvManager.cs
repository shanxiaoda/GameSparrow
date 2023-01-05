using Puerts;
public class JsEnvManager
{
    public static int JavaScriptDebugPort = 18080;
    public JsEnv jsEnv = null;
    public void init()
    {
        this.jsEnv = new JsEnv(new MyLoader(), JavaScriptDebugPort);
#if UNITY_EDITOR
        this.jsEnv.WaitDebuggerAsync();
#endif
    }
}
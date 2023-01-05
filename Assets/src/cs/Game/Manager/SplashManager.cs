using UnityEngine;
using UnityEngine.Rendering;
public class SplashManager
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    public static void stopSplashScreen()
    {
        System.Threading.Tasks.Task.Run(AsyncSkip);
    }

    private static void AsyncSkip()
    {
        SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
    }
}
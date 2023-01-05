using System;
public static class GameUtils
{
    public static bool IsNull(this UnityEngine.Object o)
    {
        return o == null;
    }

    public static void RunAction(Action action)
    {
        if (action != null) { action(); }
    }
}
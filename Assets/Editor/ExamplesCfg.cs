using Puerts;
using System;
using UnityEditor;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;

[Configure]
public class ExamplesCfgujm
{
    [Binding]
    static IEnumerable<Type> Bindings
    {
        get
        {
            return new List<Type>()
            {
                typeof(UnityEngine.Debug),
                typeof(UnityEngine.Vector3),
                typeof(UnityEngine.SkinnedMeshRenderer),
                typeof(UnityEngine.GameObject),
                typeof(UnityEngine.Object),
                typeof(GameUtils),
                typeof(UnityEngine.Transform),
            };
        }
    }
}

[Configure]
public class PuerFilter
{
    [Filter]
    static bool FilterMethods(System.Reflection.MemberInfo mb)
    {
        // 排除 MonoBehaviour.runInEditMode, 在 Editor 环境下可用发布后不存在
        if (mb.DeclaringType == typeof(UnityEngine.GameObject) && mb.Name == "runInEditMode")
        {
            UnityEngine.Debug.Log("aaaaaaaaaaaaaaaaaaaaa");
            return true;
        }
        UnityEngine.Debug.Log("abbbbbbbbbbbbbbbbbb");
        return false;
    }

    static Puerts.Editor.Generator.BindingMode FilterMethods(System.Reflection.MemberInfo memberInfo)
    {
        if (memberInfo.DeclaringType.ToString() == "System.Threading.Tasks.Task" && memberInfo.Name == "IsCompletedSuccessfully")
        {
            return Puerts.Editor.Generator.BindingMode.DontBinding; // 不生成StaticWrapper，且JS调用时获取对应字段会得到undefined。
        }
        return Puerts.Editor.Generator.BindingMode.FastBinding; // 等同于前面return false的情况
    }

    static Puerts.Editor.Generator.BindingMode FilterMethods(System.Reflection.MemberInfo memberInfo)
    {
        if (memberInfo.DeclaringType.ToString() == "System.Threading.Tasks.Task" && memberInfo.Name == "IsCompletedSuccessfully")
        {
            return Puerts.Editor.Generator.BindingMode.LazyBinding; // 首次调用时才执行反射
        }
        return Puerts.Editor.Generator.BindingMode.FastBinding; // 等同于前面return false的情况
    }
}
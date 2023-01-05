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
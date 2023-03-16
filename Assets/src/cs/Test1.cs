using UnityEngine;
using System;

using System.Reflection;
using UnityEditor;
using UnityEditorInternal;

[Serializable]
public class TestObj1
{
    public string name;
    public Component ct;

    public string my;
}

public class Test1 : MonoBehaviour
{
    public TestObj1[] list;
    public string my;
    public string go;

    public TestObj1 ddd;
}


#if UNITY_EDITOR
[CustomEditor(typeof(Test1))]
public class TSProperties_CustomEditor : Editor
{
    public SerializedProperty sp;
    public ReorderableList list;

    public SerializedProperty mysp;
    private void OnEnable()
    {
        this.sp = this.serializedObject.FindProperty("list");
        this.mysp = this.serializedObject.FindProperty("go");

        list = new ReorderableList(this.serializedObject, this.sp, true, true, true, true);
        list.drawHeaderCallback = DrawHeader;
        list.drawElementCallback = DrawListItems;
        // list.drawFooterCallback = DrawFooter;
        list.drawElementBackgroundCallback = DrawBG;
        list.drawNoneElementCallback = DrawNone;
    }

    public void DrawNone(Rect rect)
    {
        // EditorGUILayout.MaskField
    }

    public void DrawBG(Rect rect, int index, bool isActive, bool isFocused)
    {
        EditorGUI.DrawRect(rect, Color.black * index * 0.1f);
    }

    public void DrawFooter(Rect rect)
    {
        EditorGUI.LabelField(rect, "footer");
    }

    public void DrawHeader(Rect rect)
    {
        // EditorGUILayout.LabelField("head");
        EditorGUI.LabelField(rect, "head");
    }

    public void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        EditorGUI.LabelField(rect, "item");
        rect.x = 80;
        rect.width = 50;
        UnityEngine.GUI.Button(rect, "btn");
        rect.x = 140;
        rect.width = 200;
        EditorGUI.ObjectField(rect, null, typeof(Component), true);

        EditorGUILayout.Toggle(true);//, "PaneOptions"
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.PropertyField(this.mysp, true);
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
using UnityEngine;
using System;

using System.Reflection;
using UnityEditor;
using UnityEditorInternal;

[Serializable]
public class TestObj2
{
    public string name;
    public Component ct;

    public string my = "my label";
}

public class Test2 : MonoBehaviour
{
    public TestObj2 my11111;
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(TestObj2))]
public class UserStrutDraw : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // EditorGUI.BeginProperty(position, label, property);
        GUI.Button(position, property.FindPropertyRelative("my").stringValue);
        EditorGUI.PropertyField(position, property.FindPropertyRelative("my"), new GUIContent("姓名："), true);
        // property.FindPropertyRelative("my").stringValue
        // EditorGUILayout.BeginHorizontal();
        // property.FindPropertyRelative("my") = EditorGUI.LabelField( position ,   );
        // EditorGUILayout.PropertyField(property.FindPropertyRelative("my") , new GUIContent("姓名："), true);
        // EditorGUILayout.PropertyField()
        // // EditorGUILayout.PropertyField(property.FindPropertyRelative("sex"),new GUIContent("性别："));
        // EditorGUILayout.EndHorizontal();
        // EditorGUI.EndProperty();
        // Event.current.Use();
    }
}

[CustomPropertyDrawer(typeof(TestObj2))]
public class ColorSpacerDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        GUI.Button(position, "aasdf");
        // calculate the rect values for where to draw the line in the inspector
        // float lineX = (position.x + (position.width / 2)) - colorSpacer.lineWidth / 2;
        // float lineY = position.y + (colorSpacer.spaceHeight / 2);
        // float lineWidth = colorSpacer.lineWidth;
        // float lineHeight = colorSpacer.lineHeight;

        // // Draw the line in the calculated place in the inspector
        // // (using the built in white pixel texture, tinted with GUI.color)
        // Color oldGuiColor = GUI.color;
        // GUI.color = colorSpacer.lineColor;
        // EditorGUI.DrawPreviewTexture(new Rect(lineX, lineY, lineWidth, lineHeight), Texture2D.whiteTexture);
        // GUI.color = oldGuiColor;
    }

    public override float GetHeight()
    {
        return 300;
    }
}
#endif
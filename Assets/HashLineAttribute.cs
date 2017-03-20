using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HashLineAttribute : PropertyAttribute
{

    public HashLineAttribute()
    {

    }

}

[CustomPropertyDrawer(typeof(HashLineAttribute))]
public class HashLineDrawer : DecoratorDrawer
{

    public override float GetHeight()
    {
        return base.GetHeight() * 2;
    }

    public override void OnGUI(Rect position)
    {
        GUIStyle myStyle = GUI.skin.GetStyle("Label");
        myStyle.alignment = TextAnchor.MiddleCenter;
        EditorGUI.LabelField(position, "#######################################", myStyle);
        base.OnGUI(position);
    }

}

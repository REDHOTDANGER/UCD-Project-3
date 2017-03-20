using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomObjectAttribute : PropertyAttribute
{

    public CustomObjectAttribute()
    {

    }

}

[CustomPropertyDrawer(typeof(CustomObjectAttribute))]
public class CustomObjectDrawer : PropertyDrawer
{

    CustomObjectAttribute CustObj
    {
        get { return ((CustomObjectAttribute)attribute); }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label)*3;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GameObject myObj = (GameObject)property.objectReferenceValue;

        Rect drawPosition = position;
        drawPosition.height = drawPosition.height / 3;
        EditorGUI.PropertyField(drawPosition, property, label, true);

        if(myObj != null)
        {
            drawPosition.y += drawPosition.height;
            float myFloat = myObj.transform.localScale.x;
            myFloat = EditorGUI.Slider(drawPosition, myFloat, 1, 10);
            myObj.transform.localScale = new Vector3(myFloat, myFloat, myFloat);

            drawPosition.y += drawPosition.height;
            myObj.transform.position = EditorGUI.Vector3Field(drawPosition, "Position", myObj.transform.position);
        }

        //base.OnGUI(position, property, label);
    }

}
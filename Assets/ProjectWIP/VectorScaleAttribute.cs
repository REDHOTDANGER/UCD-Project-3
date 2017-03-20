using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VectorScaleAttribute : PropertyAttribute
{
    public float minScaleOne;
    public float minScaleTwo;

    public VectorScaleAttribute(float minOne, float minTwo)
    {
        minScaleOne = minOne;
        minScaleTwo = minTwo;
    }

}

[CustomPropertyDrawer(typeof(VectorScaleAttribute))]
public class VectorScaleDrawer : PropertyDrawer
{
    VectorScaleAttribute CustObj
    {
        get { return ((VectorScaleAttribute)attribute); }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 6;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GameObject myObj = (GameObject)property.objectReferenceValue;

        Rect drawPosition = position;
        drawPosition.height = drawPosition.height / 6;
        EditorGUI.PropertyField(drawPosition, property, label, true);

        if (myObj != null)
        {
            drawPosition.y += 12;
            float objectX = myObj.transform.localScale.x;
            drawPosition.y += 11;
            objectX = EditorGUI.Slider(drawPosition, "X", objectX, CustObj.minScaleOne, CustObj.minScaleTwo);

            drawPosition.y += 12;
            float objectY = myObj.transform.localScale.y;
            drawPosition.y += 11;
            objectY = EditorGUI.Slider(drawPosition, "Y", objectY, CustObj.minScaleOne, CustObj.minScaleTwo);

            drawPosition.y += 12;
            float objectZ = myObj.transform.localScale.z;
            drawPosition.y += 11;
            objectZ = EditorGUI.Slider(drawPosition, "Z", objectZ, CustObj.minScaleOne, CustObj.minScaleTwo);

            myObj.transform.localScale = new Vector3(objectX, objectY, objectZ);
        }

        //base.OnGUI(position, property, label);
    }
}
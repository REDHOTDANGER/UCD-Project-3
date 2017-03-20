using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorLineAttribute : PropertyAttribute
{
    //public Color myColor;
    public Vector4 myColor; 
    public ColorLineAttribute(float red, float green, float blue)
    {
        Vector4 myColor = new Vector4(red, green, blue, 1);
        this.myColor = new Color(red, green, blue, 1);
    }

}

[CustomPropertyDrawer(typeof(ColorLineAttribute))]
public class ColorLineDrawer : DecoratorDrawer
{
    ColorLineAttribute colorLine { get { return ((ColorLineAttribute)attribute);  } }

    public override float GetHeight()
    {
        return base.GetHeight();
    }

    public override void OnGUI(Rect position)
    {
        Color oldColor = GUI.color;
        GUI.color = colorLine.myColor;

        EditorGUI.DrawPreviewTexture(new Rect(position.x, position.y + 3f, position.width, position.height - 13f), Texture2D.whiteTexture);

        GUI.color = oldColor;

        base.OnGUI(position);
    }
}
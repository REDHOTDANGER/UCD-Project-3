using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Sprites;

public class SpriteShowAttribute : PropertyAttribute
{
    public SpriteShowAttribute()
    {
    }
}

[CustomPropertyDrawer(typeof(SpriteShowAttribute))]
public class SpriteShowDrawer : PropertyDrawer
{

    SpriteShowAttribute spriteToDraw
    {
        get { return ((SpriteShowAttribute)attribute); }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label)*8;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Sprite mySprite = (Sprite)property.objectReferenceValue;

        Rect drawPosition = position;
        drawPosition.height = drawPosition.height / 3;
       
        EditorGUI.PropertyField(drawPosition, property, label, true);
        drawPosition.y += drawPosition.height;
        if (mySprite != null)
        {
            Texture2D aText = AssetPreview.GetAssetPreview(mySprite);
            GUI.Label(drawPosition, aText);
            
        }

        //base.OnGUI(position, property, label);
    }
}
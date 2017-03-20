using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyHeroClass))]
public class CustomHeroInspector : Editor
{
    MyHeroClass myHero;
    public string[] myChoices = new string[] { "Damaging", "Healing" };
    public int mySpellChoice = 0;

    SerializedProperty myWeaponObj;

    void OnEnable()
    {
        myHero = (MyHeroClass)target;
        myWeaponObj = serializedObject.FindProperty("myWeapon");
        mySpellChoice = myHero.mySpell.isDamaging ? 0 : 1;
    }

    public override void OnInspectorGUI()
    {
        DrawBaseInfo();
        DrawSpellInfo();
        DrawWeaponInfo();
        //base.OnInspectorGUI();
    }

    private void DrawBaseInfo()
    {
        EditorGUILayout.LabelField("Base Info", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        myHero.heroName = EditorGUILayout.TextField("Hero Name: ", myHero.heroName);

        myHero.healthAmt = EditorGUILayout.IntSlider("Health: ", myHero.healthAmt, 1, 100);
        ProgressBar(myHero.healthAmt / 100f, "Health");

        myHero.armorAmt = EditorGUILayout.IntSlider("Armor: ", myHero.armorAmt, 1, 60);
        ProgressBar(myHero.armorAmt / 60f, "Armor");

        myHero.manaPool = EditorGUILayout.IntSlider("Mana: ", myHero.manaPool, 1, 50);
        ProgressBar(myHero.manaPool / 50f, "Mana");

        EditorGUILayout.EndVertical();
    }

    private void DrawSpellInfo()
    {
        EditorGUILayout.LabelField("Spell Info", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        mySpellChoice = GUILayout.SelectionGrid(mySpellChoice, myChoices, 2);
        myHero.mySpell.spellName = EditorGUILayout.TextField("Spell name: ", myHero.mySpell.spellName);
        myHero.mySpell.manaCost = EditorGUILayout.IntSlider("Mana cost: ", myHero.mySpell.manaCost, 1, 50);

        string s;
        if (mySpellChoice == 0)
            s = "Damage amount: ";
        else
            s = "Healing amount: ";

        myHero.mySpell.totalAmount = EditorGUILayout.IntSlider(s, myHero.mySpell.totalAmount, 1, 25);

        EditorGUILayout.EndVertical();

        myHero.mySpell.isDamaging = mySpellChoice == 0;
    }

    void DrawWeaponInfo()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(myWeaponObj);
        serializedObject.ApplyModifiedProperties();
    }

    void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
    }

}

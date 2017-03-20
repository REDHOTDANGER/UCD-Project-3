using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeroClass : MonoBehaviour
{
    public string heroName;

    public int armorAmt;
    public int healthAmt;
    public int manaPool;

    [System.Serializable]
    public struct spell
    {
        public string spellName;
        public int manaCost;
        public bool isDamaging;
        public int totalAmount;
    }

    public spell mySpell;

    public WeaponClass myWeapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

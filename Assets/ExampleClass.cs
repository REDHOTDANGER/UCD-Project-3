using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public float myFloat;
    [ColorLine(0f, 255f, 0f)]
    public int myInt;
    [ColorLine(0f, 0f, 255f)]

    [CustomObject]
    public GameObject myObject;

    //[SpriteShow]

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

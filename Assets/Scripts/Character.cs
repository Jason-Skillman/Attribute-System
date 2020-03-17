using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [Header("Base Attributes")]
    public int strengthValue = 10;
    public int magicValue = 10;
    public int speedValue = 10;
    public int agilityValue = 5;

    [Header("Level up Bonues")]
    public int strengthBonus = 0;
    public int magicBonus = 10;

    private Attribute strengthAttribute;
    private Attribute magicAttribute;
    private Attribute speedAttribute;
    private Attribute agilityAttribute;


    private void Awake() {
        strengthAttribute = new Attribute(strengthValue);
        magicAttribute = new Attribute(magicValue);
        speedAttribute = new Attribute(speedValue);
        agilityAttribute = new Attribute(agilityValue);
    }

    private void Start() {
        //Add level up bonuses
        strengthAttribute.AddBonus(new StandardBonus(strengthBonus));
        magicAttribute.AddBonus(new StandardBonus(magicBonus, 0.1f));

        //Add dependant attribute
        speedAttribute.AddBonus(agilityAttribute);
    }

    private void Update() {
        //Adds a timed strength boost
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            strengthAttribute.AddBonus(new TimedBonus(strengthAttribute, 3000, 5));
        } else if(Input.GetKeyDown(KeyCode.Alpha2)) {
            agilityAttribute.AddBonus(new TimedBonus(agilityAttribute, 3000, 5));
        }

        Debug.Log("Strength Value: " + strengthAttribute.CalculateValue());
        Debug.Log("Magic Value: " + magicAttribute.CalculateValue());
        Debug.Log("Speed Value: " + speedAttribute.CalculateValue());
        Debug.Log("Agility Value: " + agilityAttribute.CalculateValue());
    }

}

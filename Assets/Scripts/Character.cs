using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [Header("Base Attributes")]
    public int strengthValue = 10;

    [Header("Level up Bonues")]
    public int strengthBonus = 0;

    private Attribute strengthAttribute;


    private void Awake() {
        strengthAttribute = new Attribute(strengthValue);
    }

    private void Start() {
        //Add level up bonuses
        strengthAttribute.AddBonus(new RawBonus(strengthBonus));

        //strengthAttribute.AddBonus(new RawBonus(9, 0.1f));

        strengthAttribute.AddBonus(new TimedBonus(strengthAttribute, 3000, 5));
    }

    private void Update() {
        Debug.Log("Strength Value: " + strengthAttribute.CalculateValue());
    }

}

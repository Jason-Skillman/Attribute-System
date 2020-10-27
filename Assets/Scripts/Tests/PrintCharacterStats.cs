using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrintCharacterStats : MonoBehaviour {

	[SerializeField]
	private Character character;

	[SerializeField]
	private TMP_Text textStrength, textSpeed, textIntelligence;

	private void Update() {
		textStrength.text = character.StrengthAttribute.CalculateValue().ToString();
		textSpeed.text = character.SpeedAttribute.CalculateValue().ToString();
		textIntelligence.text = character.IntelligenceAttribute.CalculateValue().ToString();
	}

}
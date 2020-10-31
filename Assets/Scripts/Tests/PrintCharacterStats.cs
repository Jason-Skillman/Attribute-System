using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class PrintCharacterStats : MonoBehaviour {

	[SerializeField]
	private Character character;

	[SerializeField]
	private TMP_Text textStrength, textSpeed, textIntelligence;
	
	[SerializeField]
	private TMP_Text textStrengthFlavor, textSpeedFlavor, textIntelligenceFlavor;

	private StringBuilder sb;

	private void Awake() {
		sb = new StringBuilder();
	}

	private void Update() {
		textStrength.text = character.StrengthAttribute.CalculateValue().ToString();
		textSpeed.text = character.SpeedAttribute.CalculateValue().ToString();
		textIntelligence.text = character.IntelligenceAttribute.CalculateValue().ToString();

		sb.Clear();
		foreach(BaseAttribute bonus in character.StrengthAttribute.Bonuses) {
			sb.Append(bonus.AttributeName);
			sb.Append(" +");
			sb.Append(bonus.BaseValue);
			sb.Append("\n");
		}
		textStrengthFlavor.text = sb.ToString();
		
		sb.Clear();
		foreach(BaseAttribute bonus in character.SpeedAttribute.Bonuses) {
			sb.Append(bonus.AttributeName);
			sb.Append(" +");
			sb.Append(bonus.BaseValue);
			sb.Append("\n");
		}
		textSpeedFlavor.text = sb.ToString();
		
		sb.Clear();
		foreach(BaseAttribute bonus in character.IntelligenceAttribute.Bonuses) {
			sb.Append(bonus.AttributeName);
			sb.Append(" +");
			sb.Append(bonus.BaseValue);
			sb.Append("\n");
		}
		textIntelligenceFlavor.text = sb.ToString();
	}

}
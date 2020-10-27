using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusNode : MonoBehaviour {

	[SerializeField]
	private AttributeType attributeType;
	[SerializeField]
	private int bonusValue;
	[SerializeField]
	private Color activeNodeColor;

	[Header("References")]
	[SerializeField]
	private Character character;
	[SerializeField]
	private Button button;
	[SerializeField]
	private Image image;

	public void ApplyBonus() {
		StandardBonus bonus = new StandardBonus(bonusValue);

		if(attributeType == AttributeType.Strength)
			character.StrengthAttribute.AddBonus(bonus);
		else if(attributeType == AttributeType.Strength)
			character.SpeedAttribute.AddBonus(bonus);
		else if(attributeType == AttributeType.Strength)
			character.IntelligenceAttribute.AddBonus(bonus);

		button.interactable = false;
		image.color = activeNodeColor;
	}

	public enum AttributeType {
		Strength,
		Speed,
		Intelligence
	}

}

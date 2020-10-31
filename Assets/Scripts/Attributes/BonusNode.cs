using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusNode : MonoBehaviour {

	[Header("Attribute")]
	[SerializeField]
	private AttributeType attributeType;
	[SerializeField]
	private string bonusName;
	[SerializeField]
	private int bonusValue;
	
	[Header("Node")]
	[SerializeField]
	private Color activeNodeColor;

	[Header("References")]
	[SerializeField]
	private Character character;
	[SerializeField]
	private TMP_Text titleText, bodyText;
	[SerializeField]
	private Button button;
	[SerializeField]
	private Image image;
	
	private void Start() {
		titleText.text = bonusName;

		StringBuilder sb = new StringBuilder();
		sb.Append("+");
		sb.Append(bonusValue);
		sb.Append(" ");
		sb.Append(attributeType.ToString());
		bodyText.text = sb.ToString();
	}

	public void ApplyBonus() {
		StandardBonus bonus = new StandardBonus(bonusValue, name: bonusName);

		if(attributeType == AttributeType.Strength)
			character.StrengthAttribute.AddBonus(bonus);
		else if(attributeType == AttributeType.Speed)
			character.SpeedAttribute.AddBonus(bonus);
		else if(attributeType == AttributeType.Intelligence)
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

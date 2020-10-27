using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	
	[Header("Base Attributes")]
	[SerializeField]
	private int strengthValue;
	[SerializeField]
	private int speedValue;
	[SerializeField]
	private int intelligenceValue;
	
	private Attribute strengthAttribute;
	private Attribute speedAttribute;
	private Attribute intelligenceAttribute;

	public Attribute StrengthAttribute => strengthAttribute;
	public Attribute SpeedAttribute => speedAttribute;
	public Attribute IntelligenceAttribute => intelligenceAttribute;

	private void Awake() {
		strengthAttribute = new Attribute(strengthValue);
		speedAttribute = new Attribute(speedValue);
		intelligenceAttribute = new Attribute(intelligenceValue);
	}
	
}
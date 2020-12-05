using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GUST.Characters;

public class AttributeUI : MonoBehaviour {
	[SerializeField] private TMP_Text stNumText = null;
	[SerializeField] private TMP_Text dxNumText = null;
	[SerializeField] private TMP_Text iqNumText = null;
	[SerializeField] private TMP_Text htNumText = null;
	[SerializeField] private TMP_Text willNumText = null;
	[SerializeField] private TMP_Text percNumText = null;

	public void UpdateStats(Character character) {
		stNumText.text = character[Attribute.ST].ToString();
		dxNumText.text = character[Attribute.DX].ToString();
		iqNumText.text = character[Attribute.IQ].ToString();
		htNumText.text = character[Attribute.HT].ToString();
		willNumText.text = character[Attribute.Will].ToString();
		percNumText.text = character[Attribute.Perception].ToString();
	}
}

using GUST.Characters;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterDetails : MonoBehaviour {
	[SerializeField] private TMP_InputField characterNameField = null;
	[SerializeField] private TMP_InputField characterTLField = null;
	[SerializeField] private CharacterStatsUI characterStatsUI = null;

	private Character character;

	public void UpdateName() {
		character.Name = characterNameField.text;
	}

	public void Load(Character character) {
		this.character = character;
		characterNameField.text = character.Name;
		characterTLField.text = "TL";
		characterStatsUI.Load(character);
	}
}

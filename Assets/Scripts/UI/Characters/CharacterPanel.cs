using GUST.Characters;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour {
	[SerializeField] private TMP_Text characterNameText = null;

	private CharacterPopup popup = null;
	private Character character;

	public void Create(CharacterPopup popup, Character character) {
		this.popup = popup;
		this.character = character;
		characterNameText.text = character.Name;
	}

	public void Display() {
		popup.Display(character);
	}

	private void OnEnable() {
		if (character != null) {
			characterNameText.text = character.Name;
		}
	}
}

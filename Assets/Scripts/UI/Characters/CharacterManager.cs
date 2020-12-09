using GUST.Characters;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {
	[SerializeField] private GameObject characterButtonPrefab = null;
	[SerializeField] private GameObject characterNamePopup = null;
	[SerializeField] private TMP_InputField nameField = null;
	[SerializeField] private Button nameSubmitButton = null;
	[SerializeField] private RectTransform characterParent = null;
	[SerializeField] private CharacterPopup popup = null;

	private readonly List<Character> characters = new List<Character>();

	public void ShowNamePopup() {
		characterNamePopup.SetActive(true);
		//EventSystem.current.SetSelectedGameObject(nameField.gameObject);
		nameField.Select();
		nameField.ActivateInputField();
	}

	public void HideNamePopup() {
		nameField.text = "";
		nameSubmitButton.interactable = false;
		characterNamePopup.SetActive(false);
	}

	public void ValidateName() {
		nameSubmitButton.interactable = nameField.text != "";
	}

	public void AddCharacter(TMP_InputField nameField) {
		Character c = ScriptableObject.CreateInstance<Character>();
		c.Create(nameField.text);
		characters.Add(c);
		CharacterPanel panel = Instantiate(characterButtonPrefab, characterParent).GetComponent<CharacterPanel>();
		panel.Create(popup, c);
	}
}

using GUST.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
	[SerializeField] private GameObject characterButtonPrefab = null;
	[SerializeField] private RectTransform characterParent = null;
	[SerializeField] private CharacterPopup popup = null;

	private readonly List<Character> characters = new List<Character>();

	public void AddCharacter(string name) {
		Character c = ScriptableObject.CreateInstance<Character>();
		c.Create(name);
		characters.Add(c);
		CharacterPanel panel = Instantiate(characterButtonPrefab, characterParent).GetComponent<CharacterPanel>();
		panel.Create(popup, c);
	}
}

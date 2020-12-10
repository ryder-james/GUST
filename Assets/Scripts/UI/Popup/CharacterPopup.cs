using GUST.Characters;
using GUST.Spells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPopup : Popup<Character> {
	[SerializeField] private CharacterDetails characterDetails = null;
	[SerializeField] private GameObject underMenu = null;

	private RectTransform rTransform;
	private Vector3 start;
	private bool inMotion = false;

	private void Start() {
		rTransform = transform as RectTransform;
		start = rTransform.anchoredPosition;
	}

	public override void Display(Character toDisplay) {
		characterDetails.Load(toDisplay);
		gameObject.SetActive(true);
		StartCoroutine(nameof(MoveAsync), true);
	}

	public void Hide() {
		StartCoroutine(nameof(MoveAsync), false);
	}

	private IEnumerator MoveAsync(bool movingOn) {
		yield return new WaitUntil(() => !inMotion);

		inMotion = true;

		if (!movingOn) {
			underMenu.SetActive(true);
		}

		Vector3 start = rTransform.anchoredPosition;
		Vector3 end = movingOn ? Vector3.zero : this.start;
		for (float t = 0; t < 0.6f; t += Time.deltaTime) {
			rTransform.anchoredPosition = Vector3.Lerp(start, end, t / 0.6f);
			yield return new WaitForEndOfFrame();
		}

		rTransform.anchoredPosition = end;
		if (!movingOn) {
			gameObject.SetActive(false);
		} else {
			underMenu.SetActive(false);
		}
		inMotion = false;
	}
}

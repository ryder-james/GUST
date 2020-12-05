using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GUST.Characters;

[ExecuteInEditMode]
public class ReserveUI : MonoBehaviour {
	[SerializeField] protected Color color = Color.red;
	[SerializeField] private Image background = null;
	[SerializeField] private Image currentBar = null;
	[SerializeField] private Image basicBar = null;
	[SerializeField] private TMP_InputField titleText = null;
	[SerializeField] private TMP_InputField currentValue = null;
	[SerializeField] private TMP_InputField basicValue = null;
	[SerializeField] private TMP_Text currentText = null;
	[SerializeField] private TMP_Text basicText = null;

	public Character Caster { get; set; }
	public Reserve Reserve { get; private set; }

	protected virtual string DefaultTitle => "Energy Reserve";
	protected const int DefaultValue = 10;

	private void Start() {
		ResetReserve();
	}

	private void Update() {
		UpdateColor();
	}

	public void UpdateValues() {
		if (Reserve != null) {
			Reserve.Name = titleText.text;
			Reserve.Current = int.Parse(currentValue.text);
			Reserve.Basic = int.Parse(basicValue.text);
			UpdateReserve();
		}
	}

	public virtual void ResetReserve(bool eraseCaster = false) {
		if (eraseCaster) {
			Caster = null;
		}

		Reserve = new Reserve(DefaultTitle, DefaultValue);

		UpdateReserve();
	}

	public void UpdateReserve(Character caster = null, Reserve reserve = null) {
		if (caster != null) {
			Caster = caster;
		}
		if (reserve != null) {
			Reserve = reserve;
		}

		UpdateText(Reserve.Name, Reserve.Current, Reserve.Basic);
		
	}

	protected virtual void UpdateText(string title, int current, int basic) {
		if (titleText != null) {
			titleText.text = title;
		}

		if (currentValue != null) {
			currentValue.text = current.ToString();
		}

		if (basicValue != null) {
			basicValue.text = basic.ToString();
		}
	}

	private void UpdateColor() {
		if (titleText != null) {
			titleText.textComponent.color = Color.white;
		}

		if (currentValue != null) {
			currentValue.textComponent.color = color;
		}

		if (basicValue != null) {
			basicValue.textComponent.color = color;
		}

		if (background != null) {
			background.color = color;
		}

		if (currentBar != null) {
			currentBar.color = color;
		}

		if (basicBar != null) {
			basicBar.color = color;
		}

		if (currentText != null) {
			currentText.color = color;
		}

		if (basicText != null) {
			basicText.color = color;
		}
	}

	public void Delete() {
		if (Caster != null) {
			Caster.EnergyReserves.Remove(Reserve);
		}
		Destroy(gameObject);
	}
}

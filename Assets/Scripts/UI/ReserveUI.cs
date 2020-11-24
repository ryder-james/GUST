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
	[SerializeField] private TMP_Text titleText = null;
	[SerializeField] private TMP_Text currentValue = null;
	[SerializeField] private TMP_Text basicValue = null;
	[SerializeField] private TMP_Text currentText = null;
	[SerializeField] private TMP_Text basicText = null;

	public Reserve Reserve { get; set; }

	protected virtual string DefaultTitle => "Energy Reserve";
	protected const int DefaultValue = 10;

	protected virtual void Update() {
		if (Reserve != null) {
			if (titleText != null) {
				titleText.text = Reserve.Name;
				titleText.color = Color.white;
			}

			if (currentValue != null) {
				currentValue.text = Reserve.Current.ToString();
				currentValue.color = color;
			}

			if (basicValue != null) {
				basicValue.text = Reserve.Basic.ToString();
				basicValue.color = color;
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
		} else {
			if (titleText != null) {
				titleText.text = DefaultTitle;
				titleText.color = Color.white;
			}

			if (currentValue != null) {
				currentValue.text = DefaultValue.ToString();
				currentValue.color = color;
			}

			if (basicValue != null) {
				basicValue.text = DefaultValue.ToString();
				basicValue.color = color;
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
	}
}

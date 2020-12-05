using GUST.Characters;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class FatiguePointsUI : ReserveUI {
	[SerializeField] private TMP_Text checkText = null;

	protected override string DefaultTitle => "Fatigue Points";

	protected override void UpdateText(string title, int current, int basic) {
		if (checkText != null) {
			checkText.text = CalculateChecks(basic);
		}
	}

	private string CalculateChecks(int basic) {
		float tiredLimit = basic / 3;

		StringBuilder sb = new StringBuilder();
		sb.Append($"  {tiredLimit} tired\n");
		sb.Append("  0 collapsed\n");
		sb.Append($"-{basic} unconscious");

		return sb.ToString();
	}
}

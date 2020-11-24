using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class FatiguePointsUI : ReserveUI {
	[SerializeField] private TMP_Text checkText = null;

	protected override string DefaultTitle => "Fatigue Points";

	protected override void Update() {
		base.Update();

		if (Reserve != null) {
			if (checkText != null) {
				checkText.text = CalculateChecks(Reserve.Basic);
				checkText.color = color;
			}
		} else {
			if (checkText != null) {
				checkText.text = CalculateChecks(DefaultValue);
				checkText.color = color;
			}
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

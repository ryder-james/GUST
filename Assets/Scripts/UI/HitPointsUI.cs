using GUST.Characters;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class HitPointsUI : ReserveUI {
	[SerializeField] private TMP_Text checkText = null;

	protected override string DefaultTitle => "Hit Points";

	protected override void UpdateText(string title, int current, int basic) {
		base.UpdateText(title, current, basic);

		if (checkText != null) {
			checkText.text = CalculateChecks(basic);
		}
	}

	private string CalculateChecks(int basic) {
		float reelingLimit = basic / 3;

		StringBuilder sb = new StringBuilder();
		sb.Append($"  {reelingLimit} reeling\n");
		sb.Append("  0 collapsed\n");
		sb.Append($"-{basic} check #1\n");
		sb.Append($"-{basic * 2} check #2\n");
		sb.Append($"-{basic * 3} check #3\n");
		sb.Append($"-{basic * 4} check #4\n");
		sb.Append($"-{basic * 5} dead");

		return sb.ToString();
	}
}

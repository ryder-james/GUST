using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GUST.Characters;

public class CharacterStatsUI : MonoBehaviour {
	[SerializeField] private HitPointsUI hitPoints = null;
	[SerializeField] private FatiguePointsUI fatiguePoints = null;
	[SerializeField] private GameObject reservePrefab = null;
	[SerializeField] private RectTransform reserveParent = null;
	[SerializeField] private AttributeUI attributeUI = null;

	private Character caster;

	public void Load(Character caster) {
		this.caster = caster;

		if (caster != null) {
			hitPoints.UpdateReserve(ref caster, caster.HitPoints.ID);
			fatiguePoints.UpdateReserve(ref caster, caster.FatiguePoints.ID);

			for (int i = 2; i < reserveParent.childCount - 1; i++) {
				Destroy(reserveParent.GetChild(i).gameObject);
			}
			foreach (Reserve r in caster.EnergyReserves) {
				ReserveUI rUI = Instantiate(reservePrefab, reserveParent).GetComponent<ReserveUI>();
				rUI.UpdateReserve(ref caster, r.ID);
				rUI.transform.SetSiblingIndex(reserveParent.childCount - 2);
			}

			attributeUI.UpdateStats(caster);
		}
	}

	public void AddReserve() {
		Reserve r;
		if (caster != null) {
			r = caster.AddReserve("Energy Reserve");
		} else {
			r = new Reserve("Energy Reserve", 10);
		}

		ReserveUI rUI = Instantiate(reservePrefab, reserveParent).GetComponent<ReserveUI>();
		rUI.UpdateReserve(ref caster, r.ID);
		rUI.transform.SetSiblingIndex(reserveParent.childCount - 2);
	}
}

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

	public Character Caster { get; private set; }

	public void Load(Character caster) {
		Caster = caster;

		if (Caster != null) {
			hitPoints.UpdateReserve(Caster, Caster.HitPoints);
			fatiguePoints.UpdateReserve(caster, Caster.FatiguePoints);

			for (int i = 2; i < reserveParent.childCount; i++) {
				Destroy(reserveParent.GetChild(i));
			}
			foreach (Reserve r in Caster.EnergyReserves) {
				ReserveUI rUI = Instantiate(reservePrefab, reserveParent).GetComponent<ReserveUI>();
				rUI.UpdateReserve(caster, r);
			}

			attributeUI.UpdateStats(Caster);
		}
	}

	public void AddReserve() {
		Reserve r = new Reserve("Energy Reserve", 10);
		ReserveUI rUI = Instantiate(reservePrefab, reserveParent).GetComponent<ReserveUI>();
		rUI.UpdateReserve(Caster, r);
		rUI.transform.SetSiblingIndex(reserveParent.childCount - 2);
		if (Caster != null) {
			Caster.EnergyReserves.Add(r);
		}
	}
}

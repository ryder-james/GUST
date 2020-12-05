using GUST.Characters;
using GUST.Spells;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class QuickSpellView : MonoBehaviour {
	[SerializeField] private TMP_Text title = null;
	[SerializeField] private TMP_Text notes = null;
	[SerializeField] private TMP_Text skillLevel = null;
	[SerializeField] private GameObject skillLevelContainer = null;
	[SerializeField] private TMP_Text cost = null;
	[SerializeField] private TMP_Text castingTime = null;
	[SerializeField] private Spell spell = null;

	public Character Caster { get; set; }

	private void Update() {
		if (spell != null) {
			title.text = spell.Name;
			notes.text = spell.Notes;
			if (Caster != null) {
				skillLevelContainer.SetActive(true);
				skillLevel.text = spell.SpellSkill.GetRelativeSkillLevel(Caster.Spells[spell].skillLevel);
			} else {
				skillLevelContainer.SetActive(false);
			}
			cost.text = spell.SpellCost.ShortString;
			castingTime.text = spell.CastingTime.ShortString;
		} else {
			title.text = "Air Jet";
			notes.text = "Notes...";
			if (Caster != null) {
				skillLevelContainer.SetActive(true);
				skillLevel.text = "12";
			} else {
				skillLevelContainer.SetActive(false);
			}
			cost.text = "1-3";
			castingTime.text = "1 sec";
		}
	}
}

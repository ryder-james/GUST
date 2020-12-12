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
    public Spell Spell { get => spell; set => spell = value; }

    private void Update() {
		if (Spell != null) {
			title.text = Spell.Name;
			notes.text = Spell.Notes;
			if (Caster != null) {
				skillLevelContainer.SetActive(true);
				skillLevel.text = spell.SpellSkill.GetRelativeSkillLevel(Caster.Spells[spell].skillLevel);
			} else {
				skillLevelContainer.SetActive(false);
			}
			cost.text = Spell.SpellCost != null ? Spell.SpellCost.ShortString : "";
			castingTime.text = Spell.CastingTime != null ? Spell.CastingTime.ShortString : "";
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

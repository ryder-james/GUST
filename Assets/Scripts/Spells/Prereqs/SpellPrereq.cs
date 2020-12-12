using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	[CreateAssetMenu(fileName = "SpellPrereq", menuName = PrereqAssetMenuPrefix + "Spell")]
	public class SpellPrereq : Prereq {
		[SerializeField, Min(0)] private int minLevel = 0;
		[SerializeField] private Spell spell = null;

		public Spell Spell { get => spell; set => spell = value; }
		public int MinLevel {
			get => minLevel;
			set => minLevel = Mathf.Max(0, value);
		}

		public override bool IsMet(Character caster) {
			foreach (Spell spell in caster.Spells.Keys) {
				if (spell.Name == Spell.Name) {
					Attribute att = spell.SpellSkill.Attribute;
					return spell.SpellSkill.GetLevel(caster.Spells[spell].skillLevel, caster[att]) >= MinLevel;
				}
			}

			return false;
		}
	}
}
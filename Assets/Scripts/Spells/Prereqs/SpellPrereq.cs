using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	public class SpellPrereq : Prereq {
		private int minLevel;

		public Spell Spell { get; set; }
		public int MinLevel {
			get => minLevel;
			set => minLevel = Mathf.Max(0, value);
		}

		public override bool IsMet(Character caster) {
			foreach (Spell spell in caster.Spells) {
				if (spell.Name == Spell.Name) {
					Attribute att = spell.SpellSkill.Attribute;
					return spell.SpellSkill.GetLevel(caster[att]) >= MinLevel;
				}
			}

			return false;
		}
	}
}
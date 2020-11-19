using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {

	public class CollegePrereq : Prereq {
		public string College { get; set; }
		private int minSpellsKnown;

		public int MinSpellsKnownInCollege {
			get => minSpellsKnown;
			set => minSpellsKnown = Mathf.Max(0, value);
		}

		public override bool IsMet(Character caster) {
			int relatedSpells = 0;

			foreach (Spell spell in caster.Spells) {
				if (spell.Colleges.Contains(College)) {
					relatedSpells++;
				}
			}

			return relatedSpells >= minSpellsKnown;
		}
	}
}
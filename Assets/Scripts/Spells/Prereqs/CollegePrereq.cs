using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	[CreateAssetMenu(fileName = "CollegePrereq", menuName = PrereqAssetMenuPrefix + "College")]
	public class CollegePrereq : Prereq {
		[SerializeField, Min(0)] private int minSpellsKnown = 0;
		[SerializeField] private string college = "";

		public string College { get => college; set => college = value; }
		public int MinSpellsKnownInCollege {
			get => minSpellsKnown;
			set => minSpellsKnown = Mathf.Max(0, value);
		}

		public override bool IsMet(Character caster) {
			int relatedSpells = 0;

			foreach (Spell spell in caster.Spells.Keys) {
				if (spell.Colleges.Contains(College)) {
					relatedSpells++;
				}
			}

			return relatedSpells >= minSpellsKnown;
		}
	}
}
using System.Collections.Generic;

using GUST.Characters;

namespace GUST.Spells.Prereqs {

	public class PrereqSet : Prereq {
		public List<Prereq> Prereqs { get; }
		public ComparisonType Comparator { get; set; }

		public PrereqSet() {
			Prereqs = new List<Prereq>();
		}

		public override bool IsMet(Character caster) {
			bool result;

			switch (Comparator) {
			default:
			case ComparisonType.And:
				result = true;

				foreach (Prereq prereq in Prereqs) {
					if (!prereq.IsMet(caster)) {
						result = false;
						break;
					}
				}

				break;
			case ComparisonType.Or:
				result = false;

				foreach (Prereq prereq in Prereqs) {
					if (prereq.IsMet(caster)) {
						result = true;
						break;
					}
				}

				break;
			}

			return result;
		}
	}
}
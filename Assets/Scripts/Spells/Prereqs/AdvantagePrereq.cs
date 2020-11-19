using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	public class AdvantagePrereq : Prereq {
		private int minLevel;

		public string AdvantageName { get; set; }
		public string Specialization { get; set; }
		public int MinLevel {
			get => minLevel;
			set => minLevel = Mathf.Max(0, value);
		}

		private bool CheckAdvantageMatch(Advantage adv) {
			bool result = true;

			if (!(Specialization.Trim() == "")) {
				result = Specialization.Contains(adv.Specialization);
			}

			if (result && MinLevel > 0) {
				result = adv.HasLevels ? adv.Level >= MinLevel : false;
			}

			return result;
		}

		public override bool IsMet(Character caster) {
			bool result = true;

			foreach (Advantage adv in caster.Advantages) {
				if (adv.Name == AdvantageName) {
					result = CheckAdvantageMatch(adv);
					if (result) {
						break;
					}
				}
			}

			return result;
		}
	}
}
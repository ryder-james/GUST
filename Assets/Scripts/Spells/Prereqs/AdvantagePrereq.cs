using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	[CreateAssetMenu(fileName = "AdvantagePrereq", menuName = PrereqAssetMenuPrefix + "Advantage")]
	public class AdvantagePrereq : Prereq {
		[SerializeField, Min(0)] private int minLevel = 0;
		[SerializeField] private string advantageName = "";
		[SerializeField] private string specialization = "";

		public string AdvantageName { get => advantageName; set => advantageName = value; }
		public string Specialization { get => specialization; set => specialization = value; }
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
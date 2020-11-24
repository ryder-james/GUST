using System.Collections.Generic;
using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	[CreateAssetMenu(fileName = "PrereqSet", menuName = PrereqAssetMenuPrefix + "Prereq Set")]
	public class PrereqSet : Prereq {
		[SerializeField] private ComparisonType comparator = ComparisonType.And;
		[SerializeField] private List<Prereq> prereqs = new List<Prereq>();

		public List<Prereq> Prereqs => prereqs;
		public ComparisonType Comparator { get => comparator; set => comparator = value; }

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
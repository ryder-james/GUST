using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	[CreateAssetMenu(fileName = "NotPrereq", menuName = PrereqAssetMenuPrefix + "Not Prereq")]
	public class NotPrereq : Prereq {
		[SerializeField] private Prereq prereq = null;

		public Prereq Prereq { get => prereq; set => prereq = value; }

		public override bool IsMet(Character caster) {
			return !Prereq.IsMet(caster);
		}
	}
}
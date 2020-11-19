using GUST.Characters;

namespace GUST.Spells.Prereqs {
	public class NotPrereq : Prereq {
		public Prereq Prereq { get; set; }

		public override bool IsMet(Character caster) {
			return !Prereq.IsMet(caster);
		}
	}
}
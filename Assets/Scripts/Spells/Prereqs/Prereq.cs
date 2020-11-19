using GUST.Characters;

namespace GUST.Spells.Prereqs {
	public abstract class Prereq {
		public abstract bool IsMet(Character caster);
	}
}
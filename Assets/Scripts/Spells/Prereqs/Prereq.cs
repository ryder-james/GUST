using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	public abstract class Prereq : ScriptableObject {
		protected const string PrereqAssetMenuPrefix = "GUST/Prereqs/";

		public abstract bool IsMet(Character caster);
	}
}
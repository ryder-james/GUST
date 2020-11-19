using System.Collections.Generic;

using GUST.Characters;

namespace GUST.Spells {
	public class Spell {
		public string Name { get; set; }
		public string Description { get; set; }
		public string TechLevel { get; set; }
		public string PowerSource { get; set; }
		public string SpellClass { get; set; }
		public string PageRef { get; set; }
		public string Notes { get; set; }

		public Skill SpellSkill { get; }

		public bool IsResisted { get; set; }
		public Attribute ResistedBy { get; set; }

		public ShortenableString SpellCost { get; }
		public ShortenableString MaintenanceCost { get; }
		public ShortenableString CastingTime { get; }
		public ShortenableString Duration { get; }

		public EnchantmentInfo EnchantmentInfo { get; }

		public List<string> Colleges { get; }

		public Spell() {
			SpellSkill = new Skill();
			SpellCost = new ShortenableString();
			MaintenanceCost = new ShortenableString();
			CastingTime = new ShortenableString();
			Duration = new ShortenableString();
			EnchantmentInfo = new EnchantmentInfo();
			Colleges = new List<string>();
		}

		public bool AddCollege(string college) {
			if (!Colleges.Contains(college)) {
				Colleges.Add(college);
				return true;
			}

			return false;
		}

		public bool RemoveCollege(string college) {
			return Colleges.Remove(college);
		}
	}
}
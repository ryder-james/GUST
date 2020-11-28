using System.Collections.Generic;

using GUST.Spells;
using UnityEngine;

namespace GUST.Characters {
	public class Character : ScriptableObject {
		public HealthReserve HitPoints { get; }
		public FatigueReserve FatiguePoints { get; }
		public List<Reserve> EnergyReserves { get; }
		public Dictionary<Spell, int> Spells { get; }
		public List<Advantage> Advantages { get; }

		public Advantage MageryAdvantage { get; set; }
		public string Name { get; set; }

		private readonly Dictionary<Attribute, int> attributes;

		public int this[Attribute att] {
			get => attributes[att];
			set => attributes[att] = value;
		}

		public Character(string name) {
			Name = name;
			attributes = new Dictionary<Attribute, int>();
		}
	}
}
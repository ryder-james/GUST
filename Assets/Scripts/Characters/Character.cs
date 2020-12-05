using System.Collections.Generic;

using GUST.Spells;
using UnityEngine;

namespace GUST.Characters {
	public class Character : ScriptableObject {
		public struct SpellData {
			public int skillLevel;
			public string notes;
			public string relatedSkill;
		}

		public HealthReserve HitPoints { get; private set; }
		public FatigueReserve FatiguePoints { get; private set; }
		public List<Reserve> EnergyReserves { get; private set; }
		public Dictionary<Spell, SpellData> Spells { get; private set; }
		public List<Advantage> Advantages { get; private set; }

		public Advantage MageryAdvantage { get; set; }
		public string Name { get; set; }

		private readonly Dictionary<Attribute, int> attributes;

		public int this[Attribute att] {
			get => attributes[att];
			set => attributes[att] = value;
		}

		public Character(string name) {
			Name = name;

			HitPoints = new HealthReserve();
			FatiguePoints = new FatigueReserve();
			EnergyReserves = new List<Reserve>();
			Spells = new Dictionary<Spell, SpellData>();
			Advantages = new List<Advantage>();

			attributes = new Dictionary<Attribute, int> {
				[Attribute.ST] = 10,
				[Attribute.DX] = 10,
				[Attribute.IQ] = 10,
				[Attribute.HT] = 10,
				[Attribute.Will] = 10,
				[Attribute.Perception] = 10
			};
		}
	}
}
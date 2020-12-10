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
		public Reserve[] EnergyReserves => EnergyReserveList.ToArray();
		public Dictionary<Spell, SpellData> Spells { get; private set; }
		public List<Advantage> Advantages { get; private set; }

		public Advantage MageryAdvantage { get; set; }
		public string Name { get; set; }

		private List<Reserve> EnergyReserveList { get; set; }
		private Dictionary<Attribute, int> attributes;

		public int this[Attribute att] {
			get => attributes[att];
			set => attributes[att] = value;
		}

		public void Create(string name) {
			Name = name;

			HitPoints = new HealthReserve();
			FatiguePoints = new FatigueReserve();
			EnergyReserveList = new List<Reserve>();
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

		public Reserve AddReserve(string name) {
			Reserve newReserve = new Reserve(name, 10);
			EnergyReserveList.Add(newReserve);

			return newReserve;
		}

		public void RemoveReserve(int id) {
			Reserve toRemove = FindReserve(id);
			if (toRemove != null) {
				EnergyReserveList.Remove(toRemove);
			}
		}

		public void UpdateReserveName(string oldName, string newName) {
			Reserve toUpdate = FindReserve(oldName);
			if (toUpdate == null) {
				return;
			}

			toUpdate.Name = newName;
		}

		public void UpdateReserveValues(string name, int current, int basic = 0) {
			Reserve r = FindReserve(name);
			if (r == null) {
				return;
			}

			if (basic > 0) {
				r.Basic = basic;
			}

			r.Current = current;
		}

		public Reserve FindReserve(string name) {
			if (name == "Hit Points") {
				return HitPoints;
			} else if (name == "Fatigue Points") {
				return FatiguePoints;
			} else {
				foreach (Reserve r in EnergyReserveList) {
					if (r.Name == name) {
						return r;
					}
				}

				return null;
			}
		}

		public Reserve FindReserve(int id) {
			if (id == HitPoints.ID) {
				return HitPoints;
			} else if (id == FatiguePoints.ID) {
				return FatiguePoints;
			} else {
				foreach (Reserve r in EnergyReserveList) {
					if (r.ID == id) {
						return r;
					}
				}

				return null;
			}
		}
	}
}
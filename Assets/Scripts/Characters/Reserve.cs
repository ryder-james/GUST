using System.Collections.Generic;
using UnityEngine;

namespace GUST.Characters {
	public class Reserve {
		private static int count = 0;
		private int current, basic;

		public virtual string Name { get; set; }
		public int ID { get; }

		public int Current {
			get => current;
			set => current = Mathf.Min(value, Basic);
		}

		public int Basic {
			get => basic;
			set {
				basic = value;
				Current = Mathf.Min(Current, Basic);
			}
		}

		public Reserve() {
			Name = "";
			Basic = 10;
			Current = 10;
			ID = count++;
		}

		public Reserve(string name, int basic) {
			Name = name;
			Basic = basic;
			Current = basic;
			ID = count++;
		}

		public override bool Equals(object obj) {
			return obj is Reserve reserve &&
				   Name == reserve.Name;
		}

		public override int GetHashCode() {
			return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
		}
	}
}
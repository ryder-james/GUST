using System.Collections.Generic;
using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	public class AttributePrereq : Prereq {
		private int minAttributeSum;

		public List<Attribute> Attributes { get; }
		public int MinAttributeSum {
			get => minAttributeSum;
			set => minAttributeSum = Mathf.Max(0, value);
		}

		public AttributePrereq() {
			Attributes = new List<Attribute>();
		}

		public override bool IsMet(Character caster) {
			int sum = 0;

			foreach (Attribute attribute in Attributes) {
				sum += caster[attribute];
			}

			return sum >= minAttributeSum;
		}
	}
}
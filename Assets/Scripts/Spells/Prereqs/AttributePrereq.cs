using System.Collections.Generic;
using UnityEngine;

using GUST.Characters;

namespace GUST.Spells.Prereqs {
	[CreateAssetMenu(fileName = "AttributePrereq", menuName = PrereqAssetMenuPrefix + "Attribute")]
	public class AttributePrereq : Prereq {
		[SerializeField, Min(0)] private int minAttributeSum = 0;
		[SerializeField] private List<Attribute> attributes = new List<Attribute>();

		public List<Attribute> Attributes => attributes;
		public int MinAttributeSum {
			get => minAttributeSum;
			set => minAttributeSum = Mathf.Max(0, value);
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
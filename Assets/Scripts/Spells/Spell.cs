using System.Collections.Generic;
using UnityEngine;

using GUST.Characters;
using GUST.Spells.Prereqs;

namespace GUST.Spells {
	[CreateAssetMenu(fileName = "Spell", menuName = "GUST/Spell")]
	public class Spell : ScriptableObject {
		[SerializeField] private new string name = "";
		[SerializeField] private string description = "";
		[SerializeField] private string techLevel = "";
		[SerializeField] private string powerSource = "";
		[SerializeField] private string spellClass = "";
		[SerializeField] private string pageRef = "";
		[SerializeField] private string notes = "";

		[SerializeField] private bool isResisted = false;
		[SerializeField] private Attribute resistedBy = Attribute.HT;

		[SerializeField] private Skill spellSkill = null;

		[SerializeField] private ShortenableString spellCost = null;
		[SerializeField] private ShortenableString maintenanceCost = null;
		[SerializeField] private ShortenableString castingTime = null;
		[SerializeField] private ShortenableString duration = null;
		[SerializeField] private EnchantmentInfo enchantmentInfo = null;

		[SerializeField] private List<string> colleges = new List<string>();
		[SerializeField] private List<Prereq> prereqs = new List<Prereq>();

		public string Name { get => name; set => name = value; }
		public string Description { get => description; set => description = value; }
		public string TechLevel { get => techLevel; set => techLevel = value; }
		public string PowerSource { get => powerSource; set => powerSource = value; }
		public string SpellClass { get => spellClass; set => spellClass = value; }
		public string PageRef { get => pageRef; set => pageRef = value; }
		public string Notes { get => notes; set => notes = value; }

		public Skill SpellSkill { get => spellSkill; set => spellSkill = value; }

		public bool IsResisted { get => isResisted; set => isResisted = value; }
		public Attribute ResistedBy { get => resistedBy; set => resistedBy = value; }

		public ShortenableString SpellCost { get => spellCost; set => spellCost = value; }
		public ShortenableString MaintenanceCost { get => maintenanceCost; set => maintenanceCost = value; }
		public ShortenableString CastingTime { get => castingTime; set => castingTime = value; }
		public ShortenableString Duration { get => duration; set => duration = value; }

		public EnchantmentInfo EnchantmentInfo { get => enchantmentInfo; set => enchantmentInfo = value; }

		public List<string> Colleges => colleges;
		public List<Prereq> Prereqs => prereqs;

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

		public bool Clear()
        {
			bool answer = true;
			for(int i = 0; i < Colleges.Count;)
			{
				if (!RemoveCollege(Colleges[i]))
                {
					answer = false;
                }
            }
			return answer;
        }

		public string GetCollegesString()
        {
			string answer = "";
			for (int i = 0; i < Colleges.Count; i++)
			{
				if (i + 1 < Colleges.Count)
                {
					answer += Colleges[i] + ", ";
                }
                else
                {
					answer += Colleges[i];
				}
			}
			return answer;
		}

	}
}
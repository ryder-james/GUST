using UnityEngine;

namespace GUST.Characters {
	public class Skill : ScriptableObject {
		[SerializeField] private int points = 0;
		[SerializeField] private Attribute attribute = Attribute.IQ;
		[SerializeField] private SkillDifficulty difficulty = SkillDifficulty.Hard;

		public int Points { get => points; set => points = value; }
		public Attribute Attribute { get => attribute; set => attribute = value; }
		public SkillDifficulty Difficulty { get => difficulty; set => difficulty = value; }

		public string RelativeSkillLevel {
			get {
				int rsl = GetRSLValue();
				string attString = Attribute.ToString().Replace('_', ' ');
				string rslString = rsl >= 0 ? "+" : "";
				return $"{attString}{rslString}{rsl}";
			}
		}

		public int GetLevel(int attributeValue) {
			return attributeValue + GetRSLValue();
		}

		private int GetRSLValue() {
			if (Points == 1) {
				return -(int) Difficulty;
			} else if (Points < 4) {
				return 1 - (int) Difficulty;
			} else {
				return (Points / 4) + (1 - (int) Difficulty);
			}
		}
	}
}
using UnityEngine;

namespace GUST.Characters {
	[CreateAssetMenu(fileName = "SkillDifficulty", menuName = "GUST/Skill Difficulty")]
	public class Skill : ScriptableObject {
		[SerializeField] private Attribute attribute = Attribute.IQ;
		[SerializeField] private SkillDifficulty difficulty = SkillDifficulty.Hard;

		public Attribute Attribute { get => attribute; set => attribute = value; }
		public SkillDifficulty Difficulty { get => difficulty; set => difficulty = value; }

		public string GetRelativeSkillLevel(int points) {
			int rsl = GetRSLValue(points);
			string attString = Attribute.ToString().Replace('_', ' ');
			string rslString = rsl >= 0 ? "+" : "";
			return $"{attString}{rslString}{rsl}";
		}

		public int GetLevel(int points, int attributeValue) {
			return attributeValue + GetRSLValue(points);
		}

		private int GetRSLValue(int points) {
			if (points == 1) {
				return -(int) Difficulty;
			} else if (points < 4) {
				return 1 - (int) Difficulty;
			} else {
				return (points / 4) + (1 - (int) Difficulty);
			}
		}
	}
}
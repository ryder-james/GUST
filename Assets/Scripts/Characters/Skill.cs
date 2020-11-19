namespace GUST.Characters {
	public class Skill {
		public int Points { get; set; }
		public Attribute Attribute { get; set; }
		public SkillDifficulty Difficulty { get; set; }

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
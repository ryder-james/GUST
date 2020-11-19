namespace GUST.Characters {
	public class Advantage {
		public string Name { get; set; } = "";
		public string Specialization { get; set; } = "";
		public int Level { get; set; } = 0;

		public bool HasLevels => Level > 0;
	}
}


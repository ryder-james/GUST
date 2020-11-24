using UnityEngine;

namespace GUST.Spells {
	[CreateAssetMenu(fileName = "ShortenableString", menuName = "GUST/Shortenable String")]
	public class ShortenableString : ScriptableObject {
		[SerializeField] private string shortString;
		[SerializeField] private string detailedString;

		public string ShortString { get => shortString; set => shortString = value; }
		public string DetailedString { get => detailedString; set => detailedString = value; }
	}
}
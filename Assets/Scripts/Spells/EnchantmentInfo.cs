using UnityEngine;

namespace GUST.Spells {
	[CreateAssetMenu(fileName = "EnchantmentInfo", menuName = "GUST/Enchantment Info")]
	public class EnchantmentInfo : ScriptableObject {
		[SerializeField, TextArea] private string details = "";
		[SerializeField] private string cost = "";

		public string Details { get => details; set => details = value; }
		public string Cost { get => cost; set => cost = value; }
	}
}
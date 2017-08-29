namespace MagicPurse.Models
{
	public class Coin
	{
		public CoinType Type { get; set; }
		public int Amount { get; set; }
		public bool Splittable { get; set; }
	}
}
namespace MagicPurse.Models
{
	public class Money
	{
		private int Pound { get; set; }
		private int Penny { get; set; }
		private int Shilling { get; set; }

		public Money()
		{
		}

		public Money(int pound, int shilling, int penny)
		{
			this.Pound = pound;
			this.Penny = penny;
			this.Shilling = shilling;
		}

		public Money AddShiling(int amount)
		{
			this.Shilling += amount;
			return this;
		}

		public Money AddPence(int amount)
		{
			this.Penny += amount;
			return this;
		}

		public Money AddPound(int amount)
		{
			this.Pound += amount;
			return this;
		}

		public int GetTotalPence()
		{
			// change this?
			return Pound * 20 * 12 + Shilling * 12 + Penny;
		}
	}
}
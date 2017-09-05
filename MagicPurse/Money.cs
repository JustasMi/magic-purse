namespace MagicPurse
{
	public class Money
	{
		public int Pound { get; private set; }
		public int Pence { get; private set; }
		public int Shilling { get; private set; }

		public Money()
		{
		}

		public Money(int pound, int shilling, int pence)
		{
			this.Pound = pound;
			this.Pence = pence;
			this.Shilling = shilling;
		}

		public Money AddShiling(int amount)
		{
			this.Shilling += amount;
			return this;
		}

		public Money AddPence(int amount)
		{
			this.Pence += amount;
			return this;
		}

		public Money AddPound(int amount)
		{
			this.Pound += amount;
			return this;
		}

		public int GetTotalPence()
		{
			return Pound * 20 * 12 + Shilling * 12 + Pence;
		}
	}
}
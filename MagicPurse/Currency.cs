namespace MagicPurse
{
	public class Currency
	{
		public int Pound { get; private set; }
		public int Pence { get; private set; }
		public int Shilling { get; private set; }

		public Currency()
		{
		}

		public Currency(int pound, int shilling, int pence)
		{
			this.Pound = pound;
			this.Pence = pence;
			this.Shilling = shilling;
		}

		public Currency AddShiling(int amount)
		{
			this.Shilling += amount;
			return this;
		}

		public Currency AddPence(int amount)
		{
			this.Pence += amount;
			return this;
		}

		public Currency AddPound(int amount)
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
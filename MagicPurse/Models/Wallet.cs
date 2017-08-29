using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPurse.Models
{
	public class Wallet
	{
		private int Pound { get; set; }
		private int Penny { get; set; }
		private int Shilling { get; set; }

		public Wallet()
		{
		}

		public Wallet(int pound, int shilling, int penny)
		{
			this.Pound = pound;
			this.Penny = penny;
			this.Shilling = shilling;
		}

		public Wallet AddShiling(int amount)
		{
			this.Shilling += amount;
			return this;
		}

		public Wallet AddPeny(int amount)
		{
			this.Penny += amount;
			return this;
		}

		public Wallet AddPound(int amount)
		{
			this.Pound += amount;
			return this;
		}

		public int GetTotalPence()
		{
			return Pound * 20 * 12 + Shilling * 12 + Penny;
		}
	}
}
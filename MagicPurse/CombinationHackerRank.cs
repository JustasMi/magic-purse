using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPurse
{
	public class CombinationHackerRank
	{
		public long Run()
		{
			var coins = new int[] { 1, 2, 6, 12, 24, 48, 60 };
			int money = 2400;
			return MakeChange(coins, money, 0, new Dictionary<string, long>());
		}

		private long MakeChange(int[] coins, int money, int index, Dictionary<string, long> memo)
		{
			if (money == 0)
			{
				return 1;
			}
			if (index >= coins.Length)
			{
				return 0;
			}
			string key = money + "-" + index;
			if (memo.ContainsKey(key))
			{
				return memo[key];
			}
			int amountWithCoin = 0;
			long ways = 0;
			while (amountWithCoin <= money)
			{
				int remaining = money - amountWithCoin;
				ways += MakeChange(coins, remaining, index + 1, memo);
				amountWithCoin += coins[index];
			}
			memo[key] = ways;
			return ways;
		}
	}
}
using System.Collections.Generic;
using System.Linq;

namespace MagicPurse
{
	public class PossibilityCalculator
	{
		public PossibilityCalculator()
		{
		}

		public long CalculatePossibilities(List<List<int>> variations)
		{
			long count = 0;

			variations.ForEach(item =>
			{
				if (item.Count % 2 == 0)
				{
					DoStuff(item, 0, item.Distinct().ToArray(), 0, ref count);
				}
			});
			return count;
		}

		private void DoStuff(List<int> variation, int denominationIndex, int[] denominations, int coinAmount, ref long result)
		{
			// Check if no more denominations left, and check validity of path
			if (denominationIndex + 1 == denominations.Count())
			{
				// check how many coins are needed
				var requiredCoins = variation.Count() / 2;
				// check if we have enough coins
				bool goodPath = (requiredCoins - coinAmount) <= variation.Where(item => item == denominations[denominationIndex]).Count();
				if (goodPath)
				{
					result += 1;
				}
			}
			else
			{
				int totalCoins = variation
					.Where(item => item == denominations[denominationIndex])
					.Count();

				int maxCoins = variation.Count() / 2;
				// if there is enough coins dont look further
				if (coinAmount == maxCoins)
				{
					result += 1;
				}
				else
				{
					for (int i = 0; i <= totalCoins && i + coinAmount <= maxCoins; i++)
					{
						DoStuff(variation, denominationIndex + 1, denominations, coinAmount + i, ref result);
					}
				}
			}
		}
	}
}
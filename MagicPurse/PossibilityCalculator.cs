using MagicPurse.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MagicPurse
{
	public class PossibilityCalculator : IPossibilityCalculator
	{
		public long Calculate(List<List<double>> combinations)
		{
			long count = 0;

			combinations.ForEach(item =>
			{
				CalculatePossibilities(item, 0, item.Distinct().ToArray(), 0, ref count);
			});
			return count;
		}

		private void CalculatePossibilities(List<double> variation, int denominationIndex, double[] denominations, int currentCointCount, ref long result)
		{
			// Divided by two because we only need to figure out a combination for one person, the other gets the rest
			int requiredCoinCount = variation.Count() / 2;
			// Check if this is the last denomination
			if (denominationIndex + 1 == denominations.Count())
			{
				bool isEnoughCoins = (requiredCoinCount - currentCointCount) <= variation.Where(item => item == denominations[denominationIndex]).Count();
				if (isEnoughCoins)
				{
					result += 1;
				}
			}
			else
			{
				int totalCoins = variation
					.Where(item => item == denominations[denominationIndex])
					.Count();

				if (currentCointCount == requiredCoinCount)
				{
					result += 1;
				}
				else
				{
					for (int i = 0; i <= totalCoins && i + currentCointCount <= requiredCoinCount; i++)
					{
						CalculatePossibilities(variation, denominationIndex + 1, denominations, currentCointCount + i, ref result);
					}
				}
			}
		}
	}
}
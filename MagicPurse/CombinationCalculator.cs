using MagicPurse.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MagicPurse
{
	public class CombinationCalculator : ICombinationCalculator
	{
		private double[] denominations;

		public CombinationCalculator(ICoinSettings coinSettings)
		{
			denominations = coinSettings.Coins
				.Select(coin => coin.Value)
				.OrderBy(value => value)
				.ToArray();
		}

		public List<List<double>> Calculate(Currency currency)
		{
			List<List<double>> result = new List<List<double>>();
			this.RunAlgorithm(new List<double>(), 0, currency.GetTotalPence(), result);
			return result;
		}

		private void RunAlgorithm(IEnumerable<double> currentSolution, int denominationIndex, double remainingTarget, List<List<double>> result)
		{
			for (int i = denominationIndex; i < denominations.Length; i++)
			{
				double totalValueSum = remainingTarget - denominations[i];

				if (totalValueSum < 0)
				{
					break;
				}

				List<double> solution = currentSolution.ToList();
				solution.Add(denominations[i]);

				if (totalValueSum == 0)
				{
					if (solution.Count % 2 == 0)
					{
						result.Add(solution);
					}
					break;
				}
				else
				{
					RunAlgorithm(solution, i, totalValueSum, result);
				}
			}
		}
	}
}
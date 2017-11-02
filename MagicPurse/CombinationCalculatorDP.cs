using MagicPurse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPurse
{
	public class Solution
	{
		public int HalfCrown { get; set; } = 0;
		public int Florin { get; set; } = 0;
		public int Shilling { get; set; } = 0;
		public int Sixpence { get; set; } = 0;
		public int Threepence { get; set; } = 0;
		public int Penny { get; set; } = 0;
		public int Halfpenny { get; set; } = 0;

		public override int GetHashCode()
		{
			int prime = 92821;
			return Halfpenny.GetHashCode() * prime + Penny.GetHashCode() * prime + Threepence.GetHashCode() * prime + Sixpence.GetHashCode() * prime + Shilling.GetHashCode() * prime + Florin.GetHashCode() * prime + HalfCrown.GetHashCode() * prime;
		}

		public override bool Equals(object o)
		{
			var obj = o as Solution;
			return obj != null && this.Halfpenny == obj.Halfpenny
				&& this.Penny == obj.Penny && this.Threepence == obj.Threepence
				&& this.Sixpence == obj.Sixpence && this.Shilling == obj.Shilling
				&& this.Florin == obj.Florin && this.HalfCrown == obj.HalfCrown;
		}
	}

	public class CombinationCalculatorDP
	{
		private double[] denominations;

		public CombinationCalculatorDP(ICoinSettings coinSettings)
		{
			denominations = coinSettings.Coins
				.Select(coin => coin.Value)
				.OrderBy(value => value)
				.ToArray();
		}

		public List<List<double>> Calculate(Currency currency)
		{
			List<List<double>> result = new List<List<double>>();
			RunAlgorithm(currency.GetTotalPence());
			//this.RunAlgorithm(new List<double>(), 0, currency.GetTotalPence(), result);
			return result;
		}

		private void RunAlgorithm(double target)
		{
			var memo = new Dictionary<double, HashSet<Solution>>();
			memo.Add(0.5, new HashSet<Solution>() { new Solution() { Halfpenny = 1 } });
			for (double i = 1; i <= target; i += 0.5)
			{
				var memoIndex = i % 80;
				memo[memoIndex] = new HashSet<Solution>();
				//memo.Add(memoIndex, new HashSet<Solution>());
				foreach (double denom in denominations)
				{
					var changeLeft = i - denom;

					if (changeLeft < 0)
					{
						break;
					}

					if (changeLeft == 0)
					{
						memo[memoIndex].Add(GetSolForDenom(denom, new Solution()));
						continue;
					}

					foreach (Solution s in memo[changeLeft % 80])
					{
						memo[memoIndex].Add(GetSolForDenom(denom, s));
					}
				}
			}

			var result = memo[target % 80].Count();
		}

		/*
		private Solution GetSolution(double denom)
		{
			if (denom == 0.5)
			{
				return new Solution() { Halfpenny = 1 };
			}
			else if (denom == 1)
			{
				return new Solution() { Penny = 1 };
			}
			else if (denom == 3)
			{
				return new Solution() { Threepence = 1 };
			}

			return new Solution();
		}
		*/

		private Solution GetSolForDenom(double denom, Solution current)
		{
			var newSolution = new Solution();
			newSolution.Halfpenny = current.Halfpenny;
			newSolution.Penny = current.Penny;
			newSolution.Threepence = current.Threepence;
			newSolution.Sixpence = current.Sixpence;
			newSolution.Shilling = current.Shilling;
			newSolution.Florin = current.Florin;
			newSolution.HalfCrown = current.HalfCrown;

			if (denom == 0.5)
			{
				newSolution.Halfpenny += 1;
			}
			else if (denom == 1)
			{
				newSolution.Penny += 1;
			}
			else if (denom == 3)
			{
				newSolution.Threepence += 1;
			}
			else if (denom == 6)
			{
				newSolution.Sixpence += 1;
			}
			else if (denom == 12)
			{
				newSolution.Shilling += 1;
			}
			else if (denom == 24)
			{
				newSolution.Florin += 1;
			}
			else if (denom == 30)
			{
				newSolution.HalfCrown += 1;
			}
			return newSolution;
		}

		/*
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
		*/
	}
}
using MagicPurse.Models;
using System.Collections.Generic;
using System.Linq;

namespace MagicPurse
{
	public class VariationCalculator
	{
		public int[] denominations = { 1, 2, 6, 12, 24, 48, 60 };

		public VariationCalculator()
		{
			//List<List<int>> result = new List<List<int>>();
			//this.RunAlgorithm(new List<int>(), 0, 6, result);
		}

		public List<List<int>> Calculate(Money money)
		{
			List<List<int>> result = new List<List<int>>();
			// make it clear why *2 or find alternate solution
			this.RunAlgorithm(new List<int>(), 0, money.GetTotalPence() * 2, result);
			return result;
		}

		private void RunAlgorithm(IEnumerable<int> currentSolution, int index, int remainingTarget, List<List<int>> result)
		{
			for (int i = index; i < denominations.Length; i++)
			{
				int temp = remainingTarget - denominations[i];
				//string tempSoln = currentSolution + "" + answer.denoms[i] + ",";
				List<int> tempSoln = currentSolution.ToList();
				tempSoln.Add(denominations[i]);

				if (temp < 0)
				{
					break;
				}

				if (temp == 0)
				{
					// reached the answer hence quit from the loop
					result.Add(tempSoln);
					break;
				}
				else
				{
					// target not reached, try the solution recursively with the
					// current denomination as the start point.
					RunAlgorithm(tempSoln, i, temp, result);
				}
			}
		}

		/*
		 * 		public class CoinChangeAnswer
		{
			//public int[] denoms = { 1, 2, 6, 12, 24, 48, 60 };

			//public List<string> allPossibleChanges = new List<string>();
			public List<List<int>> allPossibleChanges = new List<List<int>>();
		}
		 *
		public void RunAlgorithm(string currentSolution, int index, int remainingTarget, CoinChangeAnswer answer)
		{
			for (int i = index; i < answer.denoms.Length; i++)
			{
				int temp = remainingTarget - answer.denoms[i];
				string tempSoln = currentSolution + "" + answer.denoms[i] + ",";

				if (temp < 0)
				{
					break;
				}

				if (temp == 0)
				{
					// reached the answer hence quit from the loop
					answer.allPossibleChanges.Add(tempSoln);
					break;
				}
				else
				{
					// target not reached, try the solution recursively with the
					// current denomination as the start point.
					RunAlgorithm(tempSoln, i, temp, answer);
				}
			}
		}
		*/
	}
}
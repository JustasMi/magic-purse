using MagicPurse.Extensions;
using MagicPurse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicPurse
{
	public class Algorithm
	{
		private CoinPurse coinPurse;
		private CoinExchange coinExchange;

		public Algorithm(CoinPurse coinPurse)
		{
			this.coinPurse = coinPurse;
			this.coinExchange = new CoinExchange();
			var results = new CoinChangeAnswer();
			this.RunAlgorithm("", 0, 6, results);
		}

		/*
		public int GetCombinations()
		{
			var coins = coinPurse.coins.Select(pair => new Coin()
			{
				Amount = pair.Value,
				Splittable = pair.Key != CoinType.Halfpenny,
				Type = pair.Key
			});
			int combinations = 0;
			Calculate(coins, ref combinations);
			return combinations;
		}
		*/

		public class CoinChangeAnswer
		{
			public int[] denoms = { 1, 2, 6, 12, 24, 48, 60 };
			public List<string> allPossibleChanges = new List<string>();
		}

		public void RunAlgorithm(string currentSolution, int index, int remainingTarget, CoinChangeAnswer answer)
		{
			for (int i = index; i < answer.denoms.Length; i++)
			{
				int temp = remainingTarget - answer.denoms[i];
				String tempSoln = currentSolution + "" + answer.denoms[i] + ",";

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
	}
}
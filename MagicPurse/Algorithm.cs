using MagicPurse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}

		public int GetCombinations()
		{
			var coins = coinPurse.coins.Select(pair => new Coin()
			{
				Amount = pair.Value,
				Splittable = pair.Key != CoinType.Halfpenny,
				Type = pair.Key
			});
			Calculate(coins);
			return 0;
		}

		private int Calculate(IEnumerable<Coin> coins)
		{
			var coinSum = coins.Sum(coin => coin.Amount);
			if (coinSum % 2 == 0 && coinSum != 0)
			{
				Console.WriteLine("Possible to share!" + coinSum);
			}

			var splittable = coins.Count(coin => coin.Splittable);
			if (splittable == 0)
			{
				return 0;
			}

			// continue search
			bool multiplePaths = splittable > 1;
			coins.Where(coin => coin.Splittable).ToList().ForEach(coin =>
			{
				var newList = coins.ToList();
				var selectedCoin = newList.Find(sc => sc.Splittable && sc.Type == coin.Type);
				newList.Remove(selectedCoin);
				coinExchange.ExchangeCoins()
				var coinToSplit = newList.Find(c => c.Type == coin.Type);
			});

			//coins.coins[0]
			return 0;
		}
	}
}
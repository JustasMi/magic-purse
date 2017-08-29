using MagicPurse.Models;
using System;
using System.Collections.Generic;

namespace MagicPurse
{
	public class CoinExchange
	{
		private Dictionary<CoinType, double> coinWeights = new Dictionary<CoinType, double>();

		public CoinExchange()
		{
			coinWeights.Add(CoinType.HalfCrown, 30);
			coinWeights.Add(CoinType.Florin, 24);
			coinWeights.Add(CoinType.Shilling, 12);
			coinWeights.Add(CoinType.Sixpence, 6);
			coinWeights.Add(CoinType.Threepence, 3);
			coinWeights.Add(CoinType.Penny, 1);
			coinWeights.Add(CoinType.Halfpenny, 0.5);
		}

		public Coin ExchangeCoins(Coin inputCoin, CoinType targetType)
		{
			if (inputCoin.Type == CoinType.Halfpenny)
			{
				throw new Exception("Cannot exchange half pennies");
			}

			var pence = (inputCoin.Amount * coinWeights[inputCoin.Type]);

			return new Coin()
			{
				Splittable = targetType != CoinType.Halfpenny,
				Amount = (int)(pence / coinWeights[targetType]),
				Type = targetType
			};
		}
	}
}
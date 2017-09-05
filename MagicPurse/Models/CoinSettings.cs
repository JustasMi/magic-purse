using MagicPurse.Interfaces;
using System.Collections.Generic;

namespace MagicPurse.Models
{
	public class CoinSettings : ICoinSettings
	{
		public Dictionary<CoinType, double> Coins { get; }

		public CoinSettings()
		{
			Coins = new Dictionary<CoinType, double>();
			Coins.Add(CoinType.HalfCrown, 30);
			Coins.Add(CoinType.Florin, 24);
			Coins.Add(CoinType.Shilling, 12);
			Coins.Add(CoinType.Sixpence, 6);
			Coins.Add(CoinType.Threepence, 3);
			Coins.Add(CoinType.Penny, 1);
			Coins.Add(CoinType.Halfpenny, 0.5);
		}
	}
}
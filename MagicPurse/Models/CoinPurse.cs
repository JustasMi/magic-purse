using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPurse.Models
{
	public class CoinPurse
	{
		public Dictionary<CoinType, int> coins = new Dictionary<CoinType, int>();
		public Dictionary<CoinType, double> coinWeights = new Dictionary<CoinType, double>();

		public CoinPurse()
		{
			coinWeights.Add(CoinType.HalfCrown, 30);
			coinWeights.Add(CoinType.Florin, 24);
			coinWeights.Add(CoinType.Shilling, 12);
			coinWeights.Add(CoinType.Sixpence, 6);
			coinWeights.Add(CoinType.Threepence, 3);
			coinWeights.Add(CoinType.Penny, 1);
			coinWeights.Add(CoinType.Halfpenny, 0.5);
		}

		public void Initialise(int pence)
		{
			coins[CoinType.Threepence] = (int)((double)pence / coinWeights[CoinType.Threepence]);
		}
	}
}
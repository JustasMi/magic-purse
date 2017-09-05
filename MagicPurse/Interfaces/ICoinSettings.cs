using MagicPurse.Models;
using System.Collections.Generic;

namespace MagicPurse.Interfaces
{
	public interface ICoinSettings
	{
		Dictionary<CoinType, double> Coins { get; }
	}
}
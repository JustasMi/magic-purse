using MagicPurse.Extensions;
using MagicPurse.Interfaces;
using System;
using System.Linq;

namespace MagicPurse.Factories
{
	public class MoneyFactory : IMoneyFactory
	{
		public Money Build(string money)
		{
			string[] collection = money.Split('/');

			if (collection.Length == 1)
			{
				collection[0] = collection[0].TrimEnd('d');
			}

			int[] moneyCollection = collection
				.Select(value => value.ToIntOrDefault())
				.ToArray();

			if (moneyCollection.Any(value => value < 0))
			{
				throw new ArgumentException("money");
			}

			Money result = new Money();
			if (moneyCollection.Length == 1)
			{
				result.AddPence(moneyCollection[0]);
			}
			else if (moneyCollection.Length == 2)
			{
				result
					.AddShiling(moneyCollection[0])
					.AddPence(moneyCollection[1]);
			}
			else if (moneyCollection.Length == 3)
			{
				result
					.AddPound(moneyCollection[0])
					.AddShiling(moneyCollection[1])
					.AddPence(moneyCollection[2]);
			}
			return result;
		}
	}
}
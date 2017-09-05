using MagicPurse.Extensions;
using MagicPurse.Interfaces;

namespace MagicPurse.Factories
{
	public class MoneyFactory : IMoneyFactory
	{
		public Money Build(string money)
		{
			Money result = new Money();
			string[] moneyCollection = money.Split('/');
			if (moneyCollection.Length == 1)
			{
				result.AddPence(moneyCollection[0].TrimEnd('d').ToIntOrDefault());
			}
			else if (moneyCollection.Length == 2)
			{
				result
					.AddShiling(moneyCollection[0].ToIntOrDefault())
					.AddPence(moneyCollection[1].ToIntOrDefault());
			}
			else if (moneyCollection.Length == 3)
			{
				result
					.AddPound(moneyCollection[0].ToIntOrDefault())
					.AddShiling(moneyCollection[1].ToIntOrDefault())
					.AddPence(moneyCollection[2].ToIntOrDefault());
			}
			return result;
		}
	}
}
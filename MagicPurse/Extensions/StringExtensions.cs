using MagicPurse.Models;

namespace MagicPurse.Extensions
{
	public static class StringExtensions
	{
		public static Wallet ParseMoney(this string value)
		{
			var result = new Wallet();
			var moneyArray = value.Split('/');
			if (moneyArray.Length == 1)
			{
				result.AddPeny(moneyArray[0].TrimEnd('d').ToIntOrDefault());
			}
			else if (moneyArray.Length == 2)
			{
				result
					.AddShiling(moneyArray[0].ToIntOrDefault())
					.AddPeny(moneyArray[1].ToIntOrDefault());
			}
			else if (moneyArray.Length == 3)
			{
				result
					.AddShiling(moneyArray[0].ToIntOrDefault())
					.AddPound(moneyArray[1].ToIntOrDefault())
					.AddPeny(moneyArray[2].ToIntOrDefault());
			}
			return result;
		}

		// Maybe uint?
		public static int ToIntOrDefault(this string value)
		{
			int result;
			if (int.TryParse(value, out result))
			{
				return result;
			}
			return default(int);
		}
	}
}
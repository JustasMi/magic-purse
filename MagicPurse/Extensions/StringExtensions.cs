using MagicPurse.Models;

namespace MagicPurse.Extensions
{
	public static class StringExtensions
	{
		public static Money ParseMoney(this string value)
		{
			var result = new Money();
			var moneyArray = value.Split('/');
			if (moneyArray.Length == 1)
			{
				result.AddPence(moneyArray[0].TrimEnd('d').ToIntOrDefault());
			}
			else if (moneyArray.Length == 2)
			{
				result
					.AddShiling(moneyArray[0].ToIntOrDefault())
					.AddPence(moneyArray[1].ToIntOrDefault());
			}
			else if (moneyArray.Length == 3)
			{
				result
					.AddPound(moneyArray[0].ToIntOrDefault())
					.AddShiling(moneyArray[1].ToIntOrDefault())
					.AddPence(moneyArray[2].ToIntOrDefault());
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
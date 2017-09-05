namespace MagicPurse.Extensions
{
	public static class StringExtensions
	{
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
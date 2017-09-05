using MagicPurse.Factories;
using NUnit.Framework;

namespace MagicPurse.Tests
{
	[TestFixture(Category = "Factory", Description = "CurrencyFactory")]
	public class CurrencyFactoryTests
	{
		[Test(Description = "Test converting string input into Currency object")]
		[TestCase("3d", 3)]
		[TestCase("15d", 15)]
		[TestCase("1/-", 12)]
		[TestCase("1/-/5", 245)]
		[TestCase("3/2/-", 744)]
		public void CurrencyFactoryTest(string input, int expectedPenceSum)
		{
			CurrencyFactory currencyFactory = new CurrencyFactory();
			var result = currencyFactory.Build(input);
			Assert.AreEqual(expectedPenceSum, result.GetTotalPence());
		}
	}
}
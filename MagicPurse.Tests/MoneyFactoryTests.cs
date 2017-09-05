using MagicPurse.Factories;
using NUnit.Framework;

namespace MagicPurse.Tests
{
	[TestFixture(Category = "Factory", Description = "MoneyFactory")]
	public class MoneyFactoryTests
	{
		[Test(Description = "Test converting string input into Money object")]
		[TestCase("3d", 3)]
		[TestCase("15d", 15)]
		[TestCase("1/-", 12)]
		[TestCase("1/-/5", 245)]
		[TestCase("3/2/-", 744)]
		public void MoneyFactoryTest(string input, int expectedPenceSum)
		{
			MoneyFactory moneyFactory = new MoneyFactory();
			var result = moneyFactory.Build(input);
			Assert.AreEqual(expectedPenceSum, result.GetTotalPence());
		}
	}
}
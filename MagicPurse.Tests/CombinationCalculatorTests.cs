using MagicPurse.Models;
using NUnit.Framework;

namespace MagicPurse.Tests
{
	[TestFixture(Category = "Calculator", Description = "CombinationCalculator")]
	public class CombinationCalculatorTests
	{
		private CombinationCalculator combinationCalculator;

		[SetUp]
		public void SetupBeforeEachTest()
		{
			combinationCalculator = new CombinationCalculator(new CoinSettings());
		}

		[Test(Description = "Calculate even coin count combinations for 3 pence")]
		public void TestCombinationsForThreePence()
		{
			Currency currency = new Currency().AddPence(3);
			var result = combinationCalculator.Calculate(currency);
			Assert.AreEqual(2, result.Count);
		}

		[Test(Description = "Calculate even coin count combinations for 6 pence")]
		public void TestCombinationsForSixPence()
		{
			Currency currency = new Currency().AddPence(6);
			var result = combinationCalculator.Calculate(currency);
			Assert.AreEqual(7, result.Count);
		}

		[Test(Description = "Calculate even coin count combinations for 1 shilling")]
		public void TestCombinationsForOneShilling()
		{
			Currency currency = new Currency().AddShiling(1);
			var result = combinationCalculator.Calculate(currency);
			Assert.AreEqual(25, result.Count);
		}
	}
}
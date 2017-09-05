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
			Money money = new Money().AddPence(3);
			var result = combinationCalculator.Calculate(money);
			Assert.AreEqual(2, result.Count);
		}

		[Test(Description = "Calculate even coin count combinations for 6 pence")]
		public void TestCombinationsForSixPence()
		{
			Money money = new Money().AddPence(6);
			var result = combinationCalculator.Calculate(money);
			Assert.AreEqual(7, result.Count);
		}

		[Test(Description = "Calculate even coin count combinations for 1 shilling")]
		public void TestCombinationsForOneShilling()
		{
			Money money = new Money().AddShiling(1);
			var result = combinationCalculator.Calculate(money);
			Assert.AreEqual(25, result.Count);
		}
	}
}
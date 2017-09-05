using NUnit.Framework;
using System.Collections.Generic;

namespace MagicPurse.Tests
{
	[TestFixture(Category = "Calculator", Description = "PossibilityCalculator")]
	public class PossibilityCalculatorTests
	{
		private PossibilityCalculator possibilityCalculator;

		[SetUp]
		public void SetupBeforeEachTest()
		{
			possibilityCalculator = new PossibilityCalculator();
		}

		[Test(Description = "Calculate possibilities of splitting money of two half pennies and two pennies")]
		public void TestCombinationsForThreePence()
		{
			List<List<double>> input = new List<List<double>>();
			input.Add(new List<double>() { 1, 0.5, 0.5, 1 });
			long possibilityCount = possibilityCalculator.Calculate(input);
			Assert.AreEqual(3, possibilityCount);
		}
	}
}
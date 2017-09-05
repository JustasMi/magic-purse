using MagicPurse.Interfaces;
using System;
using System.Collections.Generic;

namespace MagicPurse
{
	public class Application : IApplication
	{
		private readonly ICombinationCalculator variationCalculator;
		private readonly IPossibilityCalculator possibilityCalculator;
		private readonly IMoneyFactory moneyFactory;

		public Application(
			ICombinationCalculator variationCalculator,
			IPossibilityCalculator possibilityCalculator,
			IMoneyFactory moneyFactory)
		{
			this.variationCalculator = variationCalculator;
			this.possibilityCalculator = possibilityCalculator;
			this.moneyFactory = moneyFactory;
		}

		public void Run()
		{
			Console.WriteLine("Please enter amount of old British currency for magic purse calculation");
			string input = Console.ReadLine();
			Money money = moneyFactory.Build(input);
			List<List<double>> combinations = variationCalculator.Calculate(money);
			long possibilityCount = possibilityCalculator.Calculate(combinations);
			Console.WriteLine($"Grandmother can divide the money between two children in {possibilityCount} ways");
			Console.ReadKey();
		}
	}
}
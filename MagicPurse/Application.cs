using MagicPurse.Interfaces;
using System;
using System.Collections.Generic;

namespace MagicPurse
{
	public class Application : IApplication
	{
		private readonly ICombinationCalculator combinationCalculator;
		private readonly IPossibilityCalculator possibilityCalculator;
		private readonly IMoneyFactory moneyFactory;

		public Application(
			ICombinationCalculator combinationCalculator,
			IPossibilityCalculator possibilityCalculator,
			IMoneyFactory moneyFactory)
		{
			this.combinationCalculator = combinationCalculator;
			this.possibilityCalculator = possibilityCalculator;
			this.moneyFactory = moneyFactory;
		}

		public void Run()
		{
			try
			{
				Console.WriteLine("Please enter amount of old British currency for magic purse calculation");
				string input = Console.ReadLine();
				Money money = moneyFactory.Build(input);
				List<List<double>> combinations = combinationCalculator.Calculate(money);
				long possibilityCount = possibilityCalculator.Calculate(combinations);
				Console.WriteLine($"Grandmother can divide the money between two children in {possibilityCount} ways");
				Console.ReadKey();
			}
			catch (ArgumentException exception)
			{
				Console.WriteLine($"Invalid argument: { exception.Message}");
				Console.ReadKey();
			}
		}
	}
}
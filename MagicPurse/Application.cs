using MagicPurse.Extensions;
using MagicPurse.Models;
using System;
using System.Collections.Generic;

namespace MagicPurse
{
	public class Application
	{
		public static void Run()
		{
			VariationCalculator variationCalculator = new VariationCalculator();
			PossibilityCalculator posssibilityCalculator = new PossibilityCalculator();

			Console.WriteLine("Please enter amount of old British currency for magic purse calculation");
			string input = Console.ReadLine();
			Money money = input.ParseMoney();
			List<List<int>> variations = variationCalculator.Calculate(money);
			long finalResult = posssibilityCalculator.CalculatePossibilities(variations);
			Console.WriteLine($"Grandmother can divide the money between two children in {finalResult} ways");
			Console.ReadKey();
		}
	}
}
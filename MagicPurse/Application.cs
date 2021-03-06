﻿using MagicPurse.Interfaces;
using MagicPurse.Models;
using System;
using System.Collections.Generic;

namespace MagicPurse
{
	public class Application : IApplication
	{
		private readonly ICombinationCalculator combinationCalculator;
		private readonly IPossibilityCalculator possibilityCalculator;
		private readonly ICurrencyFactory currencyFactory;

		public Application(
			ICombinationCalculator combinationCalculator,
			IPossibilityCalculator possibilityCalculator,
			ICurrencyFactory currencyFactory)
		{
			this.combinationCalculator = combinationCalculator;
			this.possibilityCalculator = possibilityCalculator;
			this.currencyFactory = currencyFactory;
		}

		public void Run()
		{
			try
			{
				Console.WriteLine("Please enter pre-decimalisation British currency");
				string input = Console.ReadLine();
				Currency currency = currencyFactory.Build(input);

				//var hack = new CombinationHackerRank();
				//var res = hack.Run();
				//Console.WriteLine($"{ res } ways");

				var dpTest = new CombinationCalculatorDP(new CoinSettings());
				var result = dpTest.Calculate(currency);

				//List<List<double>> combinations = combinationCalculator.Calculate(currency);
				//long possibilityCount = possibilityCalculator.Calculate(combinations);
				//Console.WriteLine($"Grandmother can divide the money between two children in { possibilityCount } ways");
				Console.ReadKey();
			}
			catch (ArgumentException exception)
			{
				Console.WriteLine($"Invalid argument: { exception.Message }");
				Console.ReadKey();
			}
		}
	}
}
using MagicPurse.Extensions;
using MagicPurse.Models;
using System;

namespace MagicPurse
{
	public class Application
	{
		public static void Run()
		{
			/*
			Console.WriteLine("Please enter currency for the calculation");
			string input = Console.ReadLine();
			Wallet wallet = input.ParseMoney();
			CoinPurse coinPurse = new CoinPurse();
			coinPurse.Initialise(wallet.GetTotalPence());
			Console.WriteLine(input);
			Console.ReadKey();
			*/
			var algorithm = new Algorithm(new CoinPurse());
		}
	}
}
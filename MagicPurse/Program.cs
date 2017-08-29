using MagicPurse.Extensions;
using MagicPurse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPurse
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Enter money");
			string input = Console.ReadLine();
			Wallet wallet = input.ParseMoney();
			CoinPurse coinPurse = new CoinPurse();
			coinPurse.Initialise(wallet.GetTotalPence());
			Console.WriteLine(input);
			Console.ReadKey();
		}
	}
}
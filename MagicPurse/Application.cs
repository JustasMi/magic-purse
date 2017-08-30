using MagicPurse.Extensions;
using MagicPurse.Models;
using System;

namespace MagicPurse
{
    public class Application
    {
        public static void Run()
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

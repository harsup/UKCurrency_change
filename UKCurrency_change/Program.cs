using System;
using System.Collections.Generic;
using UKChangeCalculator;

class Program
{
    static readonly Dictionary<string, double> Denominations = new Dictionary<string, double>()
    {
         { "£50" , 50.00 },
         { "£20" , 20.00 },
         { "£10" , 10.00 },
         { "£5" , 5.00 },
         { "£2" , 2.00 },
         { "£1" , 1.00 },
         { "50p", 0.50 },
         { "20p", 0.20 },
         { "10p", 0.10 },
         { "5p", 0.05 },
         { "2p", 0.02 },
         { "1p", 0.01 }
    };
    static void Main()
    {
        IChangeCalculator changeCalculator = new ChangeCalculator(Denominations);
        IChangeDispalyer changeDispalyer = new ChangeDisplayer();

        Console.Write("Enter total amount you have(in pounds) :");

        double totalAmount = double.Parse(Console.ReadLine());

        Console.Write("Enter purchase price(in pounds) :");

        double purchasePrice = double.Parse(Console.ReadLine());

        var changeBreakdown = changeCalculator.CalculateChange(totalAmount, purchasePrice);

        changeDispalyer.Dispalychange(changeBreakdown);

    }
}
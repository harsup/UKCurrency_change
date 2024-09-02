using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKChangeCalculator
{
    public class ChangeCalculator : IChangeCalculator
    {
        private readonly Dictionary<string, double> _denominations;

        public ChangeCalculator(Dictionary<string, double> denominations)
        {
            _denominations = denominations;
        }

        public Dictionary<string, int> CalculateChange(double totalAmount , double purchasePrice)
        {
            double change = totalAmount - purchasePrice;
            var changeBreakdown = new Dictionary<string, int>();
            if (totalAmount < purchasePrice)
            {
                Console.WriteLine("Insufficient funds");
                return null;
            }

            else if (totalAmount == purchasePrice)
            {
                Console.WriteLine("No Change returned");
                return new Dictionary<string, int>();
            }

            else {
                foreach (var denomination in _denominations)
                {
                    if (change >= denomination.Value)
                    {
                        int count = (int)(change / denomination.Value);
                        change -= count * denomination.Value;
                        change = Math.Round(change, 2);
                        changeBreakdown[denomination.Key] = count;
                    }
                }

                return changeBreakdown;
            }
        }
    }


}

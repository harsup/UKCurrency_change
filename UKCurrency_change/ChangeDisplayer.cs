using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKChangeCalculator
{
    public class ChangeDisplayer : IChangeDispalyer
    {
        public void Dispalychange(Dictionary<string, int> changeBreakdown)
        {
            if (changeBreakdown != null)
            {
                Console.WriteLine("Your change is:");
                foreach (var denomination in changeBreakdown)
                {
                    Console.WriteLine($"{denomination.Value} x {denomination.Key}");
                }
            }
        }
    }
}

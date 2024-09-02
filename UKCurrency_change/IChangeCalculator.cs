using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace UKChangeCalculator
{
    public interface IChangeCalculator
    {
        Dictionary<string, int> CalculateChange(double totalAmount , double purchasePrice);
    }
}

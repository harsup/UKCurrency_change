using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKChangeCalculator
{
    public interface IChangeDispalyer
    {
        void Dispalychange(Dictionary<string, int> changeBreakdown);
    }
}

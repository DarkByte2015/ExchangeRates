using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

namespace ExchangeRates.Models
{
    [ImplementPropertyChanged]
    public class Currency
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public string CostString
        {
            get
            {
                return Cost.ToString();
            }
        }

        public Currency(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}

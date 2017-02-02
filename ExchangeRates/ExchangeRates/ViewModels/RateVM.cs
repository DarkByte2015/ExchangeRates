using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using ExchangeRates.Models;

namespace ExchangeRates.ViewModels
{
    [ImplementPropertyChanged]
    class RateVM : ViewModelBase
    {
        public string Text { get; private set; } = "This is RATE!!!";
        public Currency[] Currencies { get; private set; }

        private RateVM()
        {
        }

        public static async Task<RateVM> Create(DateTime day)
        {
            var vm = new RateVM();
            vm.Currencies = await ERHelper.GetCurrenciesAsync(day, "EUR", "USD");
            return vm;
        }
    }
}
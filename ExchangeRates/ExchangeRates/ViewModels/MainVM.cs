using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;

namespace ExchangeRates.ViewModels
{
    [ImplementPropertyChanged]
    class MainVM : ViewModelBase
    {
        public string Text { get; private set; } = "Hello world!!!";
        public DateTime MinDate { get; } = new DateTime(1970, 1, 1);
        public DateTime MaxDate { get; } = DateTime.Now;
        public DateTime Day { get; set; } = DateTime.Now;

        public ICommand GetCurrencyCommand { get; } = new RelayCommand<MainVM>(async (vm) =>
        {
            var rvm = await RateVM.Create(vm.Day);
            await Router.ShowModalAsync(rvm);
        });
    }
}

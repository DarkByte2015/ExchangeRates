using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using ExchangeRates.Views;

namespace ExchangeRates.ViewModels
{
    public static class Router
    {
        private static Dictionary<Type, Type> routes = new Dictionary<Type, Type>()
        {
            [typeof(MainVM)] = typeof(MainPage),
            [typeof(RateVM)] = typeof(RatePage)
        };

        public static INavigation Navigation
        {
            get
            {
                return App.Current.MainPage.Navigation;
            }
        }

        public static Page GetPage<T>() where T : ViewModelBase
        {
            return (Page)Activator.CreateInstance(routes[typeof(T)]);
        }

        public static async Task ShowAsync<T>(T vm) where T : ViewModelBase
        {
            var page = GetPage<T>();
            page.BindingContext = vm;
            await Navigation.PushAsync(page);
        }

        public static async Task ShowModalAsync<T>(T vm) where T : ViewModelBase
        {
            var page = GetPage<T>();
            page.BindingContext = vm;
            await Navigation.PushModalAsync(page);
        }

        public static async Task ReturnAsync()
        {
            await Navigation.PopAsync();
        }
    }
}

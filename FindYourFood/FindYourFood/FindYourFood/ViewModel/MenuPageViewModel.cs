using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindYourFood.Views;
using Xamarin.Forms;

namespace FindYourFood.ViewModel
{
    public class MenuPageViewModel
    {
        public ICommand GoHomeCommand { get; set; }
        public ICommand GoSecondCommand { get; set; }

        public MenuPageViewModel()
        {
            GoHomeCommand = new Command(GoHome);
            GoSecondCommand = new Command(GoSecond);
        }

        void GoHome(object obj)
        {
            Appl.RootPage.Detail = new NavigationPage(new MainPage());
            Appl.MenuIsPresented = false;
        }

        void GoSecond(object obj)
        {
            Appl.RootPage.Detail = new NavigationPage(new FavouritePage());
            Appl.MenuIsPresented = false;
        }
    }
}

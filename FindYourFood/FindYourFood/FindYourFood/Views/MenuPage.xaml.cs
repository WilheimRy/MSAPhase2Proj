using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.ViewModel;
using Xamarin.Forms;

namespace FindYourFood.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            BindingContext = new MenuPageViewModel();
            Title = "Menu";
            Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null;
            InitializeComponent();
        }
    }
}

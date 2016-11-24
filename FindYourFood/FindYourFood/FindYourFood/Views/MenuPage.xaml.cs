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
            Label.Text = Appl.Current.Properties["userName"].ToString();
        }

        private async void Button_OnClickedLogout(object sender, EventArgs e)
        {
            Appl.Current.Properties["userName"] = "";
            await Navigation.PushAsync(new LoginPage());

        }
    }
}

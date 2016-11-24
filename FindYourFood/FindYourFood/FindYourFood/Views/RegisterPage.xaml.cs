using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.DataModel;
using Xamarin.Forms;

namespace FindYourFood.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_OnClickedConfirm(object sender, EventArgs e)
        {
            User user = new User();
            user.userName = usernameEntry.Text;
            user.passWord = passwordEntry.Text;

            

            if (passwordEntry.Text != passwordEntry2.Text)
            {
                await DisplayAlert("Register Fail", "Password not the same!", "Ok");
            }
            else
            {
                List<User> list = await AzureManager.AzureManagerInstance.IsUserExists(user);
                if (list.Count > 0)
                {
                    await DisplayAlert("Register Fail", "User already exist!", "Ok");
                }
                else
                {
                    await AzureManager.AzureManagerInstance.AddUser(user);
                    await DisplayAlert("Register Sucess", "New user "+user.userName + " registered!", "Ok");
                    Appl.Current.MainPage = new NavigationPage(new LoginPage());
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false); // this clobbers the entire nav bar

        }
    }
}

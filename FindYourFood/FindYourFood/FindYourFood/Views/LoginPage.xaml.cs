using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.DataModel;
using Xamarin.Forms;

namespace FindYourFood.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            
            InitializeComponent();
        }

        async void Login_Clicked(object sender, System.EventArgs e)
        {
            //Simulate Login
            if (!string.IsNullOrEmpty(usernameEntry.Text) &&
                !string.IsNullOrEmpty(passwordEntry.Text))
            {
                User user = new User();
                user.userName = usernameEntry.Text;
                user.passWord = passwordEntry.Text;

                List<User> list = await AzureManager.AzureManagerInstance.IsUserExists(user);
                if (list.Count == 0)
                {
                    await DisplayAlert("Login Fail", "User doesn't exist!", "Ok");
                }
                else
                {
                    if (usernameEntry.Text.ToLower().Equals(list[0].userName)
                    && passwordEntry.Text.ToLower().Equals(list[0].passWord))
                    {
                        //Login Successful
                        Appl.Current.Properties["userName"] = list[0].userName;
                        var menuPage = new MenuPage();
                        Appl.NavigationPage = new NavigationPage(new MainPage());
                        Appl.RootPage = new RootPage();
                        Appl.RootPage.Master = menuPage;
                        Appl.RootPage.Detail = Appl.NavigationPage;

                        //change mainpage of app
                        Appl.Current.MainPage = new NavigationPage(Appl.RootPage);
                    }
                    else
                    {
                        //Login Failed
                        await DisplayAlert("Login Fail", "Please recheck your credentials", "Ok");
                    }
                }

            }
            else
            {
                await DisplayAlert("Login Fail", "Please make sure all fields are complete", "Ok");
            }

        }

        private async void RegisterButton_OnClicked(object sender, EventArgs e)
        {
            Appl.Current.MainPage = new NavigationPage(new RegisterPage());

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false); // this clobbers the entire nav bar
         
        }
           
    }
}

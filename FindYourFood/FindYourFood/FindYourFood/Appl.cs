using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindYourFood.Views;
using Xamarin.Forms;

namespace FindYourFood
{
    public class Appl : Application
    {

        public static NavigationPage NavigationPage { get; set; }
        public static RootPage RootPage;

        public static bool MenuIsPresented
        {
            get
            {
                return RootPage.IsPresented;
            }
            set
            {
                RootPage.IsPresented = value;
            }
        }

        public Appl()
        {
            // The root page of your application

            MainPage = new LoginPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

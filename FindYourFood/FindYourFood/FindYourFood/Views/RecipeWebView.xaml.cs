using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.DataModel;
using Xamarin.Forms;

namespace FindYourFood.Views
{
    public partial class RecipeWebViewPage : ContentPage
    {
        public static User SelectedRecipe = null;

        public  RecipeWebViewPage(User myRecipe)
        {
            InitializeComponent();
            SelectedRecipe = myRecipe;

            if (SelectedRecipe.isExisted == true)
            {
                WebViewBtn.IsVisible = false;
            }
            else
            {
                WebViewBtn.IsVisible = true;
            }

            Browser.Source = myRecipe.favouriteUrl;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (SelectedRecipe != null)
            {
                //search if the selected recipe exists
                List<User> list = await AzureManager.AzureManagerInstance.IsRecipeExists(SelectedRecipe);

                if (list.Count > 0)
                {
                    await DisplayAlert("Existed Favourites", SelectedRecipe.title + " already exists.", "Ok");
                }
                else
                {
                    SelectedRecipe.Date = DateTime.Now;
                    SelectedRecipe.userName = Appl.Current.Properties["userName"].ToString();
                    await AzureManager.AzureManagerInstance.AddRecipe(SelectedRecipe);
                    await DisplayAlert("Add to Favourites", SelectedRecipe.title + " added to your favourites.", "Ok");
                }
            }
            else
            {
                await DisplayAlert("No Recipe Selected!", "Please select one recipe.", "Ok");
            }

        }

    }
}

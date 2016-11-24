using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.DataModel;
using Xamarin.Forms;

namespace FindYourFood.Views
{
    public partial class WebViewPage : ContentPage
    {
        public static myRecipe SelectedRecipe = null;

        public  WebViewPage(myRecipe myRecipe)
        {
            InitializeComponent();
            SelectedRecipe = myRecipe;

            if (SelectedRecipe.Existed == true)
            {
                WebViewBtn.IsVisible = false;
            }
            else
            {
                WebViewBtn.IsVisible = true;
            }

            Browser.Source = myRecipe.recipeUrl;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (SelectedRecipe != null)
            {
                //search if the selected recipe exists
                List<myRecipe> list = await AzureManager.AzureManagerInstance.IsRecipeExists(SelectedRecipe);

                if (list.Count > 0)
                {
                    await DisplayAlert("Existed Favourites", SelectedRecipe.title + " already exists.", "Ok");
                }
                else
                {
                    SelectedRecipe.Date = DateTime.Now;
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

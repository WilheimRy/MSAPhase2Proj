using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.DataModel;
using Xamarin.Forms;

namespace FindYourFood.Views
{
    public partial class FavouritePage : ContentPage
    {
        public static User SelectedRecipe = null;


        public FavouritePage()
        {
            InitializeComponent();
        }



        private async void Button_DeleteRecipe(object sender, EventArgs e)
        {
            if (SelectedRecipe != null)
            {
                var result=await DisplayAlert("Remove Recipe","Really want to remove this recipe?", "Ok", "Cancel");
                if (result==true)
                {
                    UploadingIndicator.IsRunning = true;
                    await AzureManager.AzureManagerInstance.DeleteRecipe(SelectedRecipe);
                    await DisplayAlert("Remove Recipe", SelectedRecipe.title + " has been removed ", "Ok");
                    List<User> list = await AzureManager.AzureManagerInstance.GetAllRecipes();
                    RecipeListView.ItemsSource = list;
                    UploadingIndicator.IsRunning = false;
                }
            }
            else
            {
                await DisplayAlert("No Recipe Selected!", "Please select one recipe.", "Ok");
            }

            

        }

        private async void Button_OnClickedShowFavourites(object sender, EventArgs e)
        {
            UploadingIndicator.IsRunning = true;
            List<User> list = await AzureManager.AzureManagerInstance.GetAllRecipes();
            if (list.Count == 0)
            {
                await DisplayAlert("No Favourites!", "Try to add in some food.", "Ok");
            }
            RecipeListView.ItemsSource = list;
            UploadingIndicator.IsRunning = false;
        }

        private async void RecipeListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            SelectedRecipe = e.Item as User;

            RecipeWebViewPage recipeWebViewPage = null;

            if ((e.Item as User) != null)
            {
                User tempMyRecipe = e.Item as User;

                List<User> list = await AzureManager.AzureManagerInstance.IsRecipeExists(SelectedRecipe);

                if (list.Count > 0)
                {
                    tempMyRecipe.isExisted = true;
                }
                else
                {
                    tempMyRecipe.isExisted = false;
                }


                recipeWebViewPage = new RecipeWebViewPage(tempMyRecipe);
            }
            await Navigation.PushAsync(recipeWebViewPage);
        }

        private async void Button_OnClickedUpdate(object sender, EventArgs e)
        {
            if (SelectedRecipe != null)
            {
                var result = await DisplayAlert("Update Recipe", "Really want to Edit this recipe?", "Ok", "Cancel");
                UpdateView updateView = null;
                if (result == true)
                {
                    updateView= new UpdateView(SelectedRecipe);
                    await Navigation.PushAsync(updateView);
                }
            }
            else
            {
                await DisplayAlert("No Recipe Selected!", "Please select one recipe.", "Ok");
            }

        }
    }
}

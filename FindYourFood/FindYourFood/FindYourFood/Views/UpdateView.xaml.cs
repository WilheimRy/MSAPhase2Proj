using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.DataModel;
using Xamarin.Forms;

namespace FindYourFood.Views
{
    public partial class UpdateView : ContentPage
    {
        public static User TempRecipe = null;

        public UpdateView(User myRecipe)
        {
            TempRecipe = myRecipe;
            List<User> myRecipes= new List<User>();
            myRecipes.Add(myRecipe);
            InitializeComponent();
            RecipeListView.ItemsSource = myRecipes;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (TempRecipe != null)
            {
                var result = await DisplayAlert("Update Recipe", "Really want to edit this recipe?", "Ok", "Cancel");
                if (result == true)
                {
                    UploadingIndicator.IsRunning = true;
                    TempRecipe.title = MyEntry.Text;
                    await AzureManager.AzureManagerInstance.UpdateRecipe(TempRecipe);
                    await DisplayAlert("Update Recipe", TempRecipe.title + " has been Updated.", "Ok");
                    List<User> list = await AzureManager.AzureManagerInstance.IsRecipeExists(TempRecipe);
                    RecipeListView.ItemsSource = list;
                    UploadingIndicator.IsRunning = false;
                }
            }
        }
    }
}

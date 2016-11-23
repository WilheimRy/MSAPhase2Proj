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
        public FavouritePage()
        {
            InitializeComponent();
        }



        private void Button_DeleteRecipe(object sender, EventArgs e)
        {
            
        }

        private async void Button_OnClickedShowFavourites(object sender, EventArgs e)
        {
            UploadingIndicator.IsRunning = true;
            List<myRecipe> list= await AzureManager.AzureManagerInstance.GetAllRecipes();
            RecipeListView.ItemsSource = list;
            UploadingIndicator.IsRunning = false;
        }

        private void RecipeListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }
    }
}

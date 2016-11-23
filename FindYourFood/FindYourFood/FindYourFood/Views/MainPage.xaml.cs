using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.DataModel;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace FindYourFood.Views
{
    public partial class MainPage : ContentPage
    {
        public static myRecipe SelectedRecipe = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void MyEntry_OnCompleted(object sender, EventArgs e)
        {
            await DisplayMenu();
        }

        private async Task DisplayMenu()
        {
            string input = "";
            if (MyEntry.Text != null)
            {
                input = MyEntry.Text.Trim();
            }

            RecipeModel.RootObject rootObject;
            var uri = "";
            if (input == "")
            {
                uri =
                    "https://edamam-recipe-search-and-diet-v1.p.mashape.com/search?_app_id=4d184a43&_app_key=80e956f0544de255e27075a862bd3d5d&q=111";
            }
            else
            {
                uri =
                    "https://edamam-recipe-search-and-diet-v1.p.mashape.com/search?_app_id=4d184a43&_app_key=80e956f0544de255e27075a862bd3d5d&q=" +
                    input;
            }

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("X-Mashape-Key", "gMNslw2jxxmshodWJPKB2XVI1q0Ap1pJEWcjsnC4yxXj4J858U");

            string x = await client.GetStringAsync(new Uri(uri));

            rootObject = JsonConvert.DeserializeObject<RecipeModel.RootObject>(x);
            // the data seems all right, show it in card view
            ObservableCollection<myRecipe> recipeDisList = new ObservableCollection<myRecipe>();
            foreach (var hit in rootObject.hits)
            {
                myRecipe recipeDisplayModel = new myRecipe();
                recipeDisplayModel.title = hit.recipe.label;
                recipeDisplayModel.imgUrl = hit.recipe.image;
                recipeDisplayModel.recipeUrl = hit.recipe.url;
                recipeDisList.Add(recipeDisplayModel);
            }

            RecipeListView.ItemsSource = recipeDisList;
        }


        private async void AddtoRecipe(object sender, EventArgs e)
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

        private void RecipeListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            SelectedRecipe = e.Item as myRecipe;
        }
    }
}

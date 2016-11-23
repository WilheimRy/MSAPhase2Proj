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
        public MainPage()
        {
            InitializeComponent();
        }

        //        private Task MyEntry_OnCompleted(object sender, EventArgs e)
        //        {
        //            
        ////            string input = MyEntry.Text.Trim();
        ////
        ////            RecipeModel.RootObject rootObject;
        ////
        ////            var uri = "https://edamam-recipe-search-and-diet-v1.p.mashape.com/search?_app_id=4d184a43&_app_key=80e956f0544de255e27075a862bd3d5d&q=111";
        ////            var client = new HttpClient();
        ////
        ////            client.DefaultRequestHeaders.Add("X-Mashape-Key", "gMNslw2jxxmshodWJPKB2XVI1q0Ap1pJEWcjsnC4yxXj4J858U");
        ////
        ////            string x = await client.GetStringAsync(new Uri(uri));
        ////
        ////            rootObject = JsonConvert.DeserializeObject<RecipeModel.RootObject>(x);
        ////
        ////            int a=11;
        //        }


        private async void MyEntry_OnCompleted(object sender, EventArgs e)
        {
            string input = MyEntry.Text.Trim();

            RecipeModel.RootObject rootObject;

            var uri = "https://edamam-recipe-search-and-diet-v1.p.mashape.com/search?_app_id=4d184a43&_app_key=80e956f0544de255e27075a862bd3d5d&q=111";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("X-Mashape-Key", "gMNslw2jxxmshodWJPKB2XVI1q0Ap1pJEWcjsnC4yxXj4J858U");

            string x = await client.GetStringAsync(new Uri(uri));

            rootObject = JsonConvert.DeserializeObject<RecipeModel.RootObject>(x);
            // the data seems all right, show it in card view
            ObservableCollection <RecipeDisplayModel> recipeDisList= new ObservableCollection<RecipeDisplayModel>();
            foreach (var hit in rootObject.hits)
            {
                RecipeDisplayModel recipeDisplayModel= new RecipeDisplayModel();
                recipeDisplayModel.title = hit.recipe.label;
                recipeDisplayModel.imgUrl = hit.recipe.image;
                recipeDisplayModel.recipeUrl = hit.recipe.url;
                recipeDisList.Add(recipeDisplayModel);
            }

            RecipeView.ItemsSource = recipeDisList;

            int a = 1;
//            ObservableCollection<>


        }
    }
}

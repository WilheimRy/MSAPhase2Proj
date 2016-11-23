using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindYourFood.DataModel;

namespace FindYourFood
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<myRecipe> myRecipeTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://recipeappry.azurewebsites.net/");
            this.myRecipeTable = this.client.GetTable<myRecipe>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task AddRecipe(myRecipe myRecipe)
        {
            await this.myRecipeTable.InsertAsync(myRecipe);
        }

        public async Task<List<myRecipe>> GetAllRecipes()
        {
            return await this.myRecipeTable.ToListAsync();
        }

        public async Task<List<myRecipe>> IsRecipeExists(myRecipe myRecipe)
        {
            return await this.myRecipeTable.Where(x => x.title == myRecipe.title).ToListAsync();
        }

        public async Task DeleteRecipe(myRecipe myRecipe)
        {
            await this.myRecipeTable.DeleteAsync(myRecipe);
        }

        public async Task UpdateRecipe(myRecipe myRecipe)
        {
            await this.myRecipeTable.UpdateAsync(myRecipe);
        }



    }
}

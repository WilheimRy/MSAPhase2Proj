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

        private IMobileServiceTable<User> userTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://recipeappry.azurewebsites.net/");
            this.userTable= this.client.GetTable<User>();
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

        public async Task AddRecipe(User myRecipe)
        {
            await this.userTable.InsertAsync(myRecipe);
        }

        public async Task<List<User>> GetAllRecipes()
        {
            return await this.userTable.Where(x=>x.userName== Appl.Current.Properties["userName"].ToString()).Where(x=>x.favouriteUrl!=null).ToListAsync();
        }

        public async Task<List<User>> IsRecipeExists(User myRecipe)
        {
            return await this.userTable.Where(x => x.imgUrl == myRecipe.imgUrl).ToListAsync();
        }

        public async Task DeleteRecipe(User myRecipe)
        {
            await this.userTable.DeleteAsync(myRecipe);
        }

        public async Task UpdateRecipe(User myRecipe)
        {
            await this.userTable.UpdateAsync(myRecipe);
        }


        //register
        public async Task AddUser(User user)
        {
            await this.userTable.InsertAsync(user);
        }

        //login
        public async Task<List<User>> IsUserExists(User user)
        {
            return await this.userTable.Where(x => x.userName == user.userName).ToListAsync();
        }

        



    }
}

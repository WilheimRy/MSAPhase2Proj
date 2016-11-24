using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FindYourFood.DataModel
{
    public class myRecipe
    {
        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }
        [JsonProperty(PropertyName = "Title")]
        public string title { get; set; }
        [JsonProperty(PropertyName = "ImgUrl")]
        public string imgUrl { get; set; }
        [JsonProperty(PropertyName = "RecipeUrl")]
        public string recipeUrl { get; set; }
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime Date { get; set; }
        [JsonProperty(PropertyName = "Exist")]
        public bool Existed { get; set; }

    }
}

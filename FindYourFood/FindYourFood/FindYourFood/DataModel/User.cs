using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FindYourFood.DataModel
{
    public class User
    {


        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }
        [JsonProperty(PropertyName = "userName")]
        public string userName { get; set; }
        [JsonProperty(PropertyName = "passWord")]
        public string passWord { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string title { get; set; }
        [JsonProperty(PropertyName = "ImgUrl")]
        public string imgUrl { get; set; }
        [JsonProperty(PropertyName = "favouriteUrl")]
        public string favouriteUrl { get; set; }
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime Date { get; set; }
        [JsonProperty(PropertyName = "isExisted")]
        public bool isExisted { get; set; }


    }
}

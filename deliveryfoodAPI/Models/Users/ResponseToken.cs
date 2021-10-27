using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Users
{
    public class ResponseToken
    {
        public string id { get; set; }
        public string role_name { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public string token { get; set; }
        public DateTime? expiration { get; set; }
    }
}

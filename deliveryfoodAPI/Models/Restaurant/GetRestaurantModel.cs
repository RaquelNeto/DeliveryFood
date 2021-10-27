
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Restaurant
{
    public class GetRestaurantModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string photo { get; set; }
    }
}

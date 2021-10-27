using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Restaurant
{
    public class UpdateRestaurantModel
    {

        public string phone { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public string Street { get; set; }

        public string ZIP { get; set; }
    
        public string City { get; set; }
    }
}

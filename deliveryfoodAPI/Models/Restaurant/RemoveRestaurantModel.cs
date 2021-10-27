using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Restaurant
{
    public class RemoveRestaurantModel
    {
        [Required]
        public string id { get; set; }
    }
}

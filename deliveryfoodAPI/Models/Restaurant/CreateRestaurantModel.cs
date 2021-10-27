using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Restaurant
{
    public class CreateRestaurantModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        public string photo { get; set; }
        [Required]
        public string ownerID { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string ZIP { get; set; }
        [Required]
        public string City { get; set; }
    }
}

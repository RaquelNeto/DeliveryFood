using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Product
{
    public class AddMealModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string typeID { get; set; }
        [Required]
        public string price { get; set; }
        [Required]
        public string restaurantID { get; set; }
        public string description { get; set; }
        public bool state { get; set; }
        public string photo { get; set; }
    }
}

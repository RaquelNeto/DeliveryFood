using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.IngredientExtra
{
    public class AddIngredientExtraModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public float price { get; set; }
       
       
    }
}

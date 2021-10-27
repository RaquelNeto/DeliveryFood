using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Ingredients
{
    public class UpdateIngredient
    {
    
        public string name { get; set; }
        public string description { get; set; }
    }
}

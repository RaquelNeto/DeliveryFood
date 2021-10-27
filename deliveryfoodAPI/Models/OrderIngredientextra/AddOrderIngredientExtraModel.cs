using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.OrderIngredientextra
{
    public class AddOrderIngredientExtraModel
    {
        [Required]
        public string orderID { get; set; }
        [Required]
        public string ingredientID { get; set; }
    }
}

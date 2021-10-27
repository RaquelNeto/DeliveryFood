using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Entities
{
    public class MealsIngredients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string mealID { get; set; }
        public string ingredientID { get; set; }
        public bool isRequired { get; set; }
        public bool isRequest { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Product
{
    public class UpdateMealModel
    {
     
   
        public string price { get; set; }
        public string description { get; set; }
        public bool state { get; set; }
        public string photo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.OrderProducts
{
    public class GetMealOrderModel
    {
        [Required]
        public string id { get; set; }
    }
}

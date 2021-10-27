using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Deliveryman
{
    public class AddDeliverymanModel
    {
        [Required]
        public string userId { get; set; }
        public string vehicle { get; set; }
        public bool state { get; set; }
        public string restaurantId { get; set; }
    }
}

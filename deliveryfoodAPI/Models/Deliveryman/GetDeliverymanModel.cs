using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Deliveryman
{
    public class GetDeliverymanModel
    {
        public string name { get; set; }
        public string phone_number { get; set; }
        public string vehicle { get; set; }
        public bool state { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Update_at { get; set; }
    }
}

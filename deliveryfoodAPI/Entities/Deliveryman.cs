using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Entities
{
    public class Deliveryman
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string userID { get; set; }
        public string restaurantID { get; set; }
        public string vehicle { get; set; }
        public bool active { get; set; }
        public bool isAvailable { get; set; }


    }
}

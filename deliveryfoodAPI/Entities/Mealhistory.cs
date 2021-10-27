using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Entities
{
    public class Mealhistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string mealID { get; set; }
        public string name { get; set; }
        public string typeID { get; set; }
        public string price { get; set; }
        public string restaurantID { get; set; }
        public string description { get; set; }
        public bool state { get; set; }
        public string photo { get; set; }
        public string orderID { get; set; }
        public int quantity { get; set; }
    }
}

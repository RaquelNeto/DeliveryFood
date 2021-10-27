using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Entities
{
    public class Restaurants
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string photo {get;set;}
        public string ownerID { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }

    }
}

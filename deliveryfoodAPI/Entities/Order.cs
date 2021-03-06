using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string qrcode { get; set; }
        public DateTime? requestDate { get; set; }
        public string userID { get; set; }
        public string delivermanID { get; set; }
        public float total_price { get; set; } 
        public bool require_invoice { get; set; }
        public string status_request { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
    }
}

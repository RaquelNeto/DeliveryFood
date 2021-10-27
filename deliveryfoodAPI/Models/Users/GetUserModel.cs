using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Users
{
    public class GetUserModel
    {

        public string Name { get; set; }
        public string userName { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public string Birthdate { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Update_at { get; set; }
     
    }
}

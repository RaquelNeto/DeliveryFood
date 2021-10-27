using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Users
{
    public class UpdateUserModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string phone_number { get; set; }
        public string password { get; set; }
        public string new_password { get; set; }
        public string confirm_password { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public DateTime? Update_at { get; set; }
    }
}

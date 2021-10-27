using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Users
{
    public class ForgetModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

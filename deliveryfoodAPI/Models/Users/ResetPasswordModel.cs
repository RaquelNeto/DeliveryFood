using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Users
{
    public class ResetPasswordModel
    {

        [Required]
      
        public string NewPassword { get; set; }

        [Required]
 
        public string ConfirmPassword { get; set; }
    }
}

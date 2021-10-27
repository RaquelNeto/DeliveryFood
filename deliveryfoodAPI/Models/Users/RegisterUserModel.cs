using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Users
{
    public class RegisterUserModel
    {
        

        /// <summary>
        /// Full Name User
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string phonenumber { get; set; }

        public string nif { get; set; }

        /// <summary>
        /// Password
        /// </summary>

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /// <summary>
        /// Confirmar Password
        /// </summary>

        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }





    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueFlamePizza.DTOs
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Valid Email is required.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Password confirmation is required.")]
        public string UserConfirmPassword { get; set; }
        //public string UserFirstName { get; set; }

        //public string UserLastName { get; set; }

        //public string UserPhone { get; set; }
        //public string UserPasswordHint { get; set; }
    }
}

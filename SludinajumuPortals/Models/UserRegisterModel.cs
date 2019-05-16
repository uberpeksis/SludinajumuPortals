using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SludinajumuPortals.Models
{
    public class UserRegisterModel
    {
        [Display(Name = "Lietotājs:")]
        [Required(ErrorMessage = "Nav ievadīts lietotājvārds")]
        public string Username { get; set; }

        [Display(Name = "Parole:")]
        [Required(ErrorMessage = "Nav ievadīta parole")]
        public string Password { get; set; }

        [Display(Name = "Parole atkārtoti:")]
        [Required(ErrorMessage = "Nav ievadīta parole atkārtoti")]
        [Compare("Password", ErrorMessage = "Paroles nesakrīt")]
        public string PasswordRepeat { get; set; }
    }
}
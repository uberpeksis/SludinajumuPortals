using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SludinajumuPortals.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Lietotājvārds:")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Parole:")]
        public string Password { get; set; }

    }
}
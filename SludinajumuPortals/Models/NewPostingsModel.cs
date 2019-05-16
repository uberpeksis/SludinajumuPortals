using Logic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SludinajumuPortals.Models
{
    public class NewPostingsModel
    {
        [Required(ErrorMessage = "Kategorijas ievadlaukam jābūt aizpildītam")]
        [Display(Name = "Izvēlies kategoriju:")]
        public int CategoryId { get; set; }

        public List<CategoryData> Categories { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nav ievadīts nosaukums!")]
        [Display(Name = "Nosaukums:")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Cena:")]
        public double Price { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Nav ievadīta atrašanās vieta!")]
        [Display(Name = "Atrašanās vieta:")]
        public string Adress { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Nav ievadīta telefona numurs!")]
        [Display(Name = "Telefons:")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Nav ievadīts e-pasts!")]
        [Display(Name = "E-pasts:")]
        public string Email { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Nav ievadīts apraksts!")]
        [Display(Name = "Apraksts:")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Attēls:")]
        public List<HttpPostedFileBase> Image { get; set; }
    }
}
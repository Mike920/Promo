using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Promocje_Web.Utility;

namespace Promocje_Web.Models
{
    public class Sklep
    {
        //[Remote("IsSklepUnique", "Sklepy")]
        [DisplayName("Nazwa")]
        [CustomRemoteValidation("IsSklepUnique", "Sklepy")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Promocje_Web.Properties.Resources))]
        public string Id { get; set; }
       
        [Required(ErrorMessage = "Wybierz obraz reprezentujący logo sklepu.")]
        public string LogoUrl { get; set; }

        [Required]
        [DisplayName("Kategoria")]
        public string KategoriaId { get; set; }  
        public virtual Kategoria Kategoria { get; set; }
        public virtual ICollection<Ulotka> Ulotki { get; set; }
    }
}
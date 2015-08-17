using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Promocje_Web.Models
{
    public class Sklep
    {
        [DisplayName("Nazwa")]
        public string Id { get; set; }
       
        [Required]
        public string LogoUrl { get; set; }
        [Required]
        public virtual Kategoria Kategoria { get; set; }
        public virtual ICollection<Ulotka> Ulotki { get; set; }
    }
}
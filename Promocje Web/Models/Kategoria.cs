using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Promocje_Web.Models
{
    public class Kategoria
    {
        [DisplayName("Nazwa")][ScaffoldColumn(true)]
        public string Id { get; set; }

        public virtual ICollection<Sklep> Sklepy { get; set; }
    }
}
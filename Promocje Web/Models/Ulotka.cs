using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Promocje_Web.Services;

namespace Promocje_Web.Models
{
    public class Ulotka
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public string ApplicationUserId { get; set; }
        [Required]
        public string Title { get; set; }
        //  public string AssetId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public FileSetType FileSetType { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        private string urls = String.Empty;

        public List<string> Urls
        {
            get { return urls.Split(';').ToList(); }
            set
            {
                foreach (string url in value)
                    urls += url + ";";
            }
        }
        [DisplayName("Czas rozpoczęcia")]
        [Required]
        public DateTime StartDate { get; set; }
        [DisplayName("Czas zakonczenia")]
        [Required]
        public DateTime EndDate { get; set; }
       

        public virtual ApplicationUser ApplicationUser { get; set; }
        public int SklepId { get; set; }
        public virtual Sklep Sklep { get; set; }
    }

    public enum FileSetType
    {
        Images,
        Pdf,

    }
}
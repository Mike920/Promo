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

        public Ulotka()
        {
            urls = string.Empty;
        }
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public string ApplicationUserId { get; set; }
        [Required][DisplayName("Nazwa")]
        public string Title { get; set; }
        //  public string AssetId { get; set; }
        [Required][DisplayName("Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public FileSetType FileSetType { get; set; }
        
        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Wybierz pliki.")]
        public string urls  { get; set;}

        //Add _ to a property name to avoid exceptions in the View
        public List<string> UrlList
        {
            get { return urls.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList(); }
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

        [Required][ScaffoldColumn(false)]
        public DateTime PublishDate { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required][DisplayName("Sklep")]
        public string SklepId { get; set; }
        public virtual Sklep Sklep { get; set; }
    }

    public enum FileSetType
    {
        Images,
        Pdf,

    }
}
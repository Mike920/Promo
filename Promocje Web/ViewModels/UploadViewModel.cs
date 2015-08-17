using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Promocje_Web.ViewModels
{
    public class UploadViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }

        [Required(ErrorMessage = "Select the media file to upload")]
        public HttpPostedFileBase File { get; set; }
    }
}
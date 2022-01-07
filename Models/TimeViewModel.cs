using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterTimesContext.Models
{
    public class TimeViewModel
    {
        
            [Key]
            public int Timeid { get; set; }

            [Required]
            public string Time { get; set; }

            [Required]
            public string Estado { get; set; }

            [Required]
            public string Cores { get; set; }
        [Required]
        public string Tecnico { get; set; }
        
        [DisplayName("Image Name")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile {  get; set; }
    }
}

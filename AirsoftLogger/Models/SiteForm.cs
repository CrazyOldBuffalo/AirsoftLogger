using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AirsoftLogger.Models
{
    public class SiteForm
    {
        public string SiteCode { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "Please Enter A valid sitename")]
        public string SiteName { get; set; }

        public string Postcode { get; set; }

        [MinLength(15, ErrorMessage = "Please Enter a valid Webpage")]
        public string Website { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Please Enter A valid Phone Number")]
        public string Tel { get; set; }

        [MinLength (4, ErrorMessage = "Please Enter A valid Street Name")]
        public string Street { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Please Enter A valid City")]
        public string City { get; set; }
    }
}

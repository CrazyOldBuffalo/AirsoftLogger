using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AirsoftLogger.Models
{
    public class AddSite
    {
        [Required]
        [StringLength(4, ErrorMessage = "Please Enter a Valid SiteCode")]
        [MinLength(2 , ErrorMessage = "Please Enter a Valid SiteCode")]
        public string SiteCode { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please Enter a Valid Name")]
        [MinLength(4, ErrorMessage = "Please Enter a Valid Name")]
        public string SiteName { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Please Enter a Valid PostCode")]
        [MinLength(5, ErrorMessage = "Please Enter a Valid PostCode")]
        public string Postcode { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Please Enter a Valid Phone Number")]
        [MinLength(6, ErrorMessage = "Please Enter a Valid Phone Number")]
        public string Tel { get; set; }

        public string Website { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Please Enter a Valid Street")]
        public string Street { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Please Enter a Valid City")]
        [MinLength(2, ErrorMessage = "Please Enter A Valid City")]
        public string City { get; set; }
    }
}

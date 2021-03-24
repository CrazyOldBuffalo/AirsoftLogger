using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AirsoftLogger.Models
{
    public class Site
    {
        [StringLength(25)]
        public string SiteName { get; set; }

        [Required]
        [StringLength(4)]
        [DisplayName("Site Code")]
        [Key]
        public string SiteCode { get; set; }

        [StringLength(8)]
        public string Postcode { get; set; }

        public string Website { get; set; }

        public int Tel { get; set; }
    }
}

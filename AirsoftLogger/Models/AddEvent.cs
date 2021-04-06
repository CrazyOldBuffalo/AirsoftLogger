using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirsoftLogger.Models
{
    public class AddEvent
    {
        public int EventID { get; set; }

        [Required]
        [StringLength(4, ErrorMessage ="Please Enter A valid sitecode")]
        public string SiteCode { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Range(0,30, ErrorMessage ="Please Enter A Valid Number of Spaces")]
        public int Spaces { get; set; }
    }
}

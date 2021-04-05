using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirsoftLogger.Models
{
    public class Events
    {
        [Key]
        [Required]
        [StringLength(4)]
        public string SiteCode { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public int Spaces { get; set; }
    }
}

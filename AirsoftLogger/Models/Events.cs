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
        public Site FKSITE { get; set; }

        [Key]
        [Required]
        public DateTime Date { get; set; }

        [StringLength(75)]
        public string Type { get; set; }
    }
}

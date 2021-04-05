using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirsoftLogger.Models
{
    public class SiteDetails
    {
        public string SiteCode { get; set; }

        public string SiteName { get; set; }


        public string Postcode { get; set; }

        public string Website { get; set; }

        public string Tel { get; set; }
        public string Street { get; set; }

        public string City { get; set; }

        public int EventID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public int Spaces { get; set; }
    }
}

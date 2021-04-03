using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AirsoftLogger.Models
{
    public class Address
    {
        [MaxLength(100, ErrorMessage = "Please Enter a Valid Street")]
        public string Street { get; set; }

        [MaxLength(20, ErrorMessage = "Please Enter a Valid City")]
        [MinLength(2, ErrorMessage = "Please Enter A Valid City")]
        public string City { get; set; }

        [MaxLength(10, ErrorMessage = "Please Enter a Valid Postcode")]
        [MinLength(2, ErrorMessage = "")]
        [Key]
        public string Postcode { get; set; }
    }
}

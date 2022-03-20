using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb_4___API.Models
{
    public class WebLink
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Url { get; set; }
    }
}

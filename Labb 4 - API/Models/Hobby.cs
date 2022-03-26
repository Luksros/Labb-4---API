using Labb_4___API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb_4___API
{
    public class Hobby
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string HobbyName { get; set; }
        [Required]
        public string Description { get; set; }
        public List<WebLink> WebLinks { get; set; }
        public int PersonID { get; set; }
    }
}

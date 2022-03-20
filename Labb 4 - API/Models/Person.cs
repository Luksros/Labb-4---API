using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb_4___API
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string PhoneNum {  get; set; }
        [Required]
        public string Email { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}

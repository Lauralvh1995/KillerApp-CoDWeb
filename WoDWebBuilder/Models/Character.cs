using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WoDWebBuilder.Models
{
    public class Character
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int UserID { get; set; }
        public string Concept { get; set; }
        public int Age { get; set; }
        public string Background { get; set; }
        public string Look { get; set; }
        public string Gender { get; set; }
    }
}
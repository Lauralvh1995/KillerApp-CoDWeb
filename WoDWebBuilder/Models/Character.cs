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
        
        public string Faction { get; set; }
        public string Virtue { get; set; }
        public string Vice { get; set; }
        public string Aspiration1 { get; set; }
        public string Aspiration2 { get; set; }
        public string Aspiration3 { get; set; }
        public string condition { get; set; }
        public int Health { get; set; }
        public int Willpower { get; set; }
        public int Integrity { get; set; }
        public int Size { get; set; }
        public int Speed { get; set; }
        public int Defense { get; set; }
        public int Armor { get; set; }
        public int InitiativeMod { get; set; }
        public int Beats { get; set; }
        public int Experience { get; set; }
    }
}
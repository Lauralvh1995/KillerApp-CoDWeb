using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoDWebBuilder.Models
{
    public class WoD
    {
        public int ID { get; set; }
        public int CharacterID { get; set; }
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
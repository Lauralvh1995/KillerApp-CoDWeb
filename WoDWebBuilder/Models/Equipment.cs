using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoDWebBuilder.Models
{
    public class Equipment
    {
        public string Name { get; set; }
        public string EquipmentType { get; set; }
        public string Effect { get; set; }
        public string Condition { get; set; }
        public int DiceBonus { get; set; }
        public int Size { get; set; }
        public int Durability { get; set; }
    }
}
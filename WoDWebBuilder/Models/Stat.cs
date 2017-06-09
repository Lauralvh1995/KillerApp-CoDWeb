using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoDWebBuilder.Models
{
    public enum StatType
    {
        Attribute,
        Skill,
        Merit
    }
    public class Stat
    {
        public int ID { get; set; }
        public StatType StatType { get; set; }
        public string Name { get; set; }
        public int DotCost { get; set; }
        public string FactionRequirement { get; set; }
        public bool SpecializationEnabled { get; set; }
        public List<Requirement> Requirement { get; set; }
        public int Value { get; set; }
    }
}
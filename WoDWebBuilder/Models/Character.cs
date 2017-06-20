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

        public List<Stat> Stats { get; set; }
        public int UserID { get; set; }
        
        public string Name { get; set; }
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
        public string Condition { get; set; }
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

        public Character()
        {
            Stats = new List<Stat>();
            UserID = 1;
        }

        public bool CheckRequirement(Stat stat)
        {
            List<Requirement> tempList = new List<Requirement>();
            int checksum = stat.GetRequirements().ToList().Count();
            foreach (Requirement requirement in stat.GetRequirements().ToList())
            {
                if (requirement.Additive == true && stat.Value == requirement.Value)
                {
                    checksum--;
                }
                else
                {
                    if (requirement.Additive == false)
                    {
                        tempList.Add(requirement);
                    }
                }
                checksum = checksum - OptionalCheck(tempList, stat);
                if (checksum == 0)
                {
                    return true;
                }
            }
            return false;
        }


        public void ChangeStat(Stat stat, int value)
        {
            foreach(Stat st in Stats)
            {
                if(st.Name == stat.Name && CheckRequirement(stat))
                {
                    st.Value = value;
                }
            }
        }

        public int OptionalCheck(List<Requirement> tempList, Stat stat)
        {
            int tempCheck = tempList.Count();
            foreach (Requirement req in tempList)
            {
                if (stat.Value == req.Value)
                {
                    return tempCheck;
                }
            }
            return 0;
        }
    }
}
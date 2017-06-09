using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoDWebBuilder.Models
{
    public class Die
    {
        public int Sides { get; set; }
        public List<int> Rolls { get; set; }
        Random rando = new Random();

        public Die()
        {
            Rolls = new List<int>();
            Sides = 10;
        }

        public Die(int sides)
        {
            Rolls = new List<int>();
            Sides = sides;
        }

        public List<int> Roll(int amount)
        {
            foreach (int roll in Rolls.ToList())
            {
                Rolls.Remove(roll);
            }
            for(int i=0;i<amount;i++)
            {
                Rolls.Add(rando.Next(Sides)+1);
            }
            return Rolls;
        }
    }
}
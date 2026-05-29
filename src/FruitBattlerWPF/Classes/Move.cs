using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBattlerWPF.Classes
{
    public class Move
    {
        public string Name { get; set; }  = string.Empty;
        public Type type { get; set; }
        public int Damage { get; set; }
        public int Duengercost { get; set; }
        public string Description { get; set; } = string.Empty;


        public Move () { }
        public Move(string name, Type type, int damage, int duengercost, string description)
        {
            Name = name;
            this.type = type;
            Damage = damage;
            Duengercost = duengercost;
            Description = description;
        }

        public double UseMove()
        {
            return Damage;
        }
    }
}

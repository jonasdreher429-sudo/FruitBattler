using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBattlerWPF.Classes
{
    public class Move
    {
        public string Name;
        public Type type;
        public int Damage;
        public int Duengercost;
        public string Description;

        public double UseMove()
        {
            return Damage;
        }
    }
}

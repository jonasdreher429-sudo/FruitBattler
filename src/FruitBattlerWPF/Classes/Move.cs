using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBattlerWPF.Classes
{
    public class Move
    {
        public string Name = string.Empty;
        public Type type;
        public int Damage;
        public int Duengercost;
        public string Description = string.Empty;

        public double UseMove()
        {
            return Damage;
        }
    }
}

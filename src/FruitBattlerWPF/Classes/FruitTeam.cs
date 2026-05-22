using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBattlerWPF.Classes
{
    class FruitTeam
    {
        public Fruit[] Fruits { get; set; }
        public int Active_Fruit_Index = 0;

        public FruitTeam(Fruit[] Fruits)
        {
            this.Fruits = Fruits;
        }

        public Fruit GetActiveFruit()
        {
            return Fruits[Active_Fruit_Index];
        }

        public void SwitchFruit(int NewfruitIndex)
        {
            Active_Fruit_Index = NewfruitIndex;
        }

        public bool HasAliveFruit()
        {
            foreach (Fruit f in Fruits)
            {
                if (f.IsAlive)
                    return true;
            }
            return false;
        }




    }
}

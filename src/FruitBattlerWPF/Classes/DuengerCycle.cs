using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FruitBattlerWPF.Classes
{
    class DuengerCycle
    {
        private int CurrentStep;

        public DuengerCycle()
        {
            CurrentStep = 0;
        }

        public int GetdNextValue()
        {
            CurrentStep++;
            return CurrentStep;
        }

        public void Reset()
        {
            CurrentStep = 0;
        }
    }
}

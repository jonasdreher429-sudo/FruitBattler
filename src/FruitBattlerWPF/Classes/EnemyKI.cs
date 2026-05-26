using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBattlerWPF.Classes
{
    class EnemyKI
    {
        public FruitTeam EnemyTeam;
        public int EnemyDuenger;

        public EnemyKI(FruitTeam EnemyTeam, int enemyDuenger)
        {
            this.EnemyTeam = EnemyTeam;
            EnemyDuenger = enemyDuenger;
        }

        public int ChooseMove(FruitTeam PlayerTeam)
        {
            Fruit ActiveEnemyFruit = EnemyTeam.GetActiveFruit();
            Move[] Moveset = ActiveEnemyFruit.MoveSet;

            Fruit PlayerFruit = PlayerTeam.GetActiveFruit();
            int bestmoveidx = -1;
            int idxcounter = 0;
            foreach (Move move in Moveset)
            {
                if (idxcounter == 0)
                {
                    idxcounter++;
                    continue;

                }
                double effectiness = TypeEffective.GetEffectiveness(move.type, PlayerFruit.FruitType);
                if (move.Duengercost > EnemyDuenger)
                    continue;
                if (effectiness == 1)
                {
                    bestmoveidx = idxcounter;
                    break;
                }
                if (effectiness == 0)
                {
                    bestmoveidx = idxcounter;
                    continue;
                }
                if (effectiness == -1)
                {
                    bestmoveidx = idxcounter;
                    continue;
                }
                if (effectiness == -2)
                {
                    bestmoveidx = idxcounter;
                    continue;
                }
                idxcounter++;
            }
            if (bestmoveidx == -1)
            {
                bestmoveidx = 0;
            }
            return bestmoveidx;
        }

    }
}

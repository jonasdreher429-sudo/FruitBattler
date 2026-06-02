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

        public EnemyKI() { }
        public EnemyKI(int enemyDuenger)
        {
            EnemyDuenger = enemyDuenger;
        }

        public void CreateRandomTeam(List<Fruit> allfruits)
        {
            EnemyTeam.Fruits.Clear();

            
            while (EnemyTeam.Fruits.Count < 4)
            {
                int randomFruchtIndex = Random.Shared.Next(0, 12);
                Fruit zufallsFrucht = allfruits[randomFruchtIndex];

                // KI: Gemini 
                // Prompt: (Alter code für die funktion)
                // verbessere nichts würde dieser loop funktionieren um ein komplett unterschiedliches Team zu erstellen
                // KI Start
                bool gibtsSchon = EnemyTeam.Fruits.Any(f => f.Name == zufallsFrucht.Name);
                // KI Ende
                if (!gibtsSchon)
                {
                    EnemyTeam.Fruits.Add(zufallsFrucht);
                }

                
            }

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

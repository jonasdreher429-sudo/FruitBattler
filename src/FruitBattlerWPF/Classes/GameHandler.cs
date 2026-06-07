using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBattlerWPF.Classes
{
    class GameHandler
    {
        public int roundcount;
        public int CurrentDungerPlayer;
        public int CurrentDungerEnemy;
        public FruitTeam CurrentPlayerTeam;
        public FruitTeam CurrentEnemyTeam;
        public Fruit CurrentPlayerFruit { get; private set; }
        public Fruit CurrentEnemyFruit { get; private set; }
        public bool IsGameOver;

        private int[] DuengerCycle = { 1, 2, 3, 4, 5, 2, 3, 4, 5, 3, 4, 5, 4, 5 };
        private int DungerCylceIndex = 0;

        public GameHandler()
        {
            roundcount = 0;
            CurrentDungerPlayer = 2;
            CurrentDungerEnemy = 2;
            IsGameOver = false;
        }

        public GameHandler(FruitTeam playerTeam, FruitTeam enemyTeam) : this()
        {
            CurrentPlayerTeam = playerTeam;
            CurrentEnemyTeam = enemyTeam;
        }

        public void StartGame()
        {
            CurrentPlayerFruit = CurrentPlayerTeam.GetActiveFruit();
            CurrentEnemyFruit = CurrentEnemyTeam.GetActiveFruit();
        }

        public void NextRound()
        {
            roundcount++;

            int dunger = GetNextDuengerValue();
            CurrentPlayerFruit = CurrentPlayerTeam.GetActiveFruit();
            CurrentEnemyFruit = CurrentEnemyTeam.GetActiveFruit();

            CurrentDungerPlayer += dunger;
            CurrentDungerEnemy += dunger;
        }


        public void ApplyMove(Fruit attacker, Fruit defender, Move move)
        {
            if (move.Damage == 0)
                return;

            defender.ReceiveDamage(attacker, move);

            if (!defender.IsAlive)
            {
                HandleFaint();
            }
        }

        public void HandleFaint()
        {
            if (!CurrentPlayerTeam.HasAliveFruit())
            {
                IsGameOver = true;
                return;
            }

            if (!CurrentEnemyTeam.HasAliveFruit())
            {
                IsGameOver = true;
                return;
            }
        }

        public void SwitchFruit(FruitTeam team, int index)
        {
            team.SwitchFruit(index);

            if (team == CurrentPlayerTeam)
            {
                CurrentPlayerFruit = team.GetActiveFruit();
            }
            else
            {
                CurrentEnemyFruit = team.GetActiveFruit();
            }
        }

        public int GetNextDuengerValue()
        {
            if (DungerCylceIndex >= DuengerCycle.Length)
                return 5;

            return DuengerCycle[DungerCylceIndex++];
        }
    }
}

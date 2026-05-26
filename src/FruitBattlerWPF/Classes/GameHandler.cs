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
        public bool IsGameOver;
        public bool PlayerPLaying;
       

        public GameHandler()
        {
            roundcount = 0;
            CurrentDungerPlayer = 0;
            CurrentDungerEnemy = 0;
            IsGameOver = false;
        }

        public GameHandler(FruitTeam PlayerTeam, FruitTeam EnemyTeam) : this()
        {
            CurrentPlayerTeam = PlayerTeam;
            CurrentEnemyTeam = EnemyTeam;
        }

        public void StartGame()
        {

        }

        public void NextRound()
        {

        }

        public int CalculateDamage()
        {

        }

        public void ApplyMove()
        {

        }

        public void HandleFait()
        {

        }

        public void SwitchFruit()
        {

        }

        public int GetNextDuengerValue()
        {

        }


    }
}

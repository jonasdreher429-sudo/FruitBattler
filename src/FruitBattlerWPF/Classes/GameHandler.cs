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
            Logger.Information("GameHandler initialized.");
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
            Logger.Information("Game started.");
        }

        public void NextRound()
        {
            roundcount++;

            int dunger = GetNextDuengerValue();
            CurrentPlayerFruit = CurrentPlayerTeam.GetActiveFruit();
            CurrentEnemyFruit = CurrentEnemyTeam.GetActiveFruit();

            CurrentDungerPlayer += dunger;
            CurrentDungerEnemy += dunger;
            Logger.Debug($"Called NextRound. Round: {roundcount} Duenger: {dunger}. PlayerDunger : {CurrentDungerPlayer}. EnemyDunger: {CurrentDungerEnemy}");
        }


        public void ApplyMove(Fruit attacker, Fruit defender, Move move)
        {
            if (move.Damage == 0)
            {
                Logger.Debug($"{attacker.Name} used {move.Name} (no damage done).");
                return;
            }

            int hpBefore = defender.CurrentHP;
            defender.ReceiveDamage(attacker, move);
            int damageDealt = hpBefore - defender.CurrentHP;
            Logger.Information($"{attacker.Name} used {move.Name} and dealt {damageDealt} damage to {defender.Name} ({hpBefore} HP to {defender.CurrentHP} HP)");

            if (!defender.IsAlive)
            {
                Logger.Information($"{defender.Name} was defeated");
                HandleFaint(defender);
            }
        }

        // KI: Claude
        // Prompt: Füge hinzu das wenn Früchte vom Gegner sterben neue automatisch eingewechselt werden
        // --- KI Start ---
        // HandleFaint bekommt jetzt die gestorbene Frucht übergeben, damit erkannt werden kann,
        // ob es sich um die aktive Gegner-Frucht handelt. Ist das Spiel nicht vorbei und ist die
        // gestorbene Frucht die des Gegners, wird automatisch zur nächsten lebenden Frucht im
        // Gegner-Team gewechselt.
        public void HandleFaint(Fruit defender)
        {
            if (!CurrentPlayerTeam.HasAliveFruit())
            {
                Logger.Information("Player team was defeated so game over.");
                IsGameOver = true;
                return;
            }

            if (!CurrentEnemyTeam.HasAliveFruit())
            {
                Logger.Information("Enemy team was defeated so player wins.");
                IsGameOver = true;
                return;
            }

            if (defender == CurrentEnemyFruit)
            {
                string oldName = CurrentEnemyFruit.Name;
                CurrentEnemyTeam.SwitchToNextAliveFruit();
                CurrentEnemyFruit = CurrentEnemyTeam.GetActiveFruit();
                Logger.Information($"Enemy switched from {oldName} to {CurrentEnemyFruit.Name}");
            }
        }
        // --- KI Ende ---

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

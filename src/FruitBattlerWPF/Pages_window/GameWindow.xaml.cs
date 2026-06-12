using FruitBattlerWPF.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FruitBattlerWPF.Pages_window
{
    /// <summary>
    /// Interaktionslogik für GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GameVisualizer GameVisualizer;
        private GameHandler GameHandler;
        private EnemyKI EnemyKI;
        public GameWindow(FruitTeam playerTeam, FruitTeam enemyTeam, EnemyKI enemyKI)
        {
            InitializeComponent();

            // Claude Prompt: jetzt kommt seltener aber immernoch diese fehlermeldung
            // System.ArgumentException: "Das angegebene Visual-Objekt ist bereits ein
            // untergeordnetes Element eines anderen Visual-Objekts oder der Stamm von "CompositionTarget"."

            EnemyKI = enemyKI;
            GameHandler = new GameHandler(playerTeam, enemyTeam);
            GameVisualizer = new GameVisualizer(GameCanvas, this, playerTeam, enemyKI);

            GameHandler.StartGame();
            GameVisualizer.DrawBattleScene();

            PlaceFruitControls();

            RefreshUI();

            // Claude Prompt: Wie added man für buttons buttonclickevents im code

            // Claude Anfang
            GameVisualizer.ButtonSleep.Click += ButtonSleep_Click;
            GameVisualizer.ButtonAttack1.Click += ButtonAttack1_Click;
            GameVisualizer.ButtonAttack2.Click += ButtonAttack2_Click;
            // Claude Ende
            GameVisualizer.ButtonSwitch1.Click += ButtonSwitch1_Click;
            GameVisualizer.ButtonSwitch2.Click += ButtonSwitch2_Click;
            GameVisualizer.ButtonSwitch3.Click += ButtonSwitch3_Click;
            GameVisualizer.ButtonSwitch4.Click += ButtonSwitch4_Click;
        }

        private void ButtonSwitch1_Click(object sender, RoutedEventArgs e)
        {
            SwitchPlayerFruit(0);
        }

        private void ButtonSwitch2_Click(object sender, RoutedEventArgs e)
        {
            SwitchPlayerFruit(1);
        }

        private void ButtonSwitch3_Click(object sender, RoutedEventArgs e)
        {
            SwitchPlayerFruit(2);
        }

        private void ButtonSwitch4_Click(object sender, RoutedEventArgs e)
        {
            SwitchPlayerFruit(3);
        }

        private void SwitchPlayerFruit(int index)
        {
            Fruit newFruit = GameHandler.CurrentPlayerTeam.Fruits[index];

            // Dont switch if already active in batle
            if (newFruit == GameHandler.CurrentPlayerFruit)
            {
                MessageBox.Show("Diese Frucht ist bereits im Kampf");
                return;
            }

            // Dont switch if fruit is dead
            if (!newFruit.IsAlive)
            {
                MessageBox.Show("Diese Frucht ist tot");
                return;
            }


            // Claude Prompt: Wie wechsle ich die usercontrol der frucht am besten?

            // Claude Anfang
            // FruitControl austauschen
            Fruit oldFruit = GameHandler.CurrentPlayerFruit;
            GameCanvas.Children.Remove(oldFruit.FruitControl);

            GameHandler.SwitchFruit(GameHandler.CurrentPlayerTeam, index);

            // Neues FruitControl adden
            newFruit.FruitControl.RenderTransform = new ScaleTransform(5.0, 5.0);
            newFruit.FruitControl.IsHitTestVisible = false;
            Canvas.SetLeft(newFruit.FruitControl, 200);
            Canvas.SetTop(newFruit.FruitControl, 300);
            GameCanvas.Children.Add(newFruit.FruitControl);

            RefreshUI();

            RefreshUI();
            // Claude Ende

            EnemyAttack();
            CheckIfPLayerLost();

        }

        private void ButtonSleep_Click(object sender, RoutedEventArgs e)
        {
            ExecutePlayerMove(0);
        }

        private void ButtonAttack1_Click(object sender, RoutedEventArgs e)
        {
            ExecutePlayerMove(1);
        }

        private void ButtonAttack2_Click(object sender, RoutedEventArgs e)
        {
            ExecutePlayerMove(2);
        }
        private void EnemyAttack()
        {
            // Enemy Attack
            EnemyKI.EnemyDuenger = GameHandler.CurrentDungerEnemy;
            int enemyMoveIndex = EnemyKI.ChooseMove(GameHandler.CurrentPlayerTeam);
            Move enemyMove = GameHandler.CurrentEnemyFruit.MoveSet[enemyMoveIndex];
            GameHandler.CurrentDungerEnemy -= enemyMove.Duengercost;
            GameHandler.ApplyMove(GameHandler.CurrentEnemyFruit, GameHandler.CurrentPlayerFruit, enemyMove);
            RefreshUI();
        }

        private void CheckIfPLayerLost()
        {
            if (GameHandler.IsGameOver)
            {
                MessageBox.Show("Du hast verloren!");
                this.Close();
                return;
            }

            // New Round and Give dünger
            GameHandler.NextRound();
            RefreshUI();
        }
        private void ExecutePlayerMove(int moveIndex)
        {
            Fruit player = GameHandler.CurrentPlayerFruit;
            Fruit enemy = GameHandler.CurrentEnemyFruit;
            Move move = player.MoveSet[moveIndex];

            // Check for Dünger Cost
            if (move.Duengercost > GameHandler.CurrentDungerPlayer)
            {
                MessageBox.Show("Nicht genug Dünger in der Düngerreserve");
                return;
            }

            // Player Attack
            GameHandler.CurrentDungerPlayer -= move.Duengercost;
            GameHandler.ApplyMove(player, enemy, move);
            RefreshUI();

            if (GameHandler.IsGameOver)
            {
                MessageBox.Show("W");
                this.Close();
                return;
            }

            EnemyAttack();

            CheckIfPLayerLost();

           
            

            
        }
       


        private void PlaceFruitControls()
        {
            Fruit player = GameHandler.CurrentPlayerFruit;
            Fruit enemy = GameHandler.CurrentEnemyFruit;

            // Claude Prompt: wenn ich start, dann windwo close, dann wieder start steht da
            // System.InvalidOperationException: "Bei dem angegebenen Element
            // handelt es sich bereits um das logische untergeordnete Element eines
            // anderen Elements. Führen Sie zuerst eine Trennung

            // Claude Anfang
            // Vom alten Parent trennen falls vorhanden
            if (player.FruitControl.Parent is Panel oldParentPlayer)
                oldParentPlayer.Children.Remove(player.FruitControl);

            if (enemy.FruitControl.Parent is Panel oldParentEnemy)
                oldParentEnemy.Children.Remove(enemy.FruitControl);
            // Claude Ende

            // Claude Prompt1: wie kann ich meine usercontrols größer scalen im gamewindow
            // Claude Prompt2: wie flip ich sie dass sie in die andere horziontale richtung schauen

            // Claude Anfang
            // Skalierung einstellen (2.0 = doppelt so groß)
            player.FruitControl.RenderTransform = new ScaleTransform(5.0, 5.0);
            enemy.FruitControl.RenderTransform = new ScaleTransform(-5.0, 5.0);

            player.FruitControl.IsHitTestVisible = false;
            // Claude Ende




            // Player Fruit Bottom Left where it looks good
            Canvas.SetLeft(player.FruitControl, 200);
            Canvas.SetTop(player.FruitControl, 300);
            GameCanvas.Children.Add(player.FruitControl);

            // Enemy Fruit Top Right where it looks good
            Canvas.SetLeft(enemy.FruitControl, 1300);
            Canvas.SetTop(enemy.FruitControl, 75);
            GameCanvas.Children.Add(enemy.FruitControl);
        }

        private void RefreshUI()
        {
            Fruit player = GameHandler.CurrentPlayerFruit;
            Fruit enemy = GameHandler.CurrentEnemyFruit;

            GameVisualizer.UpdateNames(player, enemy);

            GameVisualizer.RefreshScreen(player.CurrentHP, player.MaxHP, enemy.CurrentHP, enemy.MaxHP, GameHandler.CurrentDungerPlayer);
            GameVisualizer.UpdateMoveButtons(player);
        }
    }
}

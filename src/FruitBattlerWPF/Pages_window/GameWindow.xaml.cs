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

            
            GameVisualizer.ButtonExit.Click += ButtonExit_Click;
        }

        
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            //KI: Claude
            //Prompt: ist es möglich mit einer message box oder so ein ja oder nein zu machen oder muss ich selber ein window erstellen mit zwei Buttons
            //KI: Anfang
            MessageBoxResult result = MessageBox.Show(
            "Willst du das Spiel wirklich verlassen?",
            "Beenden",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }


        private void ButtonSwitch1_Click(object sender, RoutedEventArgs e)
        {
            SwitchPlayerFruit(0);
            GameVisualizer.ButtonSwitch1.BorderBrush = new SolidColorBrush(Color.FromRgb(0xC8, 0xFF, 0x8C));
            GameVisualizer.ButtonSwitch2.BorderBrush = null;
            GameVisualizer.ButtonSwitch3.BorderBrush = null;
            GameVisualizer.ButtonSwitch4.BorderBrush = null;


        }

        private void ButtonSwitch2_Click(object sender, RoutedEventArgs e)
        {
            SwitchPlayerFruit(1);
            GameVisualizer.ButtonSwitch1.BorderBrush = null;
            GameVisualizer.ButtonSwitch2.BorderBrush = new SolidColorBrush(Color.FromRgb(0xC8, 0xFF, 0x8C));
            GameVisualizer.ButtonSwitch3.BorderBrush = null;
            GameVisualizer.ButtonSwitch4.BorderBrush = null;
        }

        private void ButtonSwitch3_Click(object sender, RoutedEventArgs e)
        {
            SwitchPlayerFruit(2);
            GameVisualizer.ButtonSwitch1.BorderBrush = null;
            GameVisualizer.ButtonSwitch2.BorderBrush = null;
            GameVisualizer.ButtonSwitch3.BorderBrush = new SolidColorBrush(Color.FromRgb(0xC8, 0xFF, 0x8C));
            GameVisualizer.ButtonSwitch4.BorderBrush = null;
        }

        private void ButtonSwitch4_Click(object sender, RoutedEventArgs e)
        {
            SwitchPlayerFruit(3);
            GameVisualizer.ButtonSwitch1.BorderBrush = null;
            GameVisualizer.ButtonSwitch2.BorderBrush = null;
            GameVisualizer.ButtonSwitch3.BorderBrush = null;
            GameVisualizer.ButtonSwitch4.BorderBrush = new SolidColorBrush(Color.FromRgb(0xC8, 0xFF, 0x8C));
        }

        private void switchButtonUpdate()
        {
            Fruit player = GameHandler.CurrentPlayerFruit;
            Button[] switchButtons = { GameVisualizer.ButtonSwitch1, GameVisualizer.ButtonSwitch2, GameVisualizer.ButtonSwitch3, GameVisualizer.ButtonSwitch4 };
            foreach (Button button in switchButtons)
            {
                if (button.Name == player.Name)
                {
                    button.Content = $"{player.Name}\n{player.CurrentHP}/{player.MaxHP} HP";

                }
            }
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
            newFruit.FruitControl.IsHitTestVisible = false;
            Canvas.SetLeft(newFruit.FruitControl, 200);
            Canvas.SetTop(newFruit.FruitControl, 300);
            GameCanvas.Children.Add(newFruit.FruitControl);

            // KI: Claude
            // Prompt: Binde die in GameVisualizer programmierte Einwechsel-Animation hier ein
            // --- KI Start ---
            // RenderTransform wird jetzt nicht mehr fix gesetzt, sondern von PlaySwitchInAnimation
            // selbst (startet bei Scale 0 und animiert auf 5.0/5.0 hoch)
            GameVisualizer.PlaySwitchInAnimation(newFruit.FruitControl, 5.0, 5.0);
            // --- KI Ende ---

            RefreshUI();

            RefreshUI();
            // Claude Ende


            if (oldFruit.CheckAlive() == true)
            {
                EnemyAttack();

            }

            switchButtonUpdate();

            CheckIfPLayerLost();

            ReEnableButtons();

        }

        // KI: Claude
        // Prompt: Füge hinzu das wenn Früchte vom Gegner sterben neue automatisch eingewechselt werden
        // --- KI Start ---
        // Analog zu SwitchPlayerFruit, aber für die automatische Einwechslung beim Gegner:
        // altes FruitControl vom Canvas entfernen, neues an der Gegner-Position (1300/75) mit
        // gespiegelter Skalierung (-5.0/5.0) einfügen und die Einwechsel-Animation abspielen.
        private void SwitchEnemyFruitVisual(Fruit oldFruit, Fruit newFruit)
        {
            GameCanvas.Children.Remove(oldFruit.FruitControl);

            if (newFruit.FruitControl.Parent is Panel oldParent)
                oldParent.Children.Remove(newFruit.FruitControl);

            newFruit.FruitControl.IsHitTestVisible = false;
            Canvas.SetLeft(newFruit.FruitControl, 1300);
            Canvas.SetTop(newFruit.FruitControl, 75);
            GameCanvas.Children.Add(newFruit.FruitControl);

            GameVisualizer.PlaySwitchInAnimation(newFruit.FruitControl, -5.0, 5.0);
        }
        // --- KI Ende ---

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

            // KI: Claude
            // Prompt: Binde die in GameVisualizer programmierte Schadenszahlen-Animation hier ein.
            // HP vorher/nachher vergleichen, da Move.Damage nur der Basiswert ist und nicht der
            // tatsächliche Schaden nach der Formel in Fruit.ReceiveDamage
            // --- KI Start ---
            int playerHpBefore = GameHandler.CurrentPlayerFruit.CurrentHP;
            GameHandler.ApplyMove(GameHandler.CurrentEnemyFruit, GameHandler.CurrentPlayerFruit, enemyMove);
            int damageDealt = playerHpBefore - GameHandler.CurrentPlayerFruit.CurrentHP;
            if (damageDealt > 0)
                GameVisualizer.ShowDamageText(damageDealt, true);
            // --- KI Ende ---

            RefreshUI();
        }

        private bool CheckIfPLayerLost()
        {
            if (GameHandler.IsGameOver)
            {
                MessageBox.Show("Du hast verloren!");
                this.Close();
                return true;
            }

            // New Round and Give dünger
            GameHandler.NextRound();
            RefreshUI();
            return false;
        }

        

        private void DisableButtons()
        {
            GameVisualizer.ButtonSleep.IsEnabled = false;
            GameVisualizer.ButtonAttack1.IsEnabled = false;
            GameVisualizer.ButtonAttack2.IsEnabled = false;


        }

        private void ReEnableButtons()
        {
            GameVisualizer.ButtonSleep.IsEnabled = true;
            GameVisualizer.ButtonAttack1.IsEnabled = true;
            GameVisualizer.ButtonAttack2.IsEnabled = true;
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

            // KI: Claude
            // Prompt: Binde die in GameVisualizer programmierte Schadenszahlen-Animation hier ein.
            // HP vorher/nachher vergleichen, da Move.Damage nur der Basiswert ist und nicht der
            // tatsächliche Schaden nach der Formel in Fruit.ReceiveDamage
            // --- KI Start ---
            int enemyHpBefore = enemy.CurrentHP;
            GameHandler.ApplyMove(player, enemy, move);
            int damageDealt = enemyHpBefore - enemy.CurrentHP;
            if (damageDealt > 0)
                GameVisualizer.ShowDamageText(damageDealt, false);
            // --- KI Ende ---

            // KI: Claude
            // Prompt: Füge hinzu das wenn Früchte vom Gegner sterben neue automatisch eingewechselt werden
            // --- KI Start ---
            // GameHandler.HandleFaint wechselt CurrentEnemyFruit bereits intern auf die nächste
            // lebende Frucht, falls die aktive Gegner-Frucht gestorben ist. Hier wird das nur noch
            // visuell auf dem Canvas nachgezogen (altes FruitControl entfernen, neues mit Animation
            // einblenden), falls sich CurrentEnemyFruit geändert hat.
            if (GameHandler.CurrentEnemyFruit != enemy && !GameHandler.IsGameOver)
            {
                SwitchEnemyFruitVisual(enemy, GameHandler.CurrentEnemyFruit);
            }
            // --- KI Ende ---

            RefreshUI();

            if (GameHandler.IsGameOver)
            {
                MessageBox.Show("DU hast gewonnen, gut gespielt!");
                this.Close();
                return;
            }

            // KI: Claude
            // Prompt: füge hinzu wenn ich die gegnerische frucht besiege das sie mich dann tot nicht noch angreifen kann
            // --- KI Start ---
            // Wenn die gegnerische Frucht durch diesen Zug gestorben ist, wird automatisch eine
            // neue eingewechselt (siehe oben), aber sie soll in diesem Zug nicht mehr angreifen
            // können. Daher wird EnemyAttack() in diesem Fall übersprungen.
            if (enemy.IsAlive)
            {
                EnemyAttack();
            }
            // --- KI Ende ---
            switchButtonUpdate();

            bool loss = CheckIfPLayerLost();

            bool FruitDead = player.CheckAlive();
            if (FruitDead == false)
            {
                DisableButtons();
                if (loss== false)
                    MessageBox.Show("Deine Frucht ist gestorben bitte wechsle deine Frucht aus");

            }


            
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

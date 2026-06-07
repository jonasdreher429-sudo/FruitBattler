using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FruitBattlerWPF.Classes
{
    public class GameVisualizer
    {
        private Canvas GameCanvas;
        private Window CurrentWindow;
        public Button ButtonSleep = new Button();
        public Button ButtonAttack1 = new Button();
        public Button ButtonAttack2 = new Button();
        private ProgressBar ProgressBarPlayerHealth = new ProgressBar();
        private Label LabelPlayerHealth = new Label();
        private ProgressBar ProgressBarEnemyHealth = new ProgressBar();
        private Label LabelEnemyHealth = new Label();
        private Label LabelDungerCounter = new Label();
        private Label LabelMoveCost1 = new Label();
        private Label LabelMoveCost2 = new Label();
        private Label LabelMoveCost3 = new Label();
        public Button ButtonSwitch1 = new Button();
        public Button ButtonSwitch2 = new Button();
        public Button ButtonSwitch3 = new Button();
        public Button ButtonSwitch4 = new Button();



        public GameVisualizer(Canvas canvas, Window window)
        {
            this.GameCanvas = canvas;
            this.CurrentWindow = window;
        }

        private void AddSwitchButtons()
        {
            // Switchbuttons
            ButtonSwitch1.Content = "1";
            ButtonSwitch1.Width = 75;
            ButtonSwitch1.Height = 75;

            ButtonSwitch2.Content = "2";
            ButtonSwitch2.Width = 75;
            ButtonSwitch2.Height = 75;

            ButtonSwitch3.Content = "3";
            ButtonSwitch3.Width = 75;
            ButtonSwitch3.Height = 75;

            ButtonSwitch4.Content = "4";
            ButtonSwitch4.Width = 75;
            ButtonSwitch4.Height = 75;

            // Move SwitchButtons
            Canvas.SetLeft(ButtonSwitch1, 50);
            Canvas.SetTop(ButtonSwitch1, 200);

            Canvas.SetLeft(ButtonSwitch2, 50);
            Canvas.SetTop(ButtonSwitch2, 300);

            Canvas.SetLeft(ButtonSwitch3, 50);
            Canvas.SetTop(ButtonSwitch3, 400);

            Canvas.SetLeft(ButtonSwitch4, 50);
            Canvas.SetTop(ButtonSwitch4, 500);

            // Place Switchbuttons on Canvas
            GameCanvas.Children.Add(ButtonSwitch1);
            GameCanvas.Children.Add(ButtonSwitch2);
            GameCanvas.Children.Add(ButtonSwitch3);
            GameCanvas.Children.Add(ButtonSwitch4);
        }
        private void AddButtons()
        {
            // Button Width, Height and Default empty content
            ButtonSleep.Content = "NONE";
            ButtonSleep.Width = 100;
            ButtonSleep.Height = 75;

            ButtonAttack1.Content = "NONE";
            ButtonAttack1.Width = 100;
            ButtonAttack1.Height = 75;

            ButtonAttack2.Content = "NONE";
            ButtonAttack2.Width = 100;
            ButtonAttack2.Height = 75;

            // Changing Button Position
            Canvas.SetLeft(ButtonSleep, 840);
            Canvas.SetTop(ButtonSleep, 475);

            Canvas.SetLeft(ButtonAttack1, 990);
            Canvas.SetTop(ButtonAttack1, 475);

            Canvas.SetLeft(ButtonAttack2, 1140);
            Canvas.SetTop(ButtonAttack2, 475);

            // Labels below Buttons with Default Content "Dünger: 0"
            LabelMoveCost1.Content = "Dünger: 0";
            LabelMoveCost1.Width = 100;
            LabelMoveCost1.Height = 30;
            

            LabelMoveCost2.Content = "Dünger: 0";
            LabelMoveCost2.Width = 100;
            LabelMoveCost2.Height = 30;
            

            LabelMoveCost3.Content = "Dünger: 0";
            LabelMoveCost3.Width = 100;
            LabelMoveCost3.Height = 30;
            
            // Moving Labels
            Canvas.SetLeft(LabelMoveCost1, 840);
            Canvas.SetTop(LabelMoveCost1, 550);

            Canvas.SetLeft(LabelMoveCost2, 990);
            Canvas.SetTop(LabelMoveCost2, 550);

            Canvas.SetLeft(LabelMoveCost3, 1140);
            Canvas.SetTop(LabelMoveCost3, 550);

            // Adding Buttons and Labels to Canvas
            GameCanvas.Children.Add(ButtonSleep);
            GameCanvas.Children.Add(ButtonAttack1);
            GameCanvas.Children.Add(ButtonAttack2);

            GameCanvas.Children.Add(LabelMoveCost1);
            GameCanvas.Children.Add(LabelMoveCost2);
            GameCanvas.Children.Add(LabelMoveCost3);
        }


        private void AddPlayerHealthBar()
        {
            // HP Bar Width and Heigth
            ProgressBarPlayerHealth.Width = 300;
            ProgressBarPlayerHealth.Height = 50;

            // HP Label Width and Heigth
            LabelPlayerHealth.Width = 100;
            LabelPlayerHealth.Height = 100;
            LabelPlayerHealth.Content = "NONE";

            // Changing Position of HP Bar and HP Label
            Canvas.SetLeft(ProgressBarPlayerHealth, 840);
            Canvas.SetTop(ProgressBarPlayerHealth, 600);
            Canvas.SetLeft(LabelPlayerHealth, 840);
            Canvas.SetTop(LabelPlayerHealth, 575);

            // Adding HP Bar and HP Label to Canvas
            GameCanvas.Children.Add(ProgressBarPlayerHealth);
            GameCanvas.Children.Add(LabelPlayerHealth);
        }

        private void AddDungerCounter()
        {
            // Label Width and Height and Default empty content
            LabelDungerCounter.Content = "Dünger: NONE";
            LabelDungerCounter.Width = 100;
            LabelDungerCounter.Height = 100;

            // Changing Label Position
            Canvas.SetLeft(LabelDungerCounter, 700);
            Canvas.SetTop(LabelDungerCounter, 550);

            // Adding Label to Canvas
            GameCanvas.Children.Add(LabelDungerCounter);
        }

        private void AddPlayerSection()
        {
            AddButtons();
            AddPlayerHealthBar();
            AddDungerCounter();
            AddSwitchButtons();
        }

        private void AddEnemyHealthBar()
        {
            // HP Bar Width and Heigth
            ProgressBarEnemyHealth.Width = 300;
            ProgressBarEnemyHealth.Height = 50;

            // HP Label Width and Heigth
            LabelEnemyHealth.Width = 100;
            LabelEnemyHealth.Height = 100;
            LabelEnemyHealth.Content = "NONE";

            // Changing Position of HP Bar and HP Label
            Canvas.SetLeft(ProgressBarEnemyHealth, 80);
            Canvas.SetTop(ProgressBarEnemyHealth, 50);

            Canvas.SetLeft(LabelEnemyHealth, 80);
            Canvas.SetTop(LabelEnemyHealth, 25);

            // Adding HP Bar and HP Label to Canvas
            GameCanvas.Children.Add(ProgressBarEnemyHealth);
            GameCanvas.Children.Add(LabelEnemyHealth);
        }

        private void AddEnemySection()
        {
            AddEnemyHealthBar();
        }

        public void DrawBattleScene()
        {
            GameCanvas.Children.Clear();
            AddPlayerSection();
            AddEnemySection();
        }



        private void UpdateHPBars(int PlayerHP, int PlayerMaxHP, int EnemyHP, int EnemyMaxHP)
        {
            // Changing HP Bar Values
            ProgressBarPlayerHealth.Maximum = PlayerMaxHP;
            ProgressBarEnemyHealth.Maximum = EnemyMaxHP;
            ProgressBarPlayerHealth.Value = PlayerHP;
            ProgressBarEnemyHealth.Value = EnemyHP;

            // Changing Labels
            LabelPlayerHealth.Content = $"{PlayerHP}/{PlayerMaxHP}";
            LabelEnemyHealth.Content = $"{EnemyHP}/{EnemyMaxHP}";
        }



        private void UpdateDungerUI(int NewDungerCount)
        {
            LabelDungerCounter.Content = $"Dünger: {NewDungerCount}";
        }



        public void RefreshScreen(int PlayerHP, int PlayerMaxHP, int EnemyHP, int EnemyMaxHP, int NewDungerCount)
        {
            UpdateHPBars(PlayerHP, PlayerMaxHP, EnemyHP, EnemyMaxHP);
            UpdateDungerUI(NewDungerCount);
        }

        private void PlayAttackAnimation()
        {
            // Not so important for now
        }

        private void ShowDamageText()
        {
            // Not so important for now
        }

        public void UpdateMoveButtons(Fruit playerFruit)
        {
            ButtonSleep.Content = playerFruit.MoveSet[0].Name;
            ButtonAttack1.Content = playerFruit.MoveSet[1].Name;
            ButtonAttack2.Content = playerFruit.MoveSet[2].Name;

            LabelMoveCost1.Content = $"Dünger: {playerFruit.MoveSet[0].Duengercost}";
            LabelMoveCost2.Content = $"Dünger: {playerFruit.MoveSet[1].Duengercost}";
            LabelMoveCost3.Content = $"Dünger: {playerFruit.MoveSet[2].Duengercost}";
        }
    }
}

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
        private Button ButtonSleep = new Button();
        private Button ButtonAttack1 = new Button();
        private Button ButtonAttack2 = new Button();
        private ProgressBar ProgressBarPlayerHealth = new ProgressBar();
        private Label LabelPlayerHealth = new Label();
        private ProgressBar ProgressBarEnemyHealth = new ProgressBar();
        private Label LabelEnemyHealth = new Label();
        private Label LabelDungerCounter = new Label();



        public GameVisualizer(Canvas canvas, Window window)
        {
            this.GameCanvas = canvas;
            this.CurrentWindow = window;
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

            // Adding Buttons to Canvas
            GameCanvas.Children.Add(ButtonSleep);
            GameCanvas.Children.Add(ButtonAttack1);
            GameCanvas.Children.Add(ButtonAttack2);
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



        public void SwitchMenuView()
        {
            // Add this with the implementation of Pages
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
    }
}

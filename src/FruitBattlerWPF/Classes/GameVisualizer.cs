using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

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
        private Label LabelPlayerName = new Label();
        private Label LabelEnemyName = new Label();
        // KI: Claude
        // Prompt: Füge oben rechts einen Exit-Button im gleichen Stil wie die anderen Buttons hinzu
        // --- KI Start ---
        public Button ButtonExit = new Button();
        // --- KI Ende ---

        // KI: Claude
        // Prompt: Füge FruitTeam und EnemyKI zum Konstruktor hinzu damit Moves, HP und Switch-Buttons mit echten Daten befüllt werden
        // --- KI Start ---
        private FruitTeam PlayerTeam;
        private EnemyKI Enemy;

        public GameVisualizer(Canvas canvas, Window window, FruitTeam playerTeam, EnemyKI enemy)
        {
            this.GameCanvas = canvas;
            this.CurrentWindow = window;
            this.PlayerTeam = playerTeam;
            this.Enemy = enemy;
        }

        private void AddSwitchButtons()
        {
            Button[] switchButtons = { ButtonSwitch1, ButtonSwitch2, ButtonSwitch3, ButtonSwitch4 };
            double[] yPositions = { 460, 530, 600, 670 };

            for (int i = 0; i < PlayerTeam.Fruits.Count && i < 4; i++)
            {
                Fruit fruit = PlayerTeam.Fruits[i];
                switchButtons[i].Content = $"{fruit.Name}\n{fruit.CurrentHP}/{fruit.MaxHP} HP";
                switchButtons[i].Name = fruit.Name;
                switchButtons[i].Width = 160;
                switchButtons[i].Height = 55;
                switchButtons[i].Background = new SolidColorBrush(Color.FromArgb(0xCC, 0x2F, 0x6A, 0x24));
                switchButtons[i].Foreground = new SolidColorBrush(Colors.White);
                switchButtons[i].BorderBrush = new SolidColorBrush(Color.FromRgb(0xC8, 0xFF, 0x8C));
                switchButtons[i].BorderThickness = new Thickness(i == PlayerTeam.Active_Fruit_Index ? 3 : 1);
                switchButtons[i].FontSize = 12;

                Canvas.SetLeft(switchButtons[i], 20);
                Canvas.SetTop(switchButtons[i], yPositions[i]);
                GameCanvas.Children.Add(switchButtons[i]);
            }
        }
        private void AddButtons()
        {
            Fruit activeFruit = PlayerTeam.GetActiveFruit();
            Move[] moves = activeFruit.MoveSet;

            // Move 0 = Sleep
            ButtonSleep.Content = $"{moves[0].Name}\n({moves[0].Duengercost} 🌿)";
            ButtonSleep.Width = 120;
            ButtonSleep.Height = 75;

            // Move 1
            ButtonAttack1.Content = $"{moves[1].Name}\n({moves[1].Duengercost} 🌿)";
            ButtonAttack1.Width = 120;
            ButtonAttack1.Height = 75;

            // Move 2
            ButtonAttack2.Content = $"{moves[2].Name}\n({moves[2].Duengercost} 🌿)";
            ButtonAttack2.Width = 120;
            ButtonAttack2.Height = 75;

            Canvas.SetLeft(ButtonSleep, 830);
            Canvas.SetTop(ButtonSleep, 560);

            Canvas.SetLeft(ButtonAttack1, 980);
            Canvas.SetTop(ButtonAttack1, 560);

            Canvas.SetLeft(ButtonAttack2, 1130);
            Canvas.SetTop(ButtonAttack2, 560);

            // Labels below Buttons with move costs
            LabelMoveCost1.Content = $"Dünger: {moves[0].Duengercost}";
            LabelMoveCost1.Width = 100;
            LabelMoveCost1.Height = 30;

            LabelMoveCost2.Content = $"Dünger: {moves[1].Duengercost}";
            LabelMoveCost2.Width = 100;
            LabelMoveCost2.Height = 30;

            LabelMoveCost3.Content = $"Dünger: {moves[2].Duengercost}";
            LabelMoveCost3.Width = 100;
            LabelMoveCost3.Height = 30;

            Canvas.SetLeft(LabelMoveCost1, 840);
            Canvas.SetTop(LabelMoveCost1, 640);

            Canvas.SetLeft(LabelMoveCost2, 990);
            Canvas.SetTop(LabelMoveCost2, 640);

            Canvas.SetLeft(LabelMoveCost3, 1140);
            Canvas.SetTop(LabelMoveCost3, 640);

            GameCanvas.Children.Add(ButtonSleep);
            GameCanvas.Children.Add(ButtonAttack1);
            GameCanvas.Children.Add(ButtonAttack2);

            GameCanvas.Children.Add(LabelMoveCost1);
            GameCanvas.Children.Add(LabelMoveCost2);
            GameCanvas.Children.Add(LabelMoveCost3);
        }


        private void AddPlayerHealthBar()
        {
            Fruit active = PlayerTeam.GetActiveFruit();

            // Fruit name label
            LabelPlayerName.Content = active.Name;
            LabelPlayerName.Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0xFF, 0xB2));
            LabelPlayerName.FontSize = 18;
            LabelPlayerName.FontWeight = FontWeights.Bold;
            LabelPlayerName.Width = 300;
            LabelPlayerName.Height = 30;
            Canvas.SetLeft(LabelPlayerName, 830);
            Canvas.SetTop(LabelPlayerName, 460);
            GameCanvas.Children.Add(LabelPlayerName);

            ProgressBarPlayerHealth.Width = 300;
            ProgressBarPlayerHealth.Height = 22;
            ProgressBarPlayerHealth.Maximum = active.MaxHP;
            ProgressBarPlayerHealth.Value = active.CurrentHP;
            ProgressBarPlayerHealth.Foreground = new SolidColorBrush(Color.FromRgb(0x7E, 0xD9, 0x57));

            LabelPlayerHealth.Width = 150;
            LabelPlayerHealth.Height = 26;
            LabelPlayerHealth.Content = $"{active.CurrentHP} / {active.MaxHP} HP";
            LabelPlayerHealth.Foreground = new SolidColorBrush(Colors.White);
            LabelPlayerHealth.FontSize = 13;

            Canvas.SetLeft(ProgressBarPlayerHealth, 830);
            Canvas.SetTop(ProgressBarPlayerHealth, 492);
            Canvas.SetLeft(LabelPlayerHealth, 830);
            Canvas.SetTop(LabelPlayerHealth, 516);

            GameCanvas.Children.Add(ProgressBarPlayerHealth);
            GameCanvas.Children.Add(LabelPlayerHealth);
        }

        private void AddDungerCounter()
        {
            LabelDungerCounter.Content = "🌿 Dünger: 2";
            LabelDungerCounter.Foreground = new SolidColorBrush(Color.FromRgb(0xC8, 0xFF, 0x8C));
            LabelDungerCounter.FontSize = 16;
            LabelDungerCounter.FontWeight = FontWeights.Bold;
            LabelDungerCounter.Width = 150;
            LabelDungerCounter.Height = 30;

            Canvas.SetLeft(LabelDungerCounter, 830);
            Canvas.SetTop(LabelDungerCounter, 530);

            GameCanvas.Children.Add(LabelDungerCounter);
        }

        private void AddPlayerSection()
        {
            AddSwitchButtons();
            AddButtons();
            AddPlayerHealthBar();
            AddDungerCounter();
        }

        private void AddEnemyHealthBar()
        {
            Fruit activeEnemy = Enemy.EnemyTeam.GetActiveFruit();

            LabelEnemyName.Content = activeEnemy.Name;
            LabelEnemyName.Foreground = new SolidColorBrush(Color.FromRgb(0xF7, 0xFF, 0xB2));
            LabelEnemyName.FontSize = 18;
            LabelEnemyName.FontWeight = FontWeights.Bold;
            LabelEnemyName.Width = 300;
            LabelEnemyName.Height = 30;
            
            Canvas.SetLeft(LabelEnemyName, 80);
            Canvas.SetTop(LabelEnemyName, 20);
            GameCanvas.Children.Add(LabelEnemyName);

            ProgressBarEnemyHealth.Width = 300;
            ProgressBarEnemyHealth.Height = 22;
            ProgressBarEnemyHealth.Maximum = activeEnemy.MaxHP;
            ProgressBarEnemyHealth.Value = activeEnemy.CurrentHP;
            ProgressBarEnemyHealth.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0x6B, 0x6B));

            LabelEnemyHealth.Width = 150;
            LabelEnemyHealth.Height = 26;
            LabelEnemyHealth.Content = $"{activeEnemy.CurrentHP} / {activeEnemy.MaxHP} HP";
            LabelEnemyHealth.Foreground = new SolidColorBrush(Colors.White);
            LabelEnemyHealth.FontSize = 13;

            Canvas.SetLeft(ProgressBarEnemyHealth, 80);
            Canvas.SetTop(ProgressBarEnemyHealth, 52);
            Canvas.SetLeft(LabelEnemyHealth, 80);
            Canvas.SetTop(LabelEnemyHealth, 76);

            GameCanvas.Children.Add(ProgressBarEnemyHealth);
            GameCanvas.Children.Add(LabelEnemyHealth);
        }

        private void AddEnemySection()
        {
            AddEnemyHealthBar();
        }

        // KI: Claude
        // Prompt: Füge oben rechts einen Exit-Button im gleichen Stil wie die anderen Buttons hinzu
        // --- KI Start ---
        private void AddExitButton()
        {
            ButtonExit.Content = "Exit";
            ButtonExit.Width = 90;
            ButtonExit.Height = 40;
            ButtonExit.Background = new SolidColorBrush(Color.FromArgb(0xCC, 0x2F, 0x6A, 0x24));
            ButtonExit.Foreground = new SolidColorBrush(Colors.White);
            ButtonExit.BorderBrush = new SolidColorBrush(Color.FromRgb(0xC8, 0xFF, 0x8C));
            ButtonExit.BorderThickness = new Thickness(1);
            ButtonExit.FontSize = 14;

            Canvas.SetLeft(ButtonExit, CurrentWindow.Width - ButtonExit.Width - 20);
            Canvas.SetTop(ButtonExit, 20);

            GameCanvas.Children.Add(ButtonExit);
        }
        // --- KI Ende ---

        public void DrawBattleScene()
        {
            GameCanvas.Children.Clear();
            DrawBackground();
            AddPlayerSection();
            AddEnemySection();
            AddExitButton();
        }
        // --- KI Ende ---

        // KI: Claude
        // Prompt: Create a well-looking battle scene background for a WPF Canvas (1280x720)
        // that matches the green nature theme of FruitBattler (dark green #1E3B1E, gradients
        // #87D86D to #3D7A32, accent #C8FF8C). Include sky, ground, hills and decorative clouds.
        // --- KI Start ---
        private void DrawBackground()
        {
            // KI: Claude
            // Prompt: Behebe den Bug, dass rechts und unten weiße Streifen zu sehen sind.
            // Ursache: Hintergrund (sky/ground/vignette) war fix auf 1280x720 gerendert,
            // das GameWindow ist aber 1400x800 groß -> Canvas war größer als der Hintergrund.
            // Fix: Hintergrundgröße von der tatsächlichen Fenstergröße ableiten statt sie
            // hart zu codieren, restliche Layer (sky/ground/vignette) werden proportional
            // dazu skaliert.
            // --- KI Start ---
            double bgWidth = CurrentWindow.Width;
            double bgHeight = CurrentWindow.Height;

            double skyHeight = bgHeight * (470.0 / 720.0);
            double groundTop = bgHeight * (440.0 / 720.0);
            double groundHeight = bgHeight * (280.0 / 720.0);
            double groundLineTop = bgHeight * (437.0 / 720.0);
            // --- KI Ende ---

            // Sky gradient (top 65%)
            Rectangle sky = new Rectangle
            {
                Width = bgWidth,
                Height = skyHeight
            };
            sky.Fill = new LinearGradientBrush(
                new GradientStopCollection
                {
                    new GradientStop(Color.FromRgb(0x4A, 0x8C, 0x6A), 0.0),
                    new GradientStop(Color.FromRgb(0x87, 0xD8, 0x6D), 1.0)
                },
                new Point(0, 0), new Point(0, 1));
            Canvas.SetLeft(sky, 0);
            Canvas.SetTop(sky, 0);
            GameCanvas.Children.Add(sky);

            // Ground (bottom 35%)
            Rectangle ground = new Rectangle
            {
                Width = bgWidth,
                Height = groundHeight
            };
            ground.Fill = new LinearGradientBrush(
                new GradientStopCollection
                {
                    new GradientStop(Color.FromRgb(0x3E, 0x8A, 0x2F), 0.0),
                    new GradientStop(Color.FromRgb(0x1E, 0x3B, 0x1E), 1.0)
                },
                new Point(0, 0), new Point(0, 1));
            Canvas.SetLeft(ground, 0);
            Canvas.SetTop(ground, groundTop);
            GameCanvas.Children.Add(ground);

            // Background hills
            Ellipse hillLeft = new Ellipse
            {
                Width = 700,
                Height = 300,
                Fill = new SolidColorBrush(Color.FromArgb(0xCC, 0x2F, 0x6A, 0x24))
            };
            Canvas.SetLeft(hillLeft, -180);
            Canvas.SetTop(hillLeft, 320);
            GameCanvas.Children.Add(hillLeft);

            Ellipse hillRight = new Ellipse
            {
                Width = 600,
                Height = 260,
                Fill = new SolidColorBrush(Color.FromArgb(0xCC, 0x3E, 0x8A, 0x2F))
            };
            Canvas.SetLeft(hillRight, 880);
            Canvas.SetTop(hillRight, 340);
            GameCanvas.Children.Add(hillRight);

            Ellipse hillCenter = new Ellipse
            {
                Width = 500,
                Height = 200,
                Fill = new SolidColorBrush(Color.FromArgb(0x99, 0x7E, 0xD9, 0x57))
            };
            Canvas.SetLeft(hillCenter, 390);
            Canvas.SetTop(hillCenter, 360);
            GameCanvas.Children.Add(hillCenter);

            // Ground dividing line (bright accent strip)
            // KI: Claude (Teil desselben Fixes wie oben) - Width/Top jetzt dynamisch statt 1280/437
            Rectangle groundLine = new Rectangle
            {
                Width = bgWidth,
                Height = 6,
                Fill = new SolidColorBrush(Color.FromArgb(0xAA, 0xC8, 0xFF, 0x8C))
            };
            Canvas.SetLeft(groundLine, 0);
            Canvas.SetTop(groundLine, groundLineTop);
            GameCanvas.Children.Add(groundLine);

            // Decorative clouds
            AddCloud(80, 60, 1.0);
            AddCloud(380, 40, 0.75);
            AddCloud(750, 80, 0.9);
            AddCloud(1050, 50, 0.65);

            // Subtle vignette overlay (dark edges)
            // KI: Claude (Teil desselben Fixes wie oben) - Width/Height jetzt dynamisch statt 1280/720
            Rectangle vignette = new Rectangle
            {
                Width = bgWidth,
                Height = bgHeight,
                IsHitTestVisible = false
            };
            RadialGradientBrush vignetteBrush = new RadialGradientBrush();
            vignetteBrush.GradientOrigin = new Point(0.5, 0.5);
            vignetteBrush.Center = new Point(0.5, 0.5);
            vignetteBrush.RadiusX = 0.75;
            vignetteBrush.RadiusY = 0.75;
            vignetteBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0x00, 0, 0, 0), 0.0));
            vignetteBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0x88, 0x1E, 0x3B, 0x1E), 1.0));
            vignette.Fill = vignetteBrush;
            Canvas.SetLeft(vignette, 0);
            Canvas.SetTop(vignette, 0);
            GameCanvas.Children.Add(vignette);
        }

        private void AddCloud(double x, double y, double opacity)
        {
            for (int i = 0; i < 3; i++)
            {
                Ellipse puff = new Ellipse
                {
                    Width = 90 + i * 20,
                    Height = 55 + i * 10,
                    Fill = new SolidColorBrush(Color.FromArgb(
                        (byte)(200 * opacity), 0xF7, 0xFF, 0xB2)),
                    Opacity = opacity * (0.5 - i * 0.1)
                };
                Canvas.SetLeft(puff, x + i * 45);
                Canvas.SetTop(puff, y + (i == 1 ? -15 : 0));
                GameCanvas.Children.Add(puff);
            }
        }
        // --- KI Ende ---



        private void UpdateHPBars(int PlayerHP, int PlayerMaxHP, int EnemyHP, int EnemyMaxHP)
        {
            // Changing HP Bar Values
            ProgressBarPlayerHealth.Maximum = PlayerMaxHP;
            ProgressBarEnemyHealth.Maximum = EnemyMaxHP;

            // KI: Claude
            // Prompt: Die Healthbar soll nach erhaltenem Schaden nicht sofort auf den neuen Wert springen,
            // sondern langsam (animiert) runtergehen
            // --- KI Start ---
            AnimateHealthBarValue(ProgressBarPlayerHealth, PlayerHP);
            AnimateHealthBarValue(ProgressBarEnemyHealth, EnemyHP);
            // --- KI Ende ---

            // Changing Labels
            LabelPlayerHealth.Content = $"{PlayerHP}/{PlayerMaxHP}";
            LabelEnemyHealth.Content = $"{EnemyHP}/{EnemyMaxHP}";
        }

        // KI: Claude
        // Prompt: Erstelle eine Methode, die den Value einer ProgressBar (Healthbar) nicht direkt setzt,
        // sondern langsam (mit Animation) zum neuen Wert hin verändert
        // --- KI Start ---
        private void AnimateHealthBarValue(ProgressBar healthBar, double newValue)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                To = newValue,
                Duration = TimeSpan.FromSeconds(0.6),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            healthBar.BeginAnimation(ProgressBar.ValueProperty, animation);
        }
        // --- KI Ende ---



        private void UpdateDungerUI(int NewDungerCount)
        {
            LabelDungerCounter.Content = $"Dünger: {NewDungerCount}";
        }


        public void UpdateNames(Fruit player, Fruit enemy)
        {
            LabelPlayerName.Content = player.Name;
            LabelEnemyName.Content = enemy.Name;
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

        // KI: Claude
        // Prompt: Erstelle eine Methode die eine Schadenszahl über der Healthbar (Spieler oder Gegner)
        // einblendet, nach oben schweben lässt und dabei langsam ausblendet. Danach soll sie wieder
        // vom Canvas entfernt werden, damit sich keine alten Texte ansammeln
        // --- KI Start ---
        public void ShowDamageText(int damage, bool isPlayer)
        {
            TextBlock damageText = new TextBlock
            {
                Text = $"-{damage}",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0x4C, 0x4C))
            };

            // Healthbar des Spielers liegt bei (830, 492), die des Gegners bei (80, 52)
            double left = isPlayer ? 900 : 150;
            double top = isPlayer ? 470 : 30;

            Canvas.SetLeft(damageText, left);
            Canvas.SetTop(damageText, top);
            GameCanvas.Children.Add(damageText);

            TranslateTransform moveTransform = new TranslateTransform(0, 0);
            damageText.RenderTransform = moveTransform;

            DoubleAnimation moveUpAnimation = new DoubleAnimation
            {
                From = 0,
                To = -40,
                Duration = TimeSpan.FromSeconds(0.9),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                BeginTime = TimeSpan.FromSeconds(0.3),
                Duration = TimeSpan.FromSeconds(0.6)
            };

            fadeOutAnimation.Completed += (sender, e) =>
            {
                GameCanvas.Children.Remove(damageText);
            };

            moveTransform.BeginAnimation(TranslateTransform.YProperty, moveUpAnimation);
            damageText.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
        }
        // --- KI Ende ---

        // KI: Claude
        // Prompt: Erstelle eine kleine Animation für das Einwechseln einer Frucht: das FruitControl soll
        // klein und unsichtbar starten und dann mit einem leichten "Bounce" auf seine Zielgröße
        // hochskalieren und gleichzeitig einblenden (Fade-In)
        // --- KI Start ---
        public void PlaySwitchInAnimation(UserControl fruitControl, double targetScaleX, double targetScaleY)
        {
            ScaleTransform scaleTransform = new ScaleTransform(0, 0);
            fruitControl.RenderTransform = scaleTransform;
            fruitControl.Opacity = 0;

            DoubleAnimation scaleXAnimation = new DoubleAnimation
            {
                From = 0,
                To = targetScaleX,
                Duration = TimeSpan.FromSeconds(0.4),
                EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.4 }
            };

            DoubleAnimation scaleYAnimation = new DoubleAnimation
            {
                From = 0,
                To = targetScaleY,
                Duration = TimeSpan.FromSeconds(0.4),
                EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.4 }
            };

            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleXAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleYAnimation);
            fruitControl.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
        }
        // --- KI Ende ---

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

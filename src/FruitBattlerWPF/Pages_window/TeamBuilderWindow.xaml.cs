using FruitBattlerWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaktionslogik für TeamBuilderWindow.xaml
    /// </summary>
    public partial class TeamBuilderWindow : Window
    {

        public Fruit CurrentSeletcted = new Fruit();
        public List<Fruit> TeamList = new List<Fruit>();
        public List<Fruit> allfruits = new List<Fruit>();
        

        public TeamBuilderWindow(List<Fruit> allfruits)
        {
            InitializeComponent();
            this.allfruits = allfruits;
        }


        
        
        private void ChangeBorderColors(Border clickedBorder)
        {
            // KI: Gemini 
            // Prompt: ich will hier die farbe der border ändern wenn sie angeklickt wird aber wie kann ich diese dann wieder wegmachen wenn eine andere border angeklickt wird 
            // Ki: start


            // 1. Alle Border-Elemente im WrapPanel zurücksetzen
            foreach (var child in FruitPanel.Children)
            {
                if (child is Border border)
                {
                    // Standard-Hintergrundfarbe und grauen Standard-Rand wiederherstellen
                    border.Background = (SolidColorBrush)FindResource("LightGreenBg");
                    border.BorderBrush = new SolidColorBrush(Color.FromRgb(200, 230, 201)); // #C8E6C9
                    border.BorderThickness = new Thickness(1);
                }
            }

            // 2. Nur den ausgewählten Rahmen highlighten (z. B. dicker dunkelgrüner Rand)
            if (clickedBorder != null)
            {
                clickedBorder.BorderBrush = (SolidColorBrush)FindResource("PrimaryGreen"); // Das leuchtende Grün
                clickedBorder.BorderThickness = new Thickness(3); // Etwas dicker machen, damit es auffällt
            }

            // KI Ende
        }
        


        




        private void Border_PyronanaUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[0];
            ChangeBorderColors(sender as Border);
        }

        private void Border_AquabeereUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[1];
            ChangeBorderColors(sender as Border);



        }

        private void Border_VoltimetteUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[2];
            ChangeBorderColors(sender as Border);



        }

        private void Border_FlorapfelUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[3];
            ChangeBorderColors(sender as Border);

        }

        private void Border_FrostubeUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[4];
            ChangeBorderColors(sender as Border);

        }

        private void Border_TerrangoUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[5];
            ChangeBorderColors(sender as Border);

        }

        private void Border_WindpfirsichUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[6];
            ChangeBorderColors(sender as Border);

        }

        private void Border_MystikokosUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[7];
            ChangeBorderColors(sender as Border);

        }

        private void Border_ToxibirneUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[8];
            ChangeBorderColors(sender as Border);

        }

        private void Border_KnacknussUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[9];
            ChangeBorderColors(sender as Border);

        }

        private void Border_SchattenfeigeUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[10];
            ChangeBorderColors(sender as Border);

        }

        private void Broder_GlanzkirscheUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSeletcted = allfruits[11];
            ChangeBorderColors(sender as Border);

        }
        private void UpdateTextBlockTeam()
        {
            if (TeamList == null)
            {
                TextBlockTeam.Text = "";
                return;
            }
            string teamtext = string.Empty;
            int count = 0;
            foreach (Fruit f in TeamList)
            {
                if (count == 0)
                    teamtext += f.Name;
                else
                {
                    teamtext += $", {f.Name}";
                }
                count++;
            }
            TextBlockTeam.Text = teamtext;
        }

        private void BtnHinzufuegen_Click(object sender, RoutedEventArgs e)
        {

            if (TeamList == null || TeamList.Count >= 4)
            {
                Logger.Warning($"Adding Fruit cancelled because team is already full.");
                MessageBox.Show("Es dürfen nur 4 Früchte im Team sein");
                return;
            }

            foreach (Fruit f in TeamList)
            {
                if(f.Name == CurrentSeletcted.Name)
                {
                    Logger.Warning($"Adding Fruit cancelled because Fruit is already in Team. Tried to add: {CurrentSeletcted.Name}");
                    MessageBox.Show("Es darf nicht zweimal die gleiche Frucht im Team sein");
                    return;
                }
            }
            TeamList.Add(CurrentSeletcted);

            string names = "";
            foreach (Fruit f in TeamList)
                names += f.Name + " ";
            Logger.Information($"{CurrentSeletcted.Name} added to team. Team is now: {names}");

            UpdateTextBlockTeam();
        }

        private void BtnLoeschen_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSeletcted == null || TeamList == null || TeamList.Count == 0)
            {
                Logger.Debug("Deleting Fruit cancelled beacause invalid state.");
                return;
            }

            Fruit Delme = new Fruit();
            foreach (Fruit f in TeamList)
            {
                if (f.Name == CurrentSeletcted.Name)
                {
                    Delme = f;
                }
            }
            TeamList.Remove(Delme);
            Logger.Information($"{CurrentSeletcted.Name} was removed from team.");
            UpdateTextBlockTeam();
        }

        private void BtnBeenden_Click(object sender, RoutedEventArgs e)
        {
            if (TeamList.Count < 4)
            {
                Logger.Warning("TeamBuilder closed and Team was incomplete");
                MessageBox.Show("Team unvollständig");
                this.DialogResult = false;
                this.Close();
                return;

            }

            string names = "";
            foreach (Fruit f in TeamList)
                names += f.Name + " ";
            Logger.Information($"Building Team successful. Team: {names}");

            this.DialogResult = true;
            this.Close();

            
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            Logger.Debug("Loading Team started.");
            TeamList = Save_load.Load();
            if (TeamList == null)
            {
                Logger.Warning("Load failed so using empty list.");
                TeamList = new List<Fruit>();
            }
            //KI: Gemini
            // kontext: Hatte einen fehler beim speichern und laden da usercontrols nicht in json konvertier bar sind
            // prompt: nun bekomme ich einen fehler wenn ich das team lade und es dann benutzen will da keine usercontrols zugewiesen sind
            // KI Anfang
            else
            {
                string names = "";
                foreach (Fruit f in TeamList)
                    names += f.Name + " ";
                Logger.Information($"Team loaded. Team is: {names}");

                // 2. Die geladenen Früchte reparieren (UserControls wieder zuweisen)
                foreach (Fruit geladeneFrucht in TeamList)
                {
                    // Wir suchen in 'allfruits' nach der Frucht mit demselben Namen
                    Fruit originaleFrucht = allfruits.FirstOrDefault(f => f.Name == geladeneFrucht.Name);

                    if (originaleFrucht != null)
                    {
                        // UI-Element wieder an die geladene Frucht hängen
                        geladeneFrucht.FruitControl = originaleFrucht.FruitControl;

                        // Falls dein MoveSet oder dein Enum-Typ auch gefehlt hat, 
                        // kannst du es hier direkt mitsichern:
                        geladeneFrucht.FruitType = originaleFrucht.FruitType;
                    }
                }
            }
            // KI: Ende

            UpdateTextBlockTeam();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string names = "";
            foreach (Fruit f in TeamList)
                names += f.Name + " ";
            Logger.Information($"Saving team started. Team: {names}");

            Save_load.save(TeamList);
        }
    }
}

using FruitBattlerWPF.Classes;
using FruitBattlerWPF.Pages_window;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FruitBattlerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Fruit> allfruits = new List<Fruit>();
        public FruitTeam UsingTeam;
        public EnemyKI enemy = new EnemyKI();
        private FruitTeam CopyTeam = new FruitTeam();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allfruits = FruitGenerator.CreateAllFruits();
            Logger.Information($"MainWindow loaded and generated {allfruits.Count} Fruits.");
        }


        //KI: Claude
        // Prompt: Warum wird durch meine Taktik mit CopyTeam in MainWindow wenn ich das Fenster schließe und wieder Start klicke meine Früchte nicht geheilt
        // KI: Anfang

        private FruitTeam CloneTeam(FruitTeam original)
        {
            FruitTeam neuesTeam = new FruitTeam();

            foreach (Fruit f in original.Fruits)
            {
                Fruit klon = new Fruit(
                    f.Name,
                    f.FruitType,
                    f.MaxHP,
                    f.Attack,
                    f.Defense,
                    f.Speed,
                    f.MoveSet,
                    (UserControl)Activator.CreateInstance(f.FruitControl.GetType())
                );

                neuesTeam.Fruits.Add(klon);
            }

            return neuesTeam;
        }
        // KI: Ende
        

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            // Abchecken ob Team vorhanden
            if(UsingTeam  == null || UsingTeam.Fruits.Count < 4)
            {
                Logger.Warning("Couldn't start because team was not complete");
                MessageBox.Show("Kein vollständiges Team ausgewählt bitte öffne den TeamBuilder");
                return;
            }


            UsingTeam = CloneTeam(CopyTeam);

            string playerTeamNames = "";
            foreach (Fruit f in UsingTeam.Fruits)
                playerTeamNames += f.Name + " ";
            Logger.Information($"Team cloned and game started. Team is: {playerTeamNames}");

            enemy.CreateRandomTeam(allfruits);

            string enemyTeamNames = "";
            foreach (Fruit f in enemy.EnemyTeam.Fruits)
                enemyTeamNames += f.Name + " ";
            Logger.Information($"Enemy team created. Enemy Team is: {enemyTeamNames}");

            GameWindow GameWindow = new GameWindow(UsingTeam, enemy.EnemyTeam, enemy);
            GameWindow.ShowDialog();
        }



        private void ButtonTeamBuilder_Click(object sender, RoutedEventArgs e)
        {
            Logger.Debug("TeamBuilder opened.");
            TeamBuilderWindow teamBuilderWindow = new TeamBuilderWindow(allfruits);
            bool? result = teamBuilderWindow.ShowDialog();
            if (result == true)
            {
                List<Fruit> teamlist = teamBuilderWindow.TeamList;
                UsingTeam = new FruitTeam(teamlist);
                CopyTeam = UsingTeam;
                // Team aus Team Builder ausgewählt und in Variable Using Team gespeichert

                string names = "";
                foreach (Fruit f in teamlist)
                    names += f.Name + " ";
                Logger.Debug($"Team used from TeamBuilder. Team: {names}");
            }
            else
            {
                Logger.Debug("TeamBuilder closed without team being selected.");
            }
        }



        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("Program Shutdown");
            Application.Current.Shutdown();
        }

       
    }
}
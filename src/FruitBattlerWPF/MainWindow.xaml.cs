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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allfruits = FruitGenerator.CreateAllFruits();
        }



        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            // Abchecken ob Team vorhanden
            if(UsingTeam  == null || UsingTeam.Fruits.Count < 4)
            {
                MessageBox.Show("Kein vollständiges Team ausgewählt bitte öffne den TeamBuilder");
                return;
            }

            enemy.CreateRandomTeam(allfruits);

            GameWindow GameWindow = new GameWindow(UsingTeam, enemy.EnemyTeam, enemy);
            GameWindow.ShowDialog();
        }



        private void ButtonTeamBuilder_Click(object sender, RoutedEventArgs e)
        {
            TeamBuilderWindow teamBuilderWindow = new TeamBuilderWindow(allfruits);
            bool? result = teamBuilderWindow.ShowDialog();
            if (result == true)
            {
                List<Fruit> teamlist = teamBuilderWindow.TeamList;
                UsingTeam = new FruitTeam(teamlist);
                // Team aus Team Builder ausgewählt und in Variable Using Team gespeichert
            }
        }



        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Logger.Information("Program Shutdown");
            Application.Current.Shutdown();
        }

       
    }
}
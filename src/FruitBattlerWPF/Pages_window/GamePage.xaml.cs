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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FruitBattlerWPF.Classes;

namespace FruitBattlerWPF.Pages
{
    public partial class GamePage : Page
    {
        // KI: Claude
        // Prompt: Verdrahte GameVisualizer mit dem Canvas, übergebe PlayerTeam und Enemy im Konstruktor und rufe DrawBattleScene beim Laden auf
        // --- KI Start ---
        private GameVisualizer visualizer;

        public GamePage(FruitTeam playerTeam, EnemyKI enemy)
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                visualizer = new GameVisualizer(GameCanvas, Window.GetWindow(this), playerTeam, enemy);
                visualizer.DrawBattleScene();
            };
        }
        // --- KI Ende ---

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

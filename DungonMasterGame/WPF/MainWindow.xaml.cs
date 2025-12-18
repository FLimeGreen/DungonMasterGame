using DungonMasterGame.WPF;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace DungonMasterGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameBoard World;
        private GamePeaces WorldPeaces;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModell();
        }

        // Manages Tastatur Eingabe
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Movement WASD
            if (e.Key == Key.W) 
            {
                WorldPeaces.PlayerMoveUp();
            }

            if (e.Key == Key.A)
            {
                WorldPeaces.PlayerMoveLeft();
            }

            if (e.Key == Key.S)
            {
                WorldPeaces.PlayerMoveDown();
            }

            if (e.Key == Key.D)
            {
                WorldPeaces.PlayerMoveRight();
            }

            // 1234567890 an Aktionen binden.

            if (e.Key == Key.Space || e.Key == Key.D1) 
                { WorldPeaces.PlayerAction(0); }

            if (e.Key == Key.D2) { WorldPeaces.PlayerAction(1); }

            if (e.Key == Key.D3) { WorldPeaces.PlayerAction(2); }

            if (e.Key == Key.D4) { WorldPeaces.PlayerAction(3); }

            if (e.Key == Key.D5) { WorldPeaces.PlayerAction(4); }

            if (e.Key == Key.D6) { WorldPeaces.PlayerAction(5); }

            if (e.Key == Key.D7) { WorldPeaces.PlayerAction(6); }

            if (e.Key == Key.D8) { WorldPeaces.PlayerAction(7); }

            if (e.Key == Key.D9) { WorldPeaces.PlayerAction(8); }

            if (e.Key == Key.D0) { WorldPeaces.PlayerAction(9); }


            //UpdateGrafik();
            //UpdateActionLeiste();
        }

        private void SkillManager(object sender, RoutedEventArgs e)
        {
            var win = new SkillManagerWindow(WorldPeaces);
            win.Show();
        }
    }
}
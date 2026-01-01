using DungonMasterGame.WPF;
using System.Windows;

namespace DungonMasterGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModell MainWindow_VieModell;
        public MainWindow()
        {
            InitializeComponent();

            // View Modell Speichern um Fester zu generieren.
            MainWindow_VieModell = new MainWindowViewModell();
            DataContext = MainWindow_VieModell;
        }

        private void SkillManager(object sender, RoutedEventArgs e)
        {
            var win = new SkillManagerWindow(MainWindow_VieModell.Peaces);
            win.Show();
        }

        private void SkillTree(object sender, RoutedEventArgs e)
        {
            var win = new SkillTreeWindow(MainWindow_VieModell.Peaces);
            win.Show();
        }
    }
}
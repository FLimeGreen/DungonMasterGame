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
            var win = new SkillTreeWindow();
            win.Show();
        }
    }
}
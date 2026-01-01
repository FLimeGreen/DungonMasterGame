using DungonMasterGame.WPF.ViewModells;
using System.Windows;

namespace DungonMasterGame.WPF
{
    /// <summary>
    /// Interaktionslogik für SkillManagerWindow.xaml
    /// </summary>
    public partial class SkillManagerWindow : Window
    {
        public SkillManagerWindow(GamePeaces peaces)
        {
            InitializeComponent();
            DataContext = new SkillManagerWindowViewModell(peaces);

        }
    }
}

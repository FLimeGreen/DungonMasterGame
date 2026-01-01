using System.Windows;

namespace DungonMasterGame.WPF
{
    /// <summary>
    /// Interaktionslogik für SkillTreeWindow.xaml
    /// </summary>
    public partial class SkillTreeWindow : Window
    {
        public SkillTreeWindow(GamePeaces peaces)
        {
            InitializeComponent();

            DataContext = new SkillTreeWindowViewModell(peaces);
        }
    }
}

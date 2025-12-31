using DungonMasterGame.WPF.ViewModells;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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

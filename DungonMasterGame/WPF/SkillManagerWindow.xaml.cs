using System.Windows;
using System.Windows.Controls;

namespace DungonMasterGame.WPF
{
    /// <summary>
    /// Interaktionslogik für SkillManagerWindow.xaml
    /// </summary>
    public partial class SkillManagerWindow : Window
    {
        GamePeaces worldofpeaces;

        List<Angriff> angriffList = new List<Angriff>();
        List<Spwan> spwanList = new List<Spwan>();
        List<Baue> baueList = new List<Baue>();

        public SkillManagerWindow(GamePeaces peaces)
        {
            InitializeComponent();
            DataContext = this;

            worldofpeaces = peaces;

            // Fill Action Leiste Mit 0-9
            for (int i = 0; i < 10; i++)
            {
                var temp = new TextBlock();
                string zahlen = "1234567890";

                temp.Name = "a" + i;
                temp.FontSize = 20;
                temp.FontWeight = FontWeights.Bold;
                temp.VerticalAlignment = VerticalAlignment.Center;
                temp.HorizontalAlignment = HorizontalAlignment.Center;
                temp.Text = "" + zahlen[i];
                Grid.SetRow(temp, 0);
                Grid.SetColumn(temp, i);

                ActionsLeiste.Children.Add(temp);
            }

            // Angriff
            angriffList.Add(new Spitzhacke(worldofpeaces, worldofpeaces.GetPlayer));

            // Spwan
            spwanList.Add(new Spwan_Skelett(worldofpeaces.GetPlayer, worldofpeaces.GetWorld, worldofpeaces));

            // Baue
            baueList.Add(new Baue_Friedhof(worldofpeaces.GetPlayer, worldofpeaces.GetWorld, worldofpeaces));
        }
    }
}

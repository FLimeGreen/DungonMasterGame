using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace DungonMasterGame.WPF
{
    /// <summary>
    /// Interaktionslogik für SkillManagerWindow.xaml
    /// </summary>
    public partial class SkillManagerWindow : Window
    {
        private GamePeaces worldofpeaces;

        public ObservableCollection<Angriff> angriffList { get; private set; }
        public ObservableCollection<Spwan> spwanList { get; private set; }
        public ObservableCollection<Baue> baueList { get; private set; }

        public SkillManagerWindow(GamePeaces peaces)
        {
            angriffList = new ObservableCollection<Angriff>();
            spwanList = new ObservableCollection<Spwan>();
            baueList = new ObservableCollection<Baue>();

            DataContext = this;
            InitializeComponent();

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
            
            angriffList.CollectionChanged += (d, a) => { MessageBox.Show("Changed" + DataContext); };
            
            // Angriff
            angriffList.Add(new Spitzhacke(worldofpeaces, worldofpeaces.GetPlayer));
            

            // Spwan
            spwanList.Add(new Spwan_Skelett(worldofpeaces.GetPlayer, worldofpeaces.GetWorld, worldofpeaces));

            // Baue
            baueList.Add(new Baue_Friedhof(worldofpeaces.GetPlayer, worldofpeaces.GetWorld, worldofpeaces));

            MessageBox.Show(AngriffSkill.Items.Count.ToString());

            MessageBox.Show(angriffList[0].Name);
            //AngriffSkill.Items.Add(new Spitzhacke(worldofpeaces, worldofpeaces.GetPlayer));
        }
    }
}

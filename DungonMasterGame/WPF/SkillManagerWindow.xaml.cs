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
        private GamePeaces worldofpeaces;

        // Liste aller Möglichen Skills
        public ObservableCollection<Angriff> angriffList { get; private set; }
        public ObservableCollection<Spwan> spwanList { get; private set; }
        public ObservableCollection<Baue> baueList { get; private set; }

        // Grade ausgewählter Skill
        private Aktion selectionaktion; 
        public Aktion SelectedAktion { 
            
            get { return selectionaktion; } 
            
            set
            {
                selectionaktion = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(selectionaktion));
            }

        }

        // INotifyPropertyChanged Event
        public event PropertyChangedEventHandler PropertyChanged;

        // Hilfsmethode zum Auslösen des Events
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SkillManagerWindow(GamePeaces peaces)
        {
            angriffList = new ObservableCollection<Angriff>();
            spwanList = new ObservableCollection<Spwan>();
            baueList = new ObservableCollection<Baue>();
            

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

                // Fügt Boarder hinzu
                var temp_b = new Border();

                temp_b.BorderBrush = Brushes.Black;
                temp_b.BorderThickness = new Thickness(1);
                Grid.SetRow(temp_b, 0);
                Grid.SetColumn(temp_b, i);

                ActionsLeiste.Children.Add(temp_b);
            }

            // Fügt in die Untere Reihe die Buttons ein
            for (int i = 0; i < 10; i++)
            {
                var temp = new Button();

                temp.Name = "SkillButton" + i;
                temp.VerticalAlignment = VerticalAlignment.Center;
                temp.HorizontalAlignment = HorizontalAlignment.Center;
                temp.Margin = new Thickness(5, 3, 5, 3);
                temp.Content = "Leer";
                Grid.SetRow(temp, 1);
                Grid.SetColumn(temp, i);

                ActionsLeiste.Children.Add(temp);

                // Fügt Boarder hinzu
                var temp_b = new Border();

                temp_b.BorderBrush = Brushes.Black;
                temp_b.BorderThickness = new Thickness(1);
                Grid.SetRow(temp_b, 1);
                Grid.SetColumn(temp_b, i);

                ActionsLeiste.Children.Add(temp_b);
            }

            // Angriff
            angriffList.Add(new Spitzhacke(worldofpeaces, worldofpeaces.GetPlayer));
            
            // Spwan
            spwanList.Add(new Spwan_Skelett(worldofpeaces.GetPlayer, worldofpeaces.GetWorld, worldofpeaces));

            // Baue
            baueList.Add(new Baue_Friedhof(worldofpeaces.GetPlayer, worldofpeaces.GetWorld, worldofpeaces));

            // Füge die ausgewähten Skills unten in die Liste ein.

            UpdatePlayerSkillAuswahl();

        }

        public void UpdatePlayerSkillAuswahl()
        {
            var skillwahl = worldofpeaces.GetPlayer.SkillAuswahl;
            int i = 0;
            
            foreach (var aktion in skillwahl)
            {
                Button butt = null;

                foreach (var child in ActionsLeiste.Children)
                {
                    if (child as Button is null)
                    {
                        continue;
                    }
                    butt = child as Button;

                    if (Grid.GetRow(butt) == 1 && Grid.GetColumn(butt) == i)
                    {
                        break;
                    }
                }

                if (butt is null) { throw new Exception("Button nicht gefunden."); }

                if (aktion == null)
                {
                    butt.Content = "Leer";
                }
                else
                {
                    butt.Content = aktion.Name;
                }

                i++;
            }
        }

        private void AngriffSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Box = sender as ListBox;
            var newItem = Box.SelectedItem;

            if (newItem is null) { return; }

            // Neues Item also nicht leer
            SelectedAktion = (Aktion)newItem;

            // Selection bei anderen Löschen
            SpwanSkill.SelectedItem = null;
            BauSkill.SelectedItem = null;

            MessageBox.Show(SelectedAktion.Name);
            
        }

        private void SpwanSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Box = sender as ListBox;
            var newItem = Box.SelectedItem;

            if (newItem is null) { return; }

            // Neues Item also nicht leer
            SelectedAktion = (Aktion)newItem;

            // Selection bei anderen Löschen
            AngriffSkill.SelectedItem = null;
            BauSkill.SelectedItem = null;

            MessageBox.Show(SelectedAktion.Name);
        }

        private void BauSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Box = sender as ListBox;
            var newItem = Box.SelectedItem;

            if (newItem is null) { return; }

            // Neues Item also nicht leer
            SelectedAktion = (Aktion)newItem;

            // Selection bei anderen Löschen
            AngriffSkill.SelectedItem = null;
            SpwanSkill.SelectedItem = null;

            MessageBox.Show(SelectedAktion.Name);
        }
    }
}

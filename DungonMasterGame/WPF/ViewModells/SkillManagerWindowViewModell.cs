using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DungonMasterGame.WPF.ViewModells
{
    public partial class SkillManagerWindowViewModell : ObservableObject
    {
        private GamePeaces worldofpeaces;

        // Liste aller Möglichen Skills
        public ObservableCollection<Angriff> AngriffList { get; private set; }
        public ObservableCollection<Spwan> SpwanList { get; private set; }
        public ObservableCollection<Baue> BaueList { get; private set; }

        // Grade ausgewählter Skill
        public ObservableCollection<Aktion> SelectedAktion { get; private set; }

        // Bindings

        public ObservableCollection<string> ButtonLabels { get; private set; }

        [ObservableProperty]
        public Aktion? angriffSkillSelectedItem = null;

        [ObservableProperty]
        public Aktion? spwanSkillSelectedItem = null;

        [ObservableProperty]
        public Aktion? bauSkillSelectedItem = null;


        public SkillManagerWindowViewModell(GamePeaces peaces)
        {
            AngriffList = peaces.GetSkillTreeManager.angriffList;
            SpwanList = peaces.GetSkillTreeManager.spwanList;
            BaueList = peaces.GetSkillTreeManager.baueList;
            SelectedAktion = new ObservableCollection<Aktion>();

            // Bindings Set
            ButtonLabels = new ObservableCollection<string>();

            worldofpeaces = peaces;

            // Füge die ausgewähten Skills unten in die Liste ein.

            UpdatePlayerSkillAuswahl();

        }

        public void UpdatePlayerSkillAuswahl()
        {
            ButtonLabels.Clear();

            var skillwahl = worldofpeaces.GetPlayer.SkillAuswahl;
            foreach (var aktion in skillwahl)
            {


                if (aktion == null)
                {
                    ButtonLabels.Add("Leer");
                }
                else
                {
                    ButtonLabels.Add(aktion.Name);
                }
            }
        }

        [RelayCommand]
        private void AngriffSkill_SelectionChanged(SelectionChangedEventArgs e)
        {
            var sender = e.Source;
            var Box = sender as ListBox;
            var newItem = Box.SelectedItem;

            if (newItem is null) { return; }

            // Neues Item also nicht leer
            SelectedAktion.Clear();
            SelectedAktion.Add((Aktion)newItem);

            // Selection bei anderen Löschen
            SpwanSkillSelectedItem = null;
            BauSkillSelectedItem = null;

        }

        [RelayCommand]
        private void SpwanSkill_SelectionChanged(SelectionChangedEventArgs e)
        {
            var sender = e.Source;
            var Box = sender as ListBox;
            var newItem = Box.SelectedItem;

            if (newItem is null) { return; }

            // Neues Item also nicht leer
            SelectedAktion.Clear();
            SelectedAktion.Add((Aktion)newItem);

            // Selection bei anderen Löschen
            AngriffSkillSelectedItem = null;
            BauSkillSelectedItem = null;

        }

        [RelayCommand]
        private void BauSkill_SelectionChanged(SelectionChangedEventArgs e)
        {
            var sender = e.Source;
            var Box = sender as ListBox;
            var newItem = Box.SelectedItem;

            if (newItem is null) { return; }

            // Neues Item also nicht leer
            SelectedAktion.Clear();
            SelectedAktion.Add((Aktion)newItem);

            // Selection bei anderen Löschen
            AngriffSkillSelectedItem = null;
            SpwanSkillSelectedItem = null;

        }

        [RelayCommand]
        private void Click_Change_SkillSelection(RoutedEventArgs e)
        {
            var sender = e.Source;
            if (SelectedAktion.Count != 1) { return; }

            Button butt = (Button)sender;
            var name = butt.Name;

            if (name is null) { return; }

            char preZahl = name.Last();
            // Magic Conversion (char dif ist der Abstand zwischen z.B. char 2 und char 0. Welcher 2 ist.
            int slot = preZahl - '0';

            worldofpeaces.GetPlayer.SkillTausch(SelectedAktion[0], slot);
            UpdatePlayerSkillAuswahl();
        }
    }
}

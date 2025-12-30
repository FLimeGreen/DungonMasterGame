using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DungonMasterGame.Fertigkeiten.SkillTree;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

public partial class SkillTreeWindowViewModell : ObservableObject
{
    [ObservableProperty]
    public SkillTreeManager skilltree;

    public TreeElement? SelectedSkill = null;

    // Strings für Beschreibung
    [ObservableProperty]
    public string skillname;

    [ObservableProperty]
    public string skillbeschreibung;

    [ObservableProperty]
    public string skillgekauft;

    // Strings für Kaufen usw.
    [ObservableProperty]
    public string verfuegbareSkillpunkte;

    public SkillTreeWindowViewModell()
    {
        skilltree = new SkillTreeManager();
        verfuegbareSkillpunkte = "Skillpunkte: " + Skilltree.FreieSkillPunkte;
    }

    [RelayCommand]
    private void Tree_SelctedItemChanged(RoutedPropertyChangedEventArgs<Object> e)
    {
        SelectedSkill = (TreeElement?)e.NewValue;

        Skillname = SelectedSkill.Name;
        Skillbeschreibung = SelectedSkill.Beschreibung;
        
        if (SelectedSkill.Gekauft)
        {
            Skillgekauft = "Gekauft";
        }
        else
        {
            Skillgekauft = "Nicht Gekauft";
        }

        VerfuegbareSkillpunkte = "Skillpunkte: " + Skilltree.FreieSkillPunkte;

    }
}

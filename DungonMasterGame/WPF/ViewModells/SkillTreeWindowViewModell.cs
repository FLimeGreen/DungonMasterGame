using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DungonMasterGame.Fertigkeiten.SkillTree;
using System.Windows;

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

    [ObservableProperty]
    public bool skillkaufenmoeglich = false;

    public SkillTreeWindowViewModell(GamePeaces peaces)
    {
        skilltree = peaces.GetSkillTreeManager;
        UpdateSkillkaufenMoeglich();
    }

    private void UpdateSkillkaufenMoeglich()
    {
        VerfuegbareSkillpunkte = "Skillpunkte: " + Skilltree.FreieSkillPunkte;
        Skillkaufenmoeglich = SelectedSkill is not null && Skilltree.FreieSkillPunkte > 0 && !SelectedSkill.Gekauft;
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

        UpdateSkillkaufenMoeglich();

    }



    [RelayCommand]
    //[Required(SelectedSkill is not null)]
    //[Required(Skilltree.FreieSkillPunkte > 0)]
    public void Skillkaufen()
    {
        if (SelectedSkill is null) { return; }
        Skilltree.KaufeSkill(SelectedSkill);
        UpdateSkillkaufenMoeglich();
    }
}

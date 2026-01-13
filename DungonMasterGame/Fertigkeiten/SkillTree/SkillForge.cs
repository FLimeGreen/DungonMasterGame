using System.Collections.ObjectModel;

namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public class SkillForge : TreeElement
    {
        public ObservableCollection<TreeElement> Weiterleiten { get; set; } = new();

        public SkillForge(string name, string beschreibung, int Kosten) : base(name, beschreibung, Kosten)
        {

        }

        public SkillForge(Aktion Aktion, int Kosten) : base(Aktion, Kosten)
        {
        }
    }
}

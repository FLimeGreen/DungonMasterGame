using System.Collections.ObjectModel;

namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public class SkillForge : TreeElement
    {
        public ObservableCollection<TreeElement> Weiterleiten { get; set; } = new();

        public SkillForge(string name, string beschreibung) : base(name, beschreibung)
        {

        }

        public SkillForge(Aktion Aktion) : base(Aktion)
        {
        }
    }
}

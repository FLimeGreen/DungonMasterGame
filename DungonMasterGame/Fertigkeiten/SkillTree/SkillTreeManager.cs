using System.Collections.ObjectModel;

namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public class SkillTreeManager
    {
        public ObservableCollection<TreeElement> Skilltree { get; set; } = new();

        private SkillForge Wurzel;

        private int freieSkillPunkte = 1;
        public int FreieSkillPunkte
        {
            get {  return freieSkillPunkte; }

            set
            {
                if (value > 0)
                {
                    freieSkillPunkte = freieSkillPunkte + value;
                }
            }
        }

        public SkillTreeManager()
        {
            Skilltree = new ObservableCollection<TreeElement>();

            Wurzel = new SkillForge("", "");
            Wurzel.Gekauft = true;

            Skilltree.Add(Wurzel);
            Wurzel.Weiterleiten.Add(new SkillBlatt("Skill1", "Wow"));
            Wurzel.Weiterleiten.Add(new SkillBlatt("Skill2", "Toll"));
            Wurzel.Weiterleiten.Add(new SkillForge("Skill3", "Wieunerwartet"));
        }
    }
}

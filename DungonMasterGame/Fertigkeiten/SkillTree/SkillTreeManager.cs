using DungonMasterGame.Fertigkeiten.SkillTree.Skills;
using DungonMasterGame.Fertigkeiten.SkillTree.SkillTree_Elemente;
using System.Collections.ObjectModel;

namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public class SkillTreeManager
    {
        public ObservableCollection<TreeElement> Skilltree { get; set; } = new();

        // gelernte Skills
        public ObservableCollection<Angriff> angriffList { get; private set; }
        public ObservableCollection<Spwan> spwanList { get; private set; }
        public ObservableCollection<Baue> baueList { get; private set; }


        private GamePeaces Peaces;
        public GamePeaces Figuren { get { return Peaces; } }

        private SkillForge Wurzel;
        public Origen Origen 
        { 
            get {
                var tem = Wurzel as Origen;
                if (tem is null) throw new Exception("Invalid Skilltree");
                return tem; 
            } 
        }

        private int freieSkillPunkte = 1;
        public int FreieSkillPunkte
        {
            get { return freieSkillPunkte; }

            set
            {
                if (value > 0)
                {
                    freieSkillPunkte = freieSkillPunkte + value;
                }
            }
        }

        public SkillTreeManager(GamePeaces peaces)
        {
            this.Peaces = peaces;

            angriffList = new ObservableCollection<Angriff>();
            spwanList = new ObservableCollection<Spwan>();
            baueList = new ObservableCollection<Baue>();

            Skilltree = new ObservableCollection<TreeElement>();

            // Erhalte ersten Skill
            Wurzel = new Skill_Spitzhacke();
            Wurzel.Kaufen(this);
            

            // Vertige Baum an
            Skilltree.Add(Wurzel);
            
        }

        public bool KaufeSkill(TreeElement Skill)
        {
            if (FreieSkillPunkte < Skill.Kosten) { return false; }

            if (Skill.Kaufen(this))
            {
                freieSkillPunkte = freieSkillPunkte - Skill.Kosten;
                return true;
            }
            else
                return false;
        }
    }
}

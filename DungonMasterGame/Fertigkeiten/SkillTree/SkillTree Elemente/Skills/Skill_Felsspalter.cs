using DungonMasterGame.Fertigkeiten.Aktionen.Angriffe;
using DungonMasterGame.Fertigkeiten.SkillTree.SkillTree_Elemente.Stats;

namespace DungonMasterGame.Fertigkeiten.SkillTree.SkillTree_Elemente.Skills
{
    public class Skill_Felsspalter : SkillForge
    {
        public Skill_Felsspalter() : base(new Felsspalter(null, null), 2)
        {

        }

        public override bool Kaufen(SkillTreeManager Tree)
        {
            var Peaces = Tree.Figuren;

            // Kauf Prozess
            this.gekauft = true;
            var Spalter = new Felsspalter(Peaces, Peaces.GetPlayer);
            Tree.angriffList.Add(Spalter);

            // Weiterleiten
            this.Weiterleiten.Add(new Stats_Felsspalter_MehrSchaden(Spalter, this));

            return true;
        }
    }
}

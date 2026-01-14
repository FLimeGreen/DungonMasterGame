using DungonMasterGame.Fertigkeiten.SkillTree.SkillTree_Elemente;
using DungonMasterGame.Fertigkeiten.SkillTree.Stats;

namespace DungonMasterGame.Fertigkeiten.SkillTree.Skills
{
    public class Skill_Spitzhacke : Origen
    {
        public Skill_Spitzhacke() : base(new Spitzhacke(null, null), 0)
        {

        }

        public override bool Kaufen(SkillTreeManager Tree)
        {
            var Peaces = Tree.Figuren;

            // Kauf Prozess
            this.gekauft = true;
            Tree.angriffList.Add(new Spitzhacke(Peaces, Peaces.GetPlayer));

            // Neue Skills hinzufügen
            this.Weiterleiten.Add(new Skill_BaueFriedhof());
            this.Weiterleiten.Add(new Stats_MehrLP());
            //Wurzel.Weiterleiten.Add(new SkillForge("Skill3", "Wieunerwartet"));

            return true;
        }

    }
}

namespace DungonMasterGame.Fertigkeiten.SkillTree.Skills
{
    public class Skill_BaueFriedhof : SkillForge
    {
        public Skill_BaueFriedhof() : base(new Baue_Friedhof(null, null, null), 1)
        {

        }

        public override bool Kaufen(SkillTreeManager Tree)
        {
            var Peaces = Tree.Figuren;

            // Kauf Prozess
            this.gekauft = true;

            // Füge Skill hinzu
            Tree.baueList.Add(new Baue_Friedhof(Peaces.GetPlayer, Peaces.GetWorld, Peaces));

            // Erweitere Baum
            this.Weiterleiten.Add(new Skill_SpawneSkelett());

            return true;
        }
    }
}

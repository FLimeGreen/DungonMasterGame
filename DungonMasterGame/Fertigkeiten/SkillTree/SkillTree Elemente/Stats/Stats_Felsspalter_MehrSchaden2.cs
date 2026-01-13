using DungonMasterGame.Fertigkeiten.Aktionen.Angriffe;
using DungonMasterGame.Fertigkeiten.SkillTree.SkillTree_Elemente.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMasterGame.Fertigkeiten.SkillTree.SkillTree_Elemente.Stats
{
    public class Stats_Felsspalter_MehrSchaden2 : SkillBlatt
    {
        Skill_Felsspalter Parent;
        Felsspalter Spalter;

        public Stats_Felsspalter_MehrSchaden2(Felsspalter Spalter, Skill_Felsspalter Parent) : base("Felsspalter Schadensupgrade", "Der Felsspalter macht nun 10 statt 8 Schaden", 1)
        {
            this.Spalter = Spalter;
            this.Parent = Parent;
        }

        public override bool Kaufen(SkillTreeManager Tree)
        {
            // Kauf Prozess
            this.gekauft = true;

            Spalter.SchadensUpgrade2 = true;

            return true;
        }
    }
}

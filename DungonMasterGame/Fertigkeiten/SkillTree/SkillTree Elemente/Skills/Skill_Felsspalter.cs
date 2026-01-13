using DungonMasterGame.Fertigkeiten.Aktionen.Angriffe;
using DungonMasterGame.Fertigkeiten.SkillTree.Skills;
using DungonMasterGame.Fertigkeiten.SkillTree.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Tree.angriffList.Add(new Felsspalter(Peaces, Peaces.GetPlayer));

            // Weiterleiten

            return true;
        }
    }
}

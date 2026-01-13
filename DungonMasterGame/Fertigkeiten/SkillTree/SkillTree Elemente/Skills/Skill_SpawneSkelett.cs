using DungonMasterGame.Figuren;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMasterGame.Fertigkeiten.SkillTree.Skills
{
    public class Skill_SpawneSkelett : SkillForge
    {
        public Skill_SpawneSkelett() : base(new Spwan_Skelett(null as Controller, null, null), 1)
        {

        }

        public override bool Kaufen(SkillTreeManager Tree)
        {
            var Peaces = Tree.Figuren;

            // Kauf Prozess
            this.gekauft = true;

            // Füge Skill hinzu
            Tree.spwanList.Add(new Spwan_Skelett(Peaces.GetPlayer, Peaces.GetWorld, Peaces));

            return true;
        }
    }
}

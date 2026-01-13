using DungonMasterGame.Fertigkeiten.SkillTree.SkillTree_Elemente.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMasterGame.Fertigkeiten.SkillTree.SkillTree_Elemente
{
    public class Origen : SkillForge
    {
        public Origen(Aktion Aktion, int Kosten) : base(Aktion, Kosten)
        {
        }

        public void FügeFelsspalter_hinzu()
        {
            this.Weiterleiten.Add(new Skill_Felsspalter());
        }
    }
}

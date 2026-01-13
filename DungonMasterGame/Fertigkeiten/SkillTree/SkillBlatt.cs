namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public class SkillBlatt : TreeElement
    {
        public SkillBlatt(Aktion Aktion, int Kosten) : base(Aktion, Kosten)
        {
        }

        public SkillBlatt(string name, string beschreibung, int Kosten) : base(name, beschreibung, Kosten)
        {

        }


    }
}

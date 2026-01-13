namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public abstract class TreeElement
    {
        protected string name;
        protected string beschreibung;
        protected int kosten;
        protected bool gekauft;
        protected SkillID skillid;

        public string Name { get { return name; } }
        public string Beschreibung { get { return beschreibung; } }

        public int Kosten { get { return kosten; } }

        public bool Gekauft
        {
            get { return gekauft; }
        }

        public SkillID SkillId { get { return skillid; } }

        public TreeElement(string name, string beschreibung, int Kosten)
        {
            this.name = name;
            this.beschreibung = beschreibung;
            kosten = Kosten;
            gekauft = false;
            skillid = SkillID.Stattaenderung;
        }

        public TreeElement(Aktion Aktion, int Kosten)
        {
            this.name = Aktion.Name;
            this.beschreibung = Aktion.Beschreibung;
            kosten = Kosten;
            gekauft = false;
            skillid = SkillID.Aktion;
        }

        public virtual bool Kaufen(SkillTreeManager Tree)
        {
            throw new NotImplementedException("Skill hat keine Implementation.");
        }
    }
}

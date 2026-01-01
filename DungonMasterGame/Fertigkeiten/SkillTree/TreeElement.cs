namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public abstract class TreeElement
    {
        string name;
        string beschreibung;
        bool gekauft;
        private SkillID skillid;

        public string Name { get { return name; } }
        public string Beschreibung { get { return beschreibung; } }
        public bool Gekauft
        {
            get { return gekauft; }
            set { gekauft = true; }
        }

        public SkillID SkillId { get { return skillid; } }

        public TreeElement(string name, string beschreibung)
        {
            this.name = name;
            this.beschreibung = beschreibung;
            gekauft = false;
            skillid = SkillID.Stattaenderung;
        }

        public TreeElement(Aktion Aktion)
        {
            this.name = Aktion.Name;
            this.beschreibung = Aktion.Beschreibung;
            skillid = SkillID.Aktion;
        }
    }
}

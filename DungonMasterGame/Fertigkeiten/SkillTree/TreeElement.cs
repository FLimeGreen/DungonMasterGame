namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public abstract class TreeElement
    {
        string name;
        string beschreibung;
        bool gekauft;

        public string Name { get { return name; } }
        public string Beschreibung { get {  return beschreibung; } }
        public bool Gekauft { 
            get { return gekauft; }
            set { gekauft = true; }
        }

        public TreeElement(string name, string beschreibung)
        {
            this.name = name;
            this.beschreibung = beschreibung;
            gekauft = false;
        }
    }
}

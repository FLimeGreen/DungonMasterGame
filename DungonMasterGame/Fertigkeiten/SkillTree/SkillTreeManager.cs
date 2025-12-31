using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace DungonMasterGame.Fertigkeiten.SkillTree
{
    public class SkillTreeManager
    {
        public ObservableCollection<TreeElement> Skilltree { get; set; } = new();

        // gelernte Skills
        public ObservableCollection<Angriff> angriffList { get; private set; }
        public ObservableCollection<Spwan> spwanList { get; private set; }
        public ObservableCollection<Baue> baueList { get; private set; }


        private GamePeaces Peaces;

        private SkillForge Wurzel;

        private int freieSkillPunkte = 1;
        public int FreieSkillPunkte
        {
            get {  return freieSkillPunkte; }

            set
            {
                if (value > 0)
                {
                    freieSkillPunkte = freieSkillPunkte + value;
                }
            }
        }

        public SkillTreeManager(GamePeaces peaces)
        {
            this.Peaces = peaces;

            angriffList = new ObservableCollection<Angriff>();
            spwanList = new ObservableCollection<Spwan>();
            baueList = new ObservableCollection<Baue>();

            Skilltree = new ObservableCollection<TreeElement>();

            // Erhalte ersten Skill
            Wurzel = new SkillForge(new Spitzhacke(null, null));
            // Angriff
            angriffList.Add(new Spitzhacke(Peaces, Peaces.GetPlayer));
            Wurzel.Gekauft = true;


            // Vertige Baum an
            Skilltree.Add(Wurzel);
            Wurzel.Weiterleiten.Add(new SkillForge(new Baue_Friedhof(null, null, null)));
            Wurzel.Weiterleiten.Add(new SkillBlatt("Mehr LP", "Du erhälst 5 Weitere Lebenspunkte"));
            //Wurzel.Weiterleiten.Add(new SkillForge("Skill3", "Wieunerwartet"));
        }

        public bool KaufeSkill(TreeElement Skill)
        {
            if (FreieSkillPunkte <= 0) { return false; }

            if (Skill.SkillId == SkillID.Aktion)
            {
                return KaufeAktion(Skill);
            }

            if (Skill.SkillId == SkillID.Stattaenderung)
            {
                return KaufeStatt(Skill);
            }

            return false;
        }

        private bool KaufeAktion(TreeElement Skill)
        {
            //aktions_Manager.AktionHinzufügen(new Spwan_Skelett(this, World, WorldFiguren), new TimeSpan(0, 0, 0, 2, 0), 1);
            //aktions_Manager.AktionHinzufügen(new Baue_Friedhof(this, World, WorldFiguren), new TimeSpan(0, 0, 0, 0, 500), 9);
            
            switch (Skill.Name)
            {
                case "Baue Friedhof":
                    // Füge Skill hinzu
                    baueList.Add(new Baue_Friedhof(Peaces.GetPlayer, Peaces.GetWorld, Peaces));

                    // Erweitere Baum
                    var Forge = Skill as SkillForge;
                    if (Forge is null) { throw new Exception("Skilltree Fehler"); }

                    Forge.Weiterleiten.Add(new SkillBlatt(new Spwan_Skelett(Peaces.GetPlayer, null, null)));
                    break;

                case "Spwane Skelett":
                    // Füge Skill hinzu
                    spwanList.Add(new Spwan_Skelett(Peaces.GetPlayer, Peaces.GetWorld, Peaces));

                    break;

                default:
                    return false;
            }

            //Gekauft
            freieSkillPunkte--;
            Skill.Gekauft = true;
            return true;
        }

        private bool KaufeStatt(TreeElement Skill)
        {
            switch (Skill.Name)
            {
                case "Mehr LP":
                    // Erhöt LP um 5
                    Peaces.GetPlayer.LP = 5;
                    break;

                default:
                    return false;
            }

            //Gekauft
            freieSkillPunkte--;
            Skill.Gekauft = true;
            return true;
        }
    }
}

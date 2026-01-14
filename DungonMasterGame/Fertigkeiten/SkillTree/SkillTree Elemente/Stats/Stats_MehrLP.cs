namespace DungonMasterGame.Fertigkeiten.SkillTree.Stats
{
    public class Stats_MehrLP : SkillBlatt
    {
        private bool ErsterKauf = true;

        public Stats_MehrLP() : base("Mehr LP", "Du erhälst 5 Weitere Lebenspunkte. Du kannst diesen Skill mehrmals erwerben.", 1)
        {

        }

        public override bool Kaufen(SkillTreeManager Tree)
        {
            var Peaces = Tree.Figuren;

            // Kauf Prozess
            //this.gekauft = true;

            // Erhöt LP um 5
            Peaces.GetPlayer.LP = 5;

            // Weiterleiten
            if (ErsterKauf)
            {
                Tree.Origen.FügeFelsspalter_hinzu();
                ErsterKauf = false;
            }

            return true;
        }
    }
}

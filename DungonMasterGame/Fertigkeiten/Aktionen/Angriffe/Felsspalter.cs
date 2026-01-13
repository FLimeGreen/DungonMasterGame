using DungonMasterGame.Figuren;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMasterGame.Fertigkeiten.Aktionen.Angriffe
{
    public class Felsspalter : Angriff
    {
        public Felsspalter(GamePeaces WorldFiguren, Controller Controller) : base(Controller, WorldFiguren, new TimeSpan(0, 0, 0, 3, 5))
        {
            name = "Felsspalter";
            beschreibung = "Ein Angriff mit einer mächtigen Axt. Greift zwei Felder hintereinander an.";
        }

        protected override bool DoAktionAsFigur()
        {
            // Check Figur ungleich null (Sicherheit).
            if (figur_controller == null)
            {
                return false;
            }

            int Schaden = 6;
            var Art = Schadensarten.physisch;

            // Angriff 1
            (int, int) Look = figur_controller.GetLooking(1);

            bool Erfolgreich1 = WorldPeaces.GreifeFeldAn(Look.Item1, Look.Item2, Schaden, Art);

            // Angriff 2
            Look = figur_controller.GetLooking(2);

            bool Erfolgreich2 =  WorldPeaces.GreifeFeldAn(Look.Item1, Look.Item2, Schaden, Art);

            return Erfolgreich1 || Erfolgreich2;
        }
    }
}

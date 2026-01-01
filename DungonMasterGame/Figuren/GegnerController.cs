using DungonMasterGame;
using DungonMasterGame.Figuren;

public abstract class GegnerController : Controller
{
    protected GegnerController(int x, int y, GamePeaces WorldFiguren) : base(x, y)
    {
        Woduschonmalwarst = new List<(int, int)>();
    }

    protected List<(int, int)> Woduschonmalwarst;

    protected double? KuerzesteDistanzNorden = null;
    protected double? KuerzesteDistanzOsten = null;
    protected double? KuerzesteDistanzSueden = null;
    protected double? KuerzesteDistanzWesten = null;

    protected double Luftline(int x, int y, int Ziel_x, int Ziel_y)
    {
        int d_x = x - Ziel_x;
        int d_y = y - Ziel_y;

        // Betrag Vektor (a^2 + b^2)Wurzel
        return Math.Sqrt(Math.Pow(d_x, 2) + Math.Pow(d_y, 2));
    }

    protected bool UpdateRichtung(Heading Richtung, int Radius, GameBoard World)
    {
        int t_x = this.x;
        int t_y = this.y;

        for (int i = 0; i < Radius; i++)
        {
            switch (Richtung)
            {
                case Heading.Norden:
                    // Norden
                    t_y++;
                    break;

                case Heading.Osten:
                    // Osten
                    t_x++;
                    break;

                case Heading.Süden:
                    // Süeden
                    t_y--;
                    break;

                case Heading.Westen:
                    // Westen
                    t_x--;
                    break;

                default: return false;
            }


            // Check ob Wand dann fertig
            if (World.GetHitbox(t_x, t_y) is not Hitbox.FreeSpace)
            {
                return true;
            }

            if (Woduschonmalwarst.Contains((t_x, t_y)))
            {
                // Warst schon.
                continue;
            }

            double distance = Luftline(t_x, t_y, 0, 0);
            switch (Richtung)
            {
                case Heading.Norden:
                    // Norden
                    // Erste Distanze
                    if (KuerzesteDistanzNorden is null)
                    {
                        KuerzesteDistanzNorden = distance;
                        continue;
                    }

                    if (distance < KuerzesteDistanzNorden)
                    {
                        KuerzesteDistanzNorden = distance;
                    }
                    break;

                case Heading.Osten:
                    // Osten
                    // Erste Distanze
                    if (KuerzesteDistanzOsten is null)
                    {
                        KuerzesteDistanzOsten = distance;
                        continue;
                    }

                    if (distance < KuerzesteDistanzOsten)
                    {
                        KuerzesteDistanzOsten = distance;
                    }
                    break;

                case Heading.Süden:
                    // Süeden
                    // Erste Distanze
                    if (KuerzesteDistanzSueden is null)
                    {
                        KuerzesteDistanzSueden = distance;
                        continue;
                    }

                    if (distance < KuerzesteDistanzSueden)
                    {
                        KuerzesteDistanzSueden = distance;
                    }
                    break;

                case Heading.Westen:
                    // Westen
                    // Erste Distanze
                    if (KuerzesteDistanzWesten is null)
                    {
                        KuerzesteDistanzWesten = distance;
                        continue;
                    }

                    if (distance < KuerzesteDistanzWesten)
                    {
                        KuerzesteDistanzWesten = distance;
                    }
                    break;

                default: return false;
            }
        }
        return true;
    }

    protected (bool, Heading?) MoveToZiel(int Radius, GameBoard World)
    {
        // Reset Speicher
        KuerzesteDistanzNorden = null;
        KuerzesteDistanzOsten = null;
        KuerzesteDistanzSueden = null;
        KuerzesteDistanzWesten = null;

        // Aktuelle Position zur Liste hinzufügen
        if (!Woduschonmalwarst.Contains((this.x, this.y)))
        {
            Woduschonmalwarst.Add((this.x, this.y));
        }

        // Update jede Richtung
        UpdateRichtung(Heading.Norden, Radius, World);
        UpdateRichtung(Heading.Osten, Radius, World);
        UpdateRichtung(Heading.Süden, Radius, World);
        UpdateRichtung(Heading.Westen, Radius, World);

        // Schauen nach kleinster Distanz

        var Werte = new Dictionary<Heading, double>();

        if (KuerzesteDistanzNorden is not null)
        {
            Werte.Add(Heading.Norden, KuerzesteDistanzNorden.Value);
        }

        if (KuerzesteDistanzOsten is not null)
        {
            Werte.Add(Heading.Osten, KuerzesteDistanzOsten.Value);
        }

        if (KuerzesteDistanzSueden is not null)
        {
            Werte.Add(Heading.Süden, KuerzesteDistanzSueden.Value);
        }

        if (KuerzesteDistanzWesten is not null)
        {
            Werte.Add(Heading.Westen, KuerzesteDistanzWesten.Value);
        }

        if (Werte.Count() == 0)
        {
            return (false, null);
        }
        else
        {
            // Sucht kleinste Zahl aus dem Dic raus.
            var min = Werte.MinBy(x => x.Value);

            return (true, min.Key);
        }

    }
}

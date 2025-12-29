public class Baue_GegnerTor : Baue
{
    private List<(int, int)> Baupunkte = new List<(int, int)> { (0,0), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1) };

    public Baue_GegnerTor(Controller Controller, GameBoard World, GamePeaces WorldofPeaces) : base(Controller, World, WorldofPeaces, new TimeSpan(0, 0, 0, 0, 0))
    {
        
    }

    public Baue_GegnerTor(Tile Controller) : base(Controller, new TimeSpan(0, 0, 0, 0, 0))
    {
    }

    public bool DoAktionAsGeneration()
    {
        // Spwan 0,0
        int bx = 0;
        int by = 25;

        
        if (!IstBauBerreichFrei(Baupunkte, bx, by))
        {
            return false;
        }

        GegnerTor_Kern Kern = null;
        List<GegnerTor_Hull> Hulle = new List<GegnerTor_Hull>();

        // Erstelle Alle Teile und Baue sie
        foreach (var b in Baupunkte)
        {
            if (b == (0, 0))
            {
                Kern = new GegnerTor_Kern(b.Item1 + bx, b.Item2 + by, world, worldofpeaces);
                BaueInWorld(b.Item1 + bx, b.Item2 + by, Kern);
            }
            else
            {
                var temp = new GegnerTor_Hull(b.Item1 + bx, b.Item2 + by);

                Hulle.Add(temp);
                BaueInWorld(b.Item1 + bx, b.Item2 + by, temp);
            }
        }

        // Nun die Teile Zusammensetzen

        Kern.HuelleErstzen = Hulle;

        foreach (var h in Hulle)
        {
            h.KernVerweis = Kern;
        }

        world.GegnerTor = Kern;
        return true;
    }
}


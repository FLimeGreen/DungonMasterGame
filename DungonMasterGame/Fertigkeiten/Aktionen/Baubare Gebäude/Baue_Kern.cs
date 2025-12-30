public class Baue_Kern : Baue
{
    private List<(int, int)> Baupunkte = new List<(int, int)> { (0,0), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1) };

    public Baue_Kern(Controller Controller, GameBoard World, GamePeaces WorldofPeaces) : base(Controller, World, WorldofPeaces, new TimeSpan(0, 0, 0, 0, 0))
    {
        
    }

    public Baue_Kern(Tile Controller) : base(Controller, new TimeSpan(0, 0, 0, 0, 0))
    {
    }

    public bool DoAktionAsGeneration()
    {
        // Spwan 0,0
        int bx = 0;
        int by = 0;

        
        if (!IstBauBerreichFrei(Baupunkte, bx, by))
        {
            return false;
        }

        Kern_Kern Kern = null;
        List<Kern_Hull> Hulle = new List<Kern_Hull>();

        // Erstelle Alle Teile und Baue sie
        foreach (var b in Baupunkte)
        {
            if (b == (0,0))
            {
                Kern = new Kern_Kern(b.Item1 + bx, b.Item2 + by, world);
                BaueInWorld(b.Item1 + bx, b.Item2 + by, Kern);
            }
            else
            {
                var temp = new Kern_Hull(b.Item1 + bx, b.Item2 + by);

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

        return true;
    }
}


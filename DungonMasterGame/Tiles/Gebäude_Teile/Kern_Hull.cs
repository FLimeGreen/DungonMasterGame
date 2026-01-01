using DungonMasterGame;

public class Kern_Hull : Gebäude
{
    private Kern_Kern kernVerweis;
    public Kern_Hull(int x, int y) : base(x, y)
    {
        hitbox = Hitbox.Kern;
        grafik[0] = new GrafikContainer(x, y, 'K', "");
    }

    public Kern_Kern KernVerweis
    {
        get { return kernVerweis; }

        set
        {
            if (value is null) { throw new Exception("Kern Kern Verweis darf nicht null sein."); }

            kernVerweis = value;

            // Get relative pos zum Kern
            int k_x = kernVerweis.X;
            int k_y = kernVerweis.Y;

            int dif_x = k_x - this.x;
            int dif_y = k_y - this.y;

            // Wenn x größer null
            if (dif_x > 0)
            {
                // Unten rechts
                if (dif_y > 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Kern/Kern6.png"); }

                if (dif_y == 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Kern/Kern3.png"); }

                // Oben rechts
                if (dif_y < 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Kern/Kern0.png"); }
            }
            else if (dif_x == 0)
            {
                // Unten Mitte
                if (dif_y > 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Kern/Kern7.png"); }

                if (dif_y == 0) { throw new Exception("Hull und Kern identisch."); }

                // Oben Mitte
                if (dif_y < 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Kern/Kern1.png"); }
            }
            else if (dif_x < 0)
            {
                // Unten links
                if (dif_y > 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Kern/Kern8.png"); }

                if (dif_y == 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Kern/Kern5.png"); }

                // Oben links
                if (dif_y < 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Kern/Kern2.png"); }
            }
        }
    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        return kernVerweis.ErhalteSchaden(Schaden, Art, World);
    }

    public bool Destroy(Kern_Kern verify, GameBoard World)
    {
        if (verify != kernVerweis) { return false; }

        // Melde Ab
        World.GebaudeAbmelden(this);

        // Ersetze durch FreeSpace
        var newSpace = new FreeSpace(this.x, this.y);
        World.ErsetzeFeld(this, this.x, this.y, newSpace);

        return true;
    }
}

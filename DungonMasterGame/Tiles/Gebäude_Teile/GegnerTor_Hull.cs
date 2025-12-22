using System.Windows.Documents;

public class GegnerTor_Hull : Gebäude
{
    private GegnerTor_Kern kernVerweis;
    public GegnerTor_Hull(int x, int y) : base(x, y)
    {
        hitbox = Hitbox.GegnerTor;
        grafik[0] = new GrafikContainer(x, y, 'G', "");
    }

    public GegnerTor_Kern KernVerweis
    {
        set 
        {
            if (value is null) { throw new Exception("GegnerTor Kern Verweis darf nicht null sein."); }

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
                if (dif_y > 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor6.png"); }

                if (dif_y == 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor3.png"); }

                // Oben rechts
                if (dif_y < 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor0.png"); }
            }
            else if (dif_x == 0)
            {
                // Unten Mitte
                if (dif_y > 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor7.png"); }

                if (dif_y == 0) { throw new Exception("Hull und Kern identisch."); }

                // Oben Mitte
                if (dif_y < 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor1.png"); }
            }
            else if (dif_x < 0)
            {
                // Unten links
                if (dif_y > 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor8.png"); }

                if (dif_y == 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor5.png"); }

                // Oben links
                if (dif_y < 0) { grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor2.png"); }
            }
        }
    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        return kernVerweis.ErhalteSchaden(Schaden, Art, World);
    }

    public bool Destroy(GegnerTor_Kern verify, GameBoard World)
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

using DungonMasterGame;

public class GegnerTor_Kern : Gebäude
{
    private List<GegnerTor_Hull> gebauedeTeile;
    private GameBoard world;
    private GamePeaces worldPeaces;

    private int MengeAnSpwan = 0;

    public int MengeSpwanSetzen
    {
        set
        {
            if (value > 0)
            {
                MengeAnSpwan = MengeAnSpwan + value;
            }
        }
    }

    public GegnerTor_Kern(int x, int y, GameBoard world, GamePeaces worldPeaces) : base(x, y)
    {
        // Stats Hinzufügen und Verhalten. Sowie auch von Kern Hülle.
        hitbox = Hitbox.GegnerTor;
        grafik[0] = new GrafikContainer(x, y, 'G', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/MehrFelder/Tor/Tor4.png");

        // Beschreibung für Selcet
        Name = "Gegner Tor";
        Beschreibung = "Durch diese Tor kommen die Gegner.";

        this.world = world;
        this.worldPeaces = worldPeaces;
    }

    public List<GegnerTor_Hull> HuelleErstzen
    {
        set
        {
            gebauedeTeile = value;

            // Spwan auf Hüllen Teile ausführen.
            int i = 0;
            foreach (var hull in gebauedeTeile)
            {
                aktions_Manager.AktionHinzufügen(new Spwan_Novizen_Abenteurer(hull, world, worldPeaces), new TimeSpan(0, 0, 0, 4, 0), i);
                i++;
            }
        }
    }

    public override void Update(GameBoard World, GamePeaces WorldOfPeaces)
    {
        if (MengeAnSpwan > 0)
        {
            if (SpwaneEinenGegner())
            {
                MengeAnSpwan--;
            }
        }

    }

    private bool SpwaneEinenGegner()
    {
        //var CooldownCheck = aktions_Manager.ActiveCoolDowns;
        //bool check = true;

        //// Schau ob ein Cooldown aktiv ist?
        //foreach (var check_part in CooldownCheck)
        //{
        //    check = check && check_part;
        //}

        //// False Cooldown Aktiv
        //if (check == true)
        //{
        //    //Kein Cooldown

        // Gegner Sollen möglichst auf einmal Spwanen.
        // Sonst ist das keine Welle
        for (int i = 0; i < 10; i++)
        {
            bool te = aktions_Manager.DoAction(i);

            // Wenn einmal erfolgreich ausgeführt höre auf.
            if (te)
            {
                return true;
            }
        }
        
        //}
        return false;
    }

}

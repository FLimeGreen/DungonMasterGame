using DungonMasterGame;
using DungonMasterGame.Figuren.Pathfinding.Helfer;

public class Friedhof : Gebäude
{
    private List<Skelett> skelette = new List<Skelett>();

    public (int, int)? Wachpunkt;

    public void Skelett_Anmelden(Skelett neuSkelett)
    {
        if (skelette.Count < 4)
        {
            skelette.Add(neuSkelett);
        }
    }

    public void Skelett_Abnmelden(Skelett neuSkelett)
    {
        if (skelette.Contains(neuSkelett))
        {
            skelette.Remove(neuSkelett);
        }
    }


    public Friedhof(int x, int y, GameBoard world, GamePeaces worldPeaces) : base(x, y)
    {
        hitbox = Hitbox.Friedhof;
        structurpunkte = 20;
        grafik[0] = new GrafikContainer(x, y, 'F', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/EinzelFelder/Friedhof.png");

        // Beschreibung für Selcet
        Name = "Friedhof";
        Beschreibung = "Erschaft 4 Untote";

        aktions_Manager.AktionHinzufügen(new Spwan_Skelett(this, world, worldPeaces), new TimeSpan(0, 0, 0, 2, 0), 0);

    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        // Negativer Schaden Erxistiert nicht.
        if (Schaden <= 0)
        {
            return false;
        }

        structurpunkte = structurpunkte - Schaden;

        if (structurpunkte <= 0)
        {
            // Melde Ab
            World.GebaudeAbmelden(this);

            // Ersetze durch FreeSpace
            var newSpace = new FreeSpace(x, y);
            return World.ErsetzeFeld(this, x, y, newSpace);
        }

        return true;
    }

    public override void Update(GameBoard World, GamePeaces WorldOfPeaces)
    {
        // Beschreibung Aktuallisieren
        WeiterEigenschaften = new List<string>() { "Menge an gespanten Skeletten: " + skelette.Count, "Wachpunkt: " + Wachpunkt};


        if (skelette.Count < 4)
        {
            // Gib an Ob Cooldown abegelaufen ist?
            if (aktions_Manager.DoAction(0))
            {
                // Nur erhöhen wenn auch gesspwaned.
                // Entsteht ein Bug wenn nur hochzählen.
                //SpwanMenge++;
            }
        }
    }

    public override void M_Key_Trigger(GamePeaces Peaces)
    {
        Wachpunkt = (Peaces.GetPlayer_X, Peaces.GetPlayer_Y);
    }

}
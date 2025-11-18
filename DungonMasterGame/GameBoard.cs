using System.Windows.Documents;

public class GameBoard
{
    private Dictionary<(int, int), Tile> WorldMap;

    private List<Gebäude> UpdateListe;

    public GameBoard()
    {
        WorldMap = new Dictionary<(int, int), Tile>();
        UpdateListe = new List<Gebäude>();

        // Mache 3x3 Kasten

        for (int x = -4; x <= 4; x++)
        {
            for (int y = -4; y <= 4; y++)
            {
                if (x == -4 || x == 4 || y == -4 || y == 4)
                {
                    if ((-2 < x && x < 2) && y == 4)
                    {
                        WorldMap.Add((x, y), new FreeSpace(x, y));
                    }
                    else
                        WorldMap.Add((x, y), new Fels(x, y));
                }
                else {
                    WorldMap.Add((x, y), new FreeSpace(x, y));
                } 
            }
        }

        // Gang nach oben
        for (int y = 5; y < 20; y++) {
            for (int x = -2; x <= 2; x++)
            {
                if (x == -2 || x == 2)
                {
                    WorldMap.Add((x, y), new Fels(x, y));
                }
                else
                {
                    WorldMap.Add((x, y), new FreeSpace(x, y));
                }
            }
        }

        // Spwan Area für Gegner
        for (int x = -4; x <= 4; x++)
        {
            for (int y = 20; y <= 29; y++)
            {
                if (x == -4 || x == 4 || y == 20 || y == 29)
                {
                    if ((-2 < x && x < 2) && y == 20)
                    {
                        WorldMap.Add((x, y), new FreeSpace(x, y));
                    }
                    else
                        WorldMap.Add((x, y), new Fels(x, y));
                }
                else
                {
                    WorldMap.Add((x, y), new FreeSpace(x, y));
                }
            }
        }

        new Baue_Kern(null, this).DoAktionAsGeneration();
        new Baue_GegnerTor(null, this).DoAktionAsGeneration();
    }

    // Gibt Welt größe an
    public int WorldSize { get { return WorldMap.Count; } }
    
    // Gibt Hitbox zurück
    public Hitbox GetHitbox(int x, int y)
    {
        if (!IstDa(x, y))
        {
            return Hitbox.None;
        }

        return WorldMap[(x, y)].GetHitbox;
    }

    // Gibt Grafik zurück
    public char Grafik(int x, int y)
    {
        return WorldMap[(x, y)].Grafik;
    }

    // Gibt zurück ob existiert
    public bool IstDa(int x, int y)
    {
        return WorldMap.ContainsKey((x, y));
    }

    // Anmelden für Gebäude Update:
    public void GebaudeAnmelden(Gebäude gebäude)
    {
        if (gebäude == null) { return; }

        if (UpdateListe.Contains(gebäude)) 
        { 
            return;
        }
        else
        {
            UpdateListe.Add(gebäude);
        }
    }

    // Abmelden für Gebäude Update:
    public void GebaudeAbmelden(Gebäude gebäude)
    {
        if (gebäude == null) { return; }

        if (UpdateListe.Contains(gebäude))
        {
            UpdateListe.Remove(gebäude);
        }
        else
        {
            return;
        }
    }

    public void GebaudeUpdaten(GameBoard World, GamePeaces WorldOfPeaces)
    {
        foreach (var item in UpdateListe)
        {
            item.Update(World, WorldOfPeaces);
        }
    }

    // Gibt zurück ob da eine Figur ist?
    public bool IstDaFigur(int x, int y)
    {
        // Check ob Da
        if (!IstDa(x, y))
            return false;

        // Versuche den Ort als FreeSpace zu interpretiern.
        FreeSpace? Ort = WorldMap[(x, y)] as FreeSpace;

        if (Ort == null)
            return false;

        // Schaue ob Ort keine Figur hat?
        return Ort.IstDaEineSpielFigur;
    }

    // Füge Figur zum Feld hinzu
    public bool PlatziereFigur(int x, int y, Controller Figur)
    {
        // Check ob Da
        if (!IstDa(x, y))
            return false;

        // Check ob Hitbox = 0
        if (GetHitbox(x, y) != Hitbox.FreeSpace)
            return false;

        FreeSpace? Ort = WorldMap[(x, y)] as FreeSpace;

        if (Ort == null)
            return false;

        Ort.SpielFigur = Figur;
        
        return true;
    }

    // Entferne Figur vom Feld
    public bool EntferneFigur(int x, int y, Controller Figur)
    {
        // Check ob Da
        if (!IstDa(x, y))
            return false;

        // Versuche den Ort als FreeSpace zu interpretiern.
        FreeSpace? Ort = WorldMap[(x, y)] as FreeSpace;

        if (Ort == null)
            return false;

        // Schaue ob Ort keine Figur hat?
        if (!Ort.IstDaEineSpielFigur)
            return false;

        // Ort hat eine Figur, als nächstes schauen ob diese Identisch sind.
        if (Ort.SpielFigur == Figur)
        {
            Ort.SpielFigur = null;
            return true;
        }
        else
        {   // Denn die Angegbene Figur ist nicht an dem Ort und deswegen wird die dortige nicht entfernt.
            return false;
        }
    }

    public bool ErsetzeFeld(Tile AltesFeld, int x, int y, Tile NewsFeld)
    {
        // Ersetzen nicht durch null
        if (AltesFeld == null || NewsFeld == null)
        {
            return false;
        }

        // Existiert das Feld überhaubt
        if (!IstDa(x, y)) { return false; }

        if (IstDaFigur(x, y))
        {
            return false;
        }

        // Platz für mehr Checks


        WorldMap.Remove((x, y));
        WorldMap.Add((x, y), NewsFeld);
        return true;
    }

    public bool FuegeEinFeldHinzu(int x, int y, Tile NewsFeld)
    {
        // Keine Leeren Felder
        if (NewsFeld == null)
        { 
            return false; 
        }

        // Wenn x und y schon Feld dann auch nicht
        if (IstDa(x, y))
        {
            return false;
        }

        WorldMap.Add((x, y), NewsFeld);
        return true;
    }

    public bool FuegeDemFeldSchadenZu(int x, int y, int Schaden, Schadensarten Art)
    {
        if (!IstDa(x, y))
        {
            return false;
        }

        if (Schaden <= 0)
        {
            return false;
        }

        return WorldMap[(x, y)].ErhalteSchaden(Schaden, Art, this);
    }

    public bool BaueGebaeuedeTile(int x, int y, Gebäude Gebaude)
    {
        // Kein Gebäude übergeben
        if (Gebaude == null) { return false; }

        // Ist da ein Feld
        if (!IstDa(x, y)) { return false; }

        // Versuche den Ort als FreeSpace zu interpretiern.
        FreeSpace? Ort = WorldMap[(x, y)] as FreeSpace;

        if (Ort == null)
            return false;

        // Steht da eine Figur?
        if (IstDaFigur(x, y)) { return false; }

        GebaudeAnmelden(Gebaude);

        return ErsetzeFeld(Ort, x, y, Gebaude);
    }
}
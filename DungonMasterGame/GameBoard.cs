public class GameBoard
{
    private Dictionary<(int, int), Tile> WorldMap;

    public GameBoard()
    {
        WorldMap = new Dictionary<(int, int), Tile>();

        // Mache 3x3 Kasten

        for (int x = -2; x <= 2; x++)
        {
            for (int y = -2; y <= 2; y++)
            {
                if (x == -2 || x == 2 || y == -2 || y == 2)
                {
                    WorldMap.Add((x, y), new Fels(x, y));
                }
                else {
                    WorldMap.Add((x, y), new FreeSpace(x, y));
                } 
            }
        }
    }

    // Gibt Welt größe an
    public int WorldSize { get { return WorldMap.Count; } }
    
    // Gibt Hitbox zurück
    public int Hitbox(int x, int y)
    {
        return WorldMap[(x, y)].Hitbox;
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

    // Füge Figur zum Feld hinzu
    public bool PlatziereFigur(int x, int y, Controller Figur)
    {
        // Check ob Da
        if (!IstDa(x, y))
            return false;

        // Check ob Hitbox = 0
        if (Hitbox(x, y) != 0)
            return false;

        FreeSpace? Ort = WorldMap[(x, y)] as FreeSpace;

        if (Ort == null)
            return false;

        Ort.SpielFigur = Figur;
        
        return true;
    }
}
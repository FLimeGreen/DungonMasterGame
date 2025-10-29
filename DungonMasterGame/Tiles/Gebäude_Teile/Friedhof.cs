using System.Windows.Media.Media3D;

public class Friedhof : Gebäude
{
    public Friedhof(int x, int y) : base(x, y)
    {
        hitbox = Hitbox.Friedhof;
        structurpunkte = 20;
        grafik = 'F';
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
            // Ersetze durch FreeSpace
            var newSpace = new FreeSpace(x, y);
            return World.ErsetzeFeld(this, x, y, newSpace);
        }

        return false;
    }

    public bool Spawn(GameBoard World, GamePeaces WorldOfPeaces)
    {
        var Spwanpoint = FreeSpwanPoint(WorldOfPeaces, World);

        // Spawnpoint der Block selber?
        if (Spwanpoint.Item1 == x && Spwanpoint.Item2 == y) { return false; }

        //Entität neu
        var Entitaet = new HelferController(Spwanpoint.Item1, Spwanpoint.Item2);

        //Entität aufs Spielbrett setzen
        World.PlatziereFigur(Spwanpoint.Item1, Spwanpoint.Item2, Entitaet);

        return WorldOfPeaces.AddNewHelper(Entitaet);
    }

}
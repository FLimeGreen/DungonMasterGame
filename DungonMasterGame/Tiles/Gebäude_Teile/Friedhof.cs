using System.Windows.Media.Media3D;

public class Friedhof : Gebäude
{
    DateTime LastSpwan;
    TimeSpan SpwanCooldown = new TimeSpan(0, 0, 0, 2, 0);

    int SpwanMenge = 0;

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
        if (SpwanMenge < 4)
        {
            // Gib an Ob Cooldown abegelaufen ist?
            if (DateTime.Now - LastSpwan > SpwanCooldown)
            {
                Spawn(World, WorldOfPeaces);
                LastSpwan = DateTime.Now;
                SpwanMenge++;
            }
        }
    }

    public bool Spawn(GameBoard World, GamePeaces WorldOfPeaces)
    {
        var Spwanpoint = FreeSpwanPoint(WorldOfPeaces, World);

        // Spawnpoint der Block selber?
        if (Spwanpoint.Item1 == x && Spwanpoint.Item2 == y) { return false; }

        //Entität neu
        var Entitaet = new Skelett(Spwanpoint.Item1, Spwanpoint.Item2, WorldOfPeaces);

        //Entität aufs Spielbrett setzen
        World.PlatziereFigur(Spwanpoint.Item1, Spwanpoint.Item2, Entitaet);

        return WorldOfPeaces.AddNewHelper(Entitaet);
    }

}
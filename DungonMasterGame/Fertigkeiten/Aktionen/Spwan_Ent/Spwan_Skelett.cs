using DungonMasterGame;
using DungonMasterGame.Figuren;
using DungonMasterGame.Figuren.Pathfinding.Helfer;
using DungonMasterGame.Tiles;

public class Spwan_Skelett : Spwan
{
    public Spwan_Skelett(Controller Controller, GameBoard world, GamePeaces worldOfPeaces) : base(Controller, world, worldOfPeaces, new TimeSpan(0, 0, 0, 2, 0))
    {
        name = "Spwane Skelett";
        beschreibung = "Spwant ein Skellet vor dir das durch die gegend Läuft.";
    }

    public Spwan_Skelett(Tile Controller, GameBoard world, GamePeaces worldOfPeaces) : base(Controller, world, worldOfPeaces, new TimeSpan(0, 0, 0, 2, 0))
    {

    }

    protected override bool DoAktionAsTile()
    {
        var Spwanpoint = FreeSpwanPoint(WorldOfPeaces, World);

        // Spawnpoint der Block selber?
        if (Spwanpoint.Item1 == x && Spwanpoint.Item2 == y) { return false; }

        Skelett Entitaet;

        // Anmelden Bei Friedhof
        var fried = tile_controller as Friedhof;
        if (fried is not null)
        {
            Entitaet = new Skelett(Spwanpoint.Item1, Spwanpoint.Item2, fried, WorldOfPeaces);
            fried.Skelett_Anmelden(Entitaet);
        }
        else
        {
            //Entität neu
            Entitaet = new Skelett(Spwanpoint.Item1, Spwanpoint.Item2, WorldOfPeaces);
        }

        //Entität aufs Spielbrett setzen
        World.PlatziereFigur(Spwanpoint.Item1, Spwanpoint.Item2, Entitaet);

        return WorldOfPeaces.AddNewHelper(Entitaet);
    }

    protected override bool DoAktionAsFigur()
    {
        if (figur_controller == null) { return false; }

        var temp_pos = figur_controller.GetLooking(2);

        x = temp_pos.Item1;
        y = temp_pos.Item2;

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

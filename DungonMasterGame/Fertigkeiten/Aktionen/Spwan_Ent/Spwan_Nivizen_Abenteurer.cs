using DungonMasterGame;
using DungonMasterGame.Figuren;
using DungonMasterGame.Figuren.Pathfinding.Gegner;
using DungonMasterGame.Tiles;

public class Spwan_Novizen_Abenteurer : Spwan
{
    public Spwan_Novizen_Abenteurer(Controller Controller, GameBoard world, GamePeaces worldOfPeaces) : base(Controller, world, worldOfPeaces, new TimeSpan(0, 0, 0, 2, 0))
    {

    }

    public Spwan_Novizen_Abenteurer(Tile Controller, GameBoard world, GamePeaces worldOfPeaces) : base(Controller, world, worldOfPeaces, new TimeSpan(0, 0, 0, 2, 0))
    {

    }

    protected override bool DoAktionAsTile()
    {
        var Spwanpoint = FreeSpwanPoint(WorldOfPeaces, World);

        // Spawnpoint der Block selber?
        if (Spwanpoint.Item1 == x && Spwanpoint.Item2 == y) { return false; }

        //Entität neu
        var Entitaet = new Novizen_Abenteurer(Spwanpoint.Item1, Spwanpoint.Item2, WorldOfPeaces);

        //Entität aufs Spielbrett setzen
        World.PlatziereFigur(Spwanpoint.Item1, Spwanpoint.Item2, Entitaet);

        return WorldOfPeaces.AddNewGegner(Entitaet);
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
        var Entitaet = new Novizen_Abenteurer(Spwanpoint.Item1, Spwanpoint.Item2, WorldOfPeaces);

        //Entität aufs Spielbrett setzen
        World.PlatziereFigur(Spwanpoint.Item1, Spwanpoint.Item2, Entitaet);

        return WorldOfPeaces.AddNewGegner(Entitaet);
    }
}

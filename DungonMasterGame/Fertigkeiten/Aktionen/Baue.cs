public abstract class Baue : Aktion
{
    protected GameBoard world;
    protected GamePeaces worldofpeaces;

    protected Baue(Controller Controller, GameBoard world, GamePeaces worldofpeaces, TimeSpan Cooldown) : base(Controller, Cooldown)
    {
        this.world = world;
        this.worldofpeaces = worldofpeaces;
    }

    protected Baue(Tile Controller, TimeSpan Cooldown) : base(Controller, Cooldown)
    {
        throw new NotImplementedException("Gebäude sollen erstmal noch nicht bauen können.");
    }

    protected bool IstBauBerreichFrei(List<(int, int)> Bauorte, int x, int y)
    {
        foreach (var pos in Bauorte)
        {
            // Get relative Baukoordinaten
            int r_x = pos.Item1 + x;
            int r_y = pos.Item2 + y;


            // Ist da ein Feld
            if (!world.IstDa(r_x, r_y)) { return false; }

            // Versuche den Ort als FreeSpace zu interpretiern.
            if (world.GetHitbox(r_x, r_y) != Hitbox.FreeSpace) { return false; }

            // Steht da eine Figur?
            if (world.IstDaFigur(r_x, r_y)) { return false; }
        }

        return true;
    }

    protected bool BaueInWorld(int x, int y, Gebäude gebäudeTile)
    {
        return world.BaueGebaeuedeTile(x, y, gebäudeTile);
    }
}

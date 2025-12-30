public abstract class Spwan : Aktion
{
    protected GameBoard World;
    protected GamePeaces WorldOfPeaces;

    protected int x = 0;
    protected int y = 0;

    public Spwan(Controller Controller, GameBoard world, GamePeaces worldOfPeaces, TimeSpan Cooldown) : base(Controller, Cooldown)
    {
        this.World = world;
        this.WorldOfPeaces = worldOfPeaces;

    }

    public Spwan(Tile Controller, GameBoard world, GamePeaces worldOfPeaces, TimeSpan Cooldown) : base(Controller, Cooldown)
    {
        this.World = world;
        this.WorldOfPeaces = worldOfPeaces;

        x = Controller.X;
        y = Controller.Y;
    }

    protected (int, int) FreeSpwanPoint(GamePeaces WorldofPEaces, GameBoard World)
    {
        if (WorldofPEaces == null) { return (y, x); }

        int c_x = x;
        int c_y = y;

        // Ist da Platz dann Spwane Figur

        //Norden
        if (World.GetHitbox(c_x, c_y + 1) == Hitbox.FreeSpace)
        {
            if (!World.IstDaFigur(c_x, c_y + 1))
            {
                return (c_x, c_y + 1);
            }
        }

        //Osten
        if (World.GetHitbox(c_x + 1, c_y) == Hitbox.FreeSpace)
        {
            if (!World.IstDaFigur(c_x + 1, c_y))
            {
                return (c_x + 1, c_y);
            }
        }

        //Süden
        if (World.GetHitbox(c_x, c_y - 1) == Hitbox.FreeSpace)
        {
            if (!World.IstDaFigur(c_x, c_y - 1))
            {
                return (c_x, c_y - 1);
            }
        }

        //Westen
        if (World.GetHitbox(c_x - 1, c_y) == Hitbox.FreeSpace)
        {
            if (!World.IstDaFigur(c_x - 1, c_y))
            {
                return (c_x - 1, c_y);
            }
        }

        return (c_x, c_y);
    }
}

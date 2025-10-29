public abstract class Gebäude : Tile
{
    protected Gebäude(int x, int y) : base(x, y)
    {
        
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

        //Westen
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
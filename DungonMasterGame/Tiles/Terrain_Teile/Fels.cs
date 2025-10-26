public class Fels : Terrain
{
    public Fels(int x, int y) : base(x, y)
    {
        hitbox = Hitbox.Wall;
        grafik = '#';
    }
}
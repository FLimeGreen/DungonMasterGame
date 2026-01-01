public abstract class Tile
{
    protected int x;
    protected int y;
    protected int? structurpunkte;
    protected Hitbox hitbox;
    protected GrafikContainer[] grafik = new GrafikContainer[2];

    public Tile(int x, int y)
    {
        this.x = x;
        this.y = y;
        structurpunkte = null;
        hitbox = Hitbox.None;
        grafik[0] = new GrafikContainer(x, y, '?', "");
    }

    public int X { get { return x; } }
    public int Y { get { return y; } }

    public virtual Hitbox GetHitbox { get { return hitbox; } }

    public GrafikContainer?[] Grafik { get { return grafik; } }

    public virtual int? Struckturpunkte { get { return structurpunkte; } }

    public virtual bool IstDaEineSpielFigur { get { return false; } }

    public virtual bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        // Negativer Schaden Erxistiert nicht.
        if (Schaden <= 0)
        {
            return false;
        }

        // Wenn Structurpunkte null Objekt unzerstörbar.
        if (structurpunkte == null)
        {
            return false;
        }

        throw new NotImplementedException("Override for Objekt that shoud take damage!");
    }
}
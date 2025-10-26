public abstract class Tile
{
    protected int x;
    protected int y;
    protected Hitbox hitbox;
    protected char grafik;
    
    public Tile(int x, int y)
    {
        this.x = x;
        this.y = y;
        hitbox = Hitbox.None;
        grafik = '?';
    }

    public virtual Hitbox GetHitbox {  get { return hitbox; } }

    public virtual char Grafik { get { return grafik; } }

    public virtual bool IstDaEineSpielFigur {  get { return false; } }
}
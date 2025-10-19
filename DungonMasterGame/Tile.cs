public abstract class Tile
{
    protected int x;
    protected int y;
    protected int hitbox;
    protected char grafik;
    
    public Tile(int x, int y)
    {
        this.x = x;
        this.y = y;
        hitbox = 0;
        grafik = '#';
    }

    public virtual int Hitbox {  get { return hitbox; } }

    public virtual char Grafik { get { return grafik; } }

    public virtual bool IstDaEineSpielFigur {  get { return false; } }
}
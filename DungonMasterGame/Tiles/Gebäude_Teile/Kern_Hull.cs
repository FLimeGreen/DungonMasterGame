using System.Windows.Documents;

public class Kern_Hull : Gebäude
{
    private Kern_Kern kernVerweis;
    public Kern_Hull(int x, int y) : base(x, y)
    {
        hitbox = Hitbox.Kern;
        grafik = 'K';
    }

    public Kern_Kern KernVerweis
    {
        set { kernVerweis = value; }
    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        return kernVerweis.ErhalteSchaden(Schaden, Art, World);
    }

    public bool Destroy(Kern_Kern verify, GameBoard World)
    {
        if (verify != kernVerweis) { return false; }
        
        // Melde Ab
        World.GebaudeAbmelden(this);

        // Ersetze durch FreeSpace
        var newSpace = new FreeSpace(this.x, this.y);
        World.ErsetzeFeld(this, this.x, this.y, newSpace);

        return true;
    }
}

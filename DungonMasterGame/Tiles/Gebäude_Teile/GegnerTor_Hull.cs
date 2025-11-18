using System.Windows.Documents;

public class GegnerTor_Hull : Gebäude
{
    private GegnerTor_Kern kernVerweis;
    public GegnerTor_Hull(int x, int y) : base(x, y)
    {
        hitbox = Hitbox.GegnerTor;
        grafik = 'G';
    }

    public GegnerTor_Kern KernVerweis
    {
        set { kernVerweis = value; }
    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        return kernVerweis.ErhalteSchaden(Schaden, Art, World);
    }

    public bool Destroy(GegnerTor_Kern verify, GameBoard World)
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

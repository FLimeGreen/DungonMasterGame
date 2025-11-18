public class GegnerTor_Kern : Gebäude
{
    private List<GegnerTor_Hull> gebauedeTeile;

    public GegnerTor_Kern(int x, int y, GameBoard world) : base(x, y)
    {
        // Stats Hinzufügen und Verhalten. Sowie auch von Kern Hülle.
        hitbox = Hitbox.GegnerTor;
        structurpunkte = 10;
        grafik = 'G';
    }

    public List<GegnerTor_Hull> HuelleErstzen 
    {
        set { gebauedeTeile = value;}
    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        if (Schaden <= 0)
        {
            return false;
        }

        structurpunkte = structurpunkte - Schaden;

        if (structurpunkte <= 0)
        {
            // Melde Ab
            World.GebaudeAbmelden(this);

            // Ersetze durch FreeSpace
            var newSpace = new FreeSpace(this.x, this.y);
            World.ErsetzeFeld(this, this.x, this.y, newSpace);

            foreach (var hull in gebauedeTeile)
            {
                hull.Destroy(this, World);
            }
        }

        return true;
    }
}

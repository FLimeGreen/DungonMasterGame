using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;

public class Friedhof : Gebäude
{
    int SpwanMenge = 0;

    public Friedhof(int x, int y, GameBoard world, GamePeaces worldPeaces) : base(x, y)
    {
        hitbox = Hitbox.Friedhof;
        structurpunkte = 20;
        grafik = 'F';

        aktions_Manager.AktionHinzufügen(new Spwan_Skelett(this, world, worldPeaces), new TimeSpan(0, 0, 0, 2, 0), 0);
    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        // Negativer Schaden Erxistiert nicht.
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
            var newSpace = new FreeSpace(x, y);
            return World.ErsetzeFeld(this, x, y, newSpace);
        }

        return true;
    }

    public override void Update(GameBoard World, GamePeaces WorldOfPeaces)
    {
        if (SpwanMenge < 4)
        {
            // Gib an Ob Cooldown abegelaufen ist?
            aktions_Manager.DoAction(0);

            SpwanMenge++;
        }
    }

}
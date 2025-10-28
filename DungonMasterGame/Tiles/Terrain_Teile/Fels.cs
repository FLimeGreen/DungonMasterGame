public class Fels : Terrain
{
    public Fels(int x, int y) : base(x, y)
    {
        hitbox = Hitbox.Wall;
        structurpunkte = 5;
        grafik = '#';
    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        if (Art == Schadensarten.physisch)
        {
            Schaden = Schaden * 2;
        }

        structurpunkte = structurpunkte - Schaden;

        if (structurpunkte <= 0) 
        {
            // Ersetze durch FreeSpace
            var newSpace = new FreeSpace(x, y);
            World.ErsetzeFeld(this, x, y, newSpace);


            // Platziere Wände
            // Check alle vier Richtungen ob da schon ein Feld ist?
            
            // Damit die Orginal Position nicht verändert wird.
            int c_x = x;
            int c_y = y;
            // Norden
            if (!World.IstDa(c_x, c_y++))
            {
                // Füge da eine Wand ein
                World.FuegeEinFeldHinzu(c_x, c_y++, new Fels(c_x, c_y++));
            }

            c_x = x;
            c_y = y;
            // Osten
            if (!World.IstDa(c_x++, c_y))
            {
                // Füge da eine Wand ein
                World.FuegeEinFeldHinzu(c_x++, c_y, new Fels(c_x++, c_y));
            }

            c_x = x;
            c_y = y;
            // Süden
            if (!World.IstDa(c_x, c_y--))
            {
                // Füge da eine Wand ein
                World.FuegeEinFeldHinzu(c_x, c_y--, new Fels(c_x, c_y--));
            }

            c_x = x;
            c_y = y;
            // Westen
            if (!World.IstDa(c_x--, c_y))
            {
                // Füge da eine Wand ein
                World.FuegeEinFeldHinzu(c_x--, c_y, new Fels(c_x--, c_y));
            }

        }

        return true;
    }
}
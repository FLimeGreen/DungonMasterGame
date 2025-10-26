using System.ComponentModel.DataAnnotations;

public class FreeSpace : Terrain
{
    // Spielfigur Speicher:

    protected Controller? Figur;

    public FreeSpace(int x, int y) : base(x, y)
    {
        // Nichts auf dem Feld
        hitbox = Hitbox.FreeSpace;
        grafik = '_';
    }
    public override Hitbox GetHitbox 
    {
        get {
            
            if (Figur == null)
            {
                return Hitbox.FreeSpace;
            } // Figur ist Spieler
            else if (Figur as PlayerController != null)
            {
                return Hitbox.FreeSpace_with_Player;
            }
            
            
            return Hitbox.None;
        }
    }

    public override char Grafik 
    {
        get 
        {
            if (IstDaEineSpielFigur)
            {
                if (Figur != null)
                    return Figur.Grafik;
                throw new Exception("Spannender Fall der Untersucht werden muss: " + IstDaEineSpielFigur + "  nun das Objekt:" + Figur);
            }
            else
            {
                return base.Grafik;
            }
        } 
    }

    public override bool IstDaEineSpielFigur { get { return Figur != null; } }

    public Controller? SpielFigur 
    { 
        get { return Figur; }
        set { Figur = value; }
    }
}
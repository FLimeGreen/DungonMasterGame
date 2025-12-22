using System.ComponentModel.DataAnnotations;

public class FreeSpace : Terrain
{
    // Spielfigur Speicher:

    protected Controller? Figur;

    public FreeSpace(int x, int y) : base(x, y)
    {
        // Nichts auf dem Feld
        hitbox = Hitbox.FreeSpace;
        grafik[0] = new GrafikContainer(x, y, '_', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/EinzelFelder/Free_Space.png");
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
            else if (Figur as HelferController != null) 
            {
                return Hitbox.FreeSpace_with_Supporter;
            }
            else if (Figur as GegnerController != null)
            {
                return Hitbox.FreeSpace_with_Gegner;
            }


            return Hitbox.None;
        }
    }

    public override bool IstDaEineSpielFigur { get { return Figur != null; } }

    public Controller? SpielFigur 
    { 
        get { return Figur; }
        set 
        {
            // Neu setzen oder vielleicht auch löschen.
            Figur = value;

            if (this.IstDaEineSpielFigur)
            {
                grafik[1] = Figur.Grafik;
            }
            else
            {
                grafik[1] = null;
            }
        }
    }
}
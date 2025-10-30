using System.Diagnostics.CodeAnalysis;
using System.Windows.Documents;

public abstract class Controller
{
    protected int x;
    protected int y;
    protected Heading heading;
    // 1 = Norden = W | 2 = Osten = D | 3 = Süden = S | 4 = Westen = A
    protected char grafik;

    // Charakter Eigenschaften:
    // HP
    // ATK
    // DEF

    // Wie lange warten bis nächste Bewegegung
    protected TimeSpan speed;

    // Wie lange warten bis nächste Attake
    protected TimeSpan[] actioncooldownLenght = new TimeSpan[10];

    // Cooldown: Wann ist es das letzte mal Passiert
    protected DateTime movecooldown;

    protected DateTime[] actioncooldown = new DateTime[10];


    public Controller(int x, int y)
    {
        this.x = x;
        this.y = y;
        heading = Heading.Norden; // Norden

        //Charakter Eigenschaften
        //Tagen, Stunden, Minuten, Sekunden und Millisekunden
        speed = new TimeSpan(0, 0, 0, 0, 30);
    }

    public char Grafik { get { return grafik; } }

    public int X { get { return x; } }
    public int Y { get { return y; } }

    public (int, int) GetLooking(int Distance)
    {
        switch (heading)
        {
            case Heading.Norden:
                return (x, y + Distance);

            case Heading.Osten:
                return (x + Distance, y);

            case Heading.Süden:
                return (x, y - Distance);

            case Heading.Westen:
                return (x -Distance, y);

            default: throw new Exception("Some thing faild horrible (Looking Block)x: " + x + " y: " + y + " Head: " + heading);
        }
    }

    public virtual void Update(GameBoard World, GamePeaces WorldPeaces, string[]? data = null) { }

    protected bool FeldVorDirIstFrei(GameBoard World)
    {
        int FigurX = X;
        int FigurY = Y;

        switch (heading)
        {
            case Heading.Norden:
                FigurY++;
                break;
            
            case Heading.Osten:
                FigurX++;
                break;
            
            case Heading.Süden: 
                FigurY--;
                break;
                
            case Heading.Westen:
                FigurX--;
                break;
            
            default: return false;
        }

        if (World.GetHitbox(FigurX, FigurY) == Hitbox.FreeSpace)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected bool MoveOneField(Heading Direktion, GameBoard World)
    {
        // Wenn nicht Größer als Speed noch keine Bewegung
        if (!(DateTime.Now - movecooldown > speed))
        {
            return false;
        }

        // Fals doch bewege dich:

        switch (Direktion)
        {
            case Heading.Norden:
                heading = Heading.Norden;

                // Schaue ob Platz ist?
                if (FeldVorDirIstFrei(World))
                {
                    World.EntferneFigur(X, Y, this);
                    y++;
                }
                else
                {
                    return false;
                }
                break;

            case Heading.Osten:
                heading = Heading.Osten;

                // Schaue ob Platz ist?
                if (FeldVorDirIstFrei(World))
                {
                    World.EntferneFigur(X, Y, this);
                    x++;
                }
                else
                {
                    return false;
                }
                break;

            case Heading.Süden:
                heading = Heading.Süden;

                // Schaue ob Platz ist?
                if (FeldVorDirIstFrei(World))
                {
                    World.EntferneFigur(X, Y, this);
                    y--;
                }
                else
                {
                    return false;
                }
                break;

            case Heading.Westen:
                heading = Heading.Westen;

                // Schaue ob Platz ist?
                if (FeldVorDirIstFrei(World))
                {
                    World.EntferneFigur(X, Y, this);
                    x--;
                }
                else
                {
                    return false;
                }
                break;

            default:
                return false;
        }

        // Setze neu Cooldown
        movecooldown = DateTime.Now;
        // Setze Figur neu.
        World.PlatziereFigur(X, Y, this);
        return true;
    }

    protected bool DoAction(int AktionNumber)
    {
        // Von 10 ist das keine Valiede Nummer
        if (AktionNumber < 0 ||  AktionNumber > 9)
        {
            return false;
        }

        // Wenn Keine Cooldown Length dann auch keine Hinterlegte Aktion
        if (actioncooldownLenght[AktionNumber] == null)
        {
            return false;
        }

        // Gib an Ob Cooldown abegelaufen ist?
        if (DateTime.Now - actioncooldown[AktionNumber] > actioncooldownLenght[AktionNumber])
        {
            actioncooldown[AktionNumber] = DateTime.Now;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public bool BaueGebaudeTyp(Gebäude Gebaude, GamePeaces WorldPeces)
    {
        if (Gebaude == null) { return false; }
        if (WorldPeces == null) { return false; }

        var tem = GetLooking(1);
        int _x = tem.Item1;
        int _y = tem.Item2;

        return WorldPeces.BaueGebauede(_x, _y, Gebaude);
    }

}
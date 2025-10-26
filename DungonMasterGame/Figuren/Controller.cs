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

    protected TimeSpan speed;

    // Cooldown:
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

    public virtual void Update(string[]? data = null) { }

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

    protected bool MoveOneField(int Direktion, GameBoard World)
    {
        // Wenn nicht Größer als Speed noch keine Bewegung
        if (!(DateTime.Now - movecooldown > speed))
        {
            return false;
        }

        // Fals doch bewege dich:

        switch (Direktion)
        {
            case 1:
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

            case 2:
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

            case 3:
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

            case 4:
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
}
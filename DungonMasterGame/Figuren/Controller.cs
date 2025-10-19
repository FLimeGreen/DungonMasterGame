public abstract class Controller
{
    protected int x;
    protected int y;
    protected int heading;
    // 1 = Norden | 2 = Osten | 3 = Süden | 4 = Westen
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
        heading = 1; // Norden

        //Charakter Eigenschaften
        //Tagen, Stunden, Minuten, Sekunden und Millisekunden
        speed = new TimeSpan(0, 0, 0, 1, 0);
    }

    public char Grafik { get { return grafik; } }

    public virtual void Update(string[]? data = null) { }

    protected bool MoveOneField(int Direktion)
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
                y++; 
                break;

            case 2:
                x++;
                break;

            case 3:
                y--;
                break;

            case 4:
                x--;
                break;

            default:
                return false;
        }

        // Setze neu Cooldown
        movecooldown = DateTime.Now;
        return true;
    }
}
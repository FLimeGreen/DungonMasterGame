public class PlayerController : Controller
{
    public PlayerController(int x, int y,GameBoard World, GamePeaces WorldFiguren) : base(x, y, WorldFiguren)
    {
        grafik = 'X';

        // CoolDowns:
        // Tagen, Stunden, Minuten, Sekunden und Millisekunden
        // new TimeSpan(0, 0, 0, 2, 0);

        // Fügt Aktion hinzu
        aktions_Manager.AktionHinzufügen(new Spitzhacke(WorldFiguren, this), new TimeSpan(0, 0, 0, 2, 0), 0);
        aktions_Manager.AktionHinzufügen(new Spwan_Skelett(this, World, WorldFiguren), new TimeSpan(0, 0, 0, 2, 0), 1);
    }

    public IEnumerable<bool> ActiveCoolDowns
    {
        get
        {
            return aktions_Manager.ActiveCoolDowns;
        }
    }


    // Player Move Funktion

    public void Move(Heading direction, GameBoard World)
    {
        // Erst Blickrichtung ändern bevor da hin gehen.
        if (direction != this.heading)
        {
            this.heading = direction;
            return;
        }

        // Bewege in Richtung in die du schaust.
        var check = base.MoveOneField(direction, World);

        if (!check)
        {
            Console.WriteLine("Player Bewegungsfehler Aufgetreten");
        }
    }

    public bool ActionSlot1()
    {
        // Spitzhacke
        return aktions_Manager.DoAction(0);
    }

    public bool ActionSlot2()
    {
        // Spitzhacke
        return aktions_Manager.DoAction(1);
    }
}
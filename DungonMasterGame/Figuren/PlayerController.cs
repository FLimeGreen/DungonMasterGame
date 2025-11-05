public class PlayerController : Controller
{
    public PlayerController(int x, int y, GamePeaces WorldFiguren) : base(x, y, WorldFiguren)
    {
        grafik = 'X';

        // CoolDowns:
        // Tagen, Stunden, Minuten, Sekunden und Millisekunden
        actioncooldownLenght[0] = new TimeSpan(0, 0, 0, 2, 0);
        ausgewaelteAktionen[0] = new Spitzhacke(WorldFiguren, this);
    }

    public IEnumerable<bool> ActiveCoolDowns
    {
        get
        {
            bool[] bools = new bool[actioncooldownLenght.Length];

            for (int i = 0; i < actioncooldownLenght.Length; i++)
            {
                bools[i] = DateTime.Now - actioncooldown[i] > actioncooldownLenght[i];
            }

            return bools;
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

    public bool ActionSlot1(GamePeaces WorldPeaces)
    {
        // Spitzhacke
        return DoAction(0);
    }
}
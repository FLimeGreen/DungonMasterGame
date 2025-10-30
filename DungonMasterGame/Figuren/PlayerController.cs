public class PlayerController : Controller
{
    public PlayerController(int x, int y) : base(x, y)
    {
        grafik = 'X';

        // CoolDowns:
        // Tagen, Stunden, Minuten, Sekunden und Millisekunden
        actioncooldownLenght[0] = new TimeSpan(0, 0, 0, 2, 0);
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
        var check = base.MoveOneField(direction, World);

        if (!check)
        {
            Console.WriteLine("Player Bewegungsfehler Aufgetreten");
        }
    }

    public bool ActionSlot1(GamePeaces WorldPeaces)
    {
        // Spitzhacke
        if (DoAction(0))
        {
            int Schaden = 2;
            var Art = Schadensarten.physisch;
            (int, int) Look = GetLooking(1);

             return WorldPeaces.GreifeFeldAn(Look.Item1, Look.Item2, Schaden, Art);
        }

        return false;
    }
}
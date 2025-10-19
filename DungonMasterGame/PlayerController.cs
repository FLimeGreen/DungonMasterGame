public class PlayerController : Controller
{
    public PlayerController(int x, int y) : base(x, y)
    {
        grafik = 'X';
    }

    public override void Update(string[]? data = null)
    {
        // Keine Daten Kein Update
        if (data == null) { return; }

        // Erwarteter String
        //[MoveDirection]

        // Check für Move Data
        Move(Convert.ToInt32(data[0]));

    }

    // Player Move Funktion

    private void Move(int direction)
    {
        var check = base.MoveOneField(direction);

        if (!check)
        {
            Console.WriteLine("Player Bewegungsfehler Aufgetreten");
        }
    }
}
public class PlayerController : Controller
{
    public PlayerController(int x, int y) : base(x, y)
    {
        grafik = 'X';
    }


    // Player Move Funktion

    public void Move(int direction, GameBoard World)
    {
        var check = base.MoveOneField(direction, World);

        if (!check)
        {
            Console.WriteLine("Player Bewegungsfehler Aufgetreten");
        }
    }
}
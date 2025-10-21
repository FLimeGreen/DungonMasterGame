public class GamePeaces
{
    private PlayerController Player;
    private List<Controller> Helfer;
    private List<Controller> Gegner;

    // Game Board
    private GameBoard Board;

    public GamePeaces(GameBoard Board)
    {
        Player = new PlayerController(0, 0);
        Helfer = new List<Controller>();
        Gegner = new List<Controller>();
        this.Board = Board;

        // Set up Player

        if (!Board.PlatziereFigur(0, 0, Player))
            Console.WriteLine("Fiegur Platzier Fahler");
    }

    public int GetPlayer_X { get { return Player.X; } }
    public int GetPlayer_Y { get { return Player.Y; } }
}

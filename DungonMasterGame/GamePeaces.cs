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

    public void PlayerMoveUp()
    {
        Player.Move(1, Board);
    }

    public void PlayerMoveDown()
    {
        Player.Move(3, Board);
    }

    public void PlayerMoveLeft()
    {
        Player.Move(4, Board);
    }

    public void PlayerMoveRight()
    {
        Player.Move(2, Board);
    }

    public void PlayerAction1()
    {
        Player.ActionSlot1(this);
    }

    // Angriff auf eine Feld / Figur

    public bool GreifeFeldAn(int x, int y, int Schaden, Schadensarten Art)
    {
        // Ob da?
        if (!Board.IstDa(x, y))
        {
            return false;
        }

        if (Schaden <= 0)
        {
            return false;
        }

        // Check ob da eine Figur ist?
        if (Board.IstDaFigur(x, y))
        {
            // Füge der Figur Schaden zu.
            throw new NotImplementedException();
        }
        else
        {
            // Füge dem Gebäude / Terrain Schaden zu
             return Board.FuegeDemFeldSchadenZu(x, y, Schaden, Art);
        }
    }
}

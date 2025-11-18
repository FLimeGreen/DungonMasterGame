public class GamePeaces
{
    private PlayerController Player;
    private List<HelferController> Helfer;
    private List<Controller> Gegner;

    // Game Board
    private GameBoard Board;

    public GamePeaces(GameBoard Board)
    {
        Player = new PlayerController(0, 3, Board, this);
        Helfer = new List<HelferController>();
        Gegner = new List<Controller>();
        this.Board = Board;

        // Set up Player

        if (!Board.PlatziereFigur(0, 3, Player))
            Console.WriteLine("Fiegur Platzier Fahler");
    }

    public int GetPlayer_X { get { return Player.X; } }
    public int GetPlayer_Y { get { return Player.Y; } }

    public IEnumerable<bool> GetPlayerCooldown
    {
        get {
            return Player.ActiveCoolDowns;
        }
    }

    public bool AddNewHelper(HelferController NeuHelfer)
    {
        if (NeuHelfer == null) { return false; }

        if (this.Helfer.Contains(NeuHelfer)) 
        { 
            return false; 
        }
        else
        {
            Helfer.Add(NeuHelfer);
            return true;
        }
    }

    public void UpdateHelfer()
    {
        foreach (var item in Helfer)
        {
            item.Update(Board, this);
        }
    }

    public void PlayerMoveUp()
    {
        Player.Move(Heading.Norden, Board);
    }

    public void PlayerMoveDown()
    {
        Player.Move(Heading.Süden, Board);
    }

    public void PlayerMoveLeft()
    {
        Player.Move(Heading.Westen, Board);
    }

    public void PlayerMoveRight()
    {
        Player.Move(Heading.Osten, Board);
    }

    public void PlayerAction1()
    {
        Player.ActionSlot1();
    }
    public void PlayerAction2()
    {
        Player.ActionSlot2();
    }

    public void PlayerBauAction()
    {
        Player.BaueGebaudeTyp(new Friedhof(Player.GetLooking(1).Item1, Player.GetLooking(1).Item2, Board, this), this);
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

    public bool BaueGebauede(int x, int y, Gebäude Gebaude)
    {
        if (!Board.IstDa(x, y)) { return false; }

        if (Gebaude == null) { return false; }

        // Leite an Gemaboard weiter
        return Board.BaueGebaeuedeTile(x, y, Gebaude);
    }
}

using System.Windows;

public class GamePeaces
{
    private PlayerController Player;
    private List<HelferController> Helfer;
    private List<GegnerController> Gegner;

    // Game Board
    private GameBoard Board;

    public GamePeaces(GameBoard Board)
    {
        // Deklariere Variabelen
        Player = new PlayerController(0, 3, Board, this);
        Helfer = new List<HelferController>();
        Gegner = new List<GegnerController>();
        this.Board = Board;

        // Set up Player

        if (!Board.PlatziereFigur(0, 3, Player))
            throw new Exception("Platzier Fehler bei dem Spieler.");
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

    public bool RemoveHelper(HelferController Helfer)
    {
        if (Helfer == null) { return false; }

        if (this.Helfer.Contains(Helfer))
        {
            this.Helfer.Remove(Helfer);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddNewGegner(GegnerController NeuHelfer)
    {
        if (NeuHelfer == null) { return false; }

        if (this.Gegner.Contains(NeuHelfer))
        {
            return false;
        }
        else
        {
            Gegner.Add(NeuHelfer);
            return true;
        }
    }

    public bool RemoveGegner(GegnerController Gegner)
    {
        if (Gegner == null) { return false; }

        if (this.Gegner.Contains(Gegner))
        {
            this.Gegner.Remove(Gegner);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateHelfer()
    {
        foreach (var item in Helfer)
        {
            item.Update(Board, this);
        }
    }

    public void UpdateGegner()
    {
        foreach (var item in Gegner)
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

    // Weiterleitung an PlayerController
    public void PlayerAction(int n)
    {
        Player.ActionSlot(n);
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
            return Board.FuegederFigurSchadenZu(x, y, Schaden, Art);
        }
        else
        {
            // Füge dem Gebäude / Terrain Schaden zu
             return Board.FuegeDemFeldSchadenZu(x, y, Schaden, Art);
        }
    }

}

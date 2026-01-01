using DungonMasterGame;
using DungonMasterGame.Tiles;

public abstract class Gebäude : Tile
{
    protected Action_Manager aktions_Manager = new Action_Manager();

    public string SP
    {
        get
        {
            if (structurpunkte is null)
            {
                return "Sp: infi";
            }
            else
            {
                return "Sp: " + structurpunkte;
            }
        }
    }

    public string Name { get; protected set; }

    public string Beschreibung { get; protected set; }

    public List<string> WeiterEigenschaften { get; protected set; }

    protected Gebäude(int x, int y) : base(x, y)
    {
        WeiterEigenschaften = new List<string>();
    }

    public virtual void Update(GameBoard World, GamePeaces WorldOfPeaces)
    {
        return;
    }

}
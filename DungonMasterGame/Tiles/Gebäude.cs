public abstract class Gebäude : Tile
{
    protected Action_Manager aktions_Manager = new Action_Manager();

    protected Gebäude(int x, int y) : base(x, y)
    {

    }

    public virtual void Update(GameBoard World, GamePeaces WorldOfPeaces)
    {
        return;
    }

}
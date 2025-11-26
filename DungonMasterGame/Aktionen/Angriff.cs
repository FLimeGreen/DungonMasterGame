public abstract class Angriff : Aktion
{
    protected GamePeaces WorldPeaces;

    protected string name;

    public Angriff(Controller Controller, GamePeaces WorldFiguren) : base(Controller) 
    {
        WorldPeaces = WorldFiguren;
    }

    public string Name { get { return name; } }
}

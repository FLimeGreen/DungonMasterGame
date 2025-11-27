public abstract class Angriff : Aktion
{
    protected GamePeaces WorldPeaces;

    public Angriff(Controller Controller, GamePeaces WorldFiguren) : base(Controller) 
    {
        WorldPeaces = WorldFiguren;
    }
}

public abstract class Angriff : Aktion
{
    protected GamePeaces WorldPeaces;

    public Angriff(Controller Controller, GamePeaces WorldFiguren, TimeSpan Cooldown) : base(Controller, Cooldown) 
    {
        WorldPeaces = WorldFiguren;
    }
}

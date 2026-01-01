public abstract class Aktion
{
    protected Controller? figur_controller;
    protected Tile? tile_controller;

    protected TimeSpan Cooldown_Duration;

    protected string name = "Not Given";
    protected string beschreibung = "";

    // Ausfürung durch Controller
    public Aktion(Controller Controller, TimeSpan Cooldown)
    {
        figur_controller = Controller;
        tile_controller = null;
        Cooldown_Duration = Cooldown;
    }

    public Aktion(Tile Controller, TimeSpan Cooldown)
    {
        tile_controller = Controller;
        figur_controller = null;
        Cooldown_Duration = Cooldown;
    }

    public TimeSpan CooldwonDuration { get { return Cooldown_Duration; } }

    public string Name { get { return name; } }
    public string Beschreibung { get { return beschreibung; } }

    public bool DoAktion()
    {
        if (figur_controller != null)
        {
            return DoAktionAsFigur();
        }

        if (tile_controller != null)
        {
            return DoAktionAsTile();
        }

        throw new Exception("Data Error: Sowohl Figur als auch Tile sind null. Aktion nicht ausfürbar");
    }

    protected virtual bool DoAktionAsFigur()
    {
        throw new NotImplementedException("Keine Aktion Implementiert!");
    }

    protected virtual bool DoAktionAsTile()
    {
        throw new NotImplementedException("Keine Aktion Implementiert!");
    }
}
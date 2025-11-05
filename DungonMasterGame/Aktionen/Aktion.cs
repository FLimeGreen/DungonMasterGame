public abstract class Aktion
{
    protected Controller? figur_controller;
    protected Tile? tile_controller;

    // Ausfürung durch Controller
    public Aktion(Controller Controller)
    {
        figur_controller = Controller;
        tile_controller = null;
    }

    public Aktion(Tile Controller)
    {
        tile_controller = Controller;
        figur_controller = null;
    }

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
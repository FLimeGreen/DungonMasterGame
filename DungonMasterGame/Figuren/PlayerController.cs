public class PlayerController : Controller
{
    public PlayerController(int x, int y,GameBoard World, GamePeaces WorldFiguren) : base(x, y, WorldFiguren)
    {
        grafik = 'X';

        // CoolDowns:
        // Tagen, Stunden, Minuten, Sekunden und Millisekunden
        // new TimeSpan(0, 0, 0, 2, 0);

        // Fügt Aktion hinzu
        aktions_Manager.AktionHinzufügen(new Spitzhacke(WorldFiguren, this), new TimeSpan(0, 0, 0, 2, 0), 0);
        aktions_Manager.AktionHinzufügen(new Spwan_Skelett(this, World, WorldFiguren), new TimeSpan(0, 0, 0, 2, 0), 1);
        aktions_Manager.AktionHinzufügen(new Baue_Friedhof(this, World, WorldFiguren), new TimeSpan(0, 0, 0, 0, 500), 9);
    }

    public IEnumerable<bool> ActiveCoolDowns
    {
        get
        {
            return aktions_Manager.ActiveCoolDowns;
        }
    }

    public IEnumerable<Aktion> SkillAuswahl
    {
        get { return aktions_Manager.SkillSettings; }
    }

    public bool SkillTausch(Aktion newAktion, int slot)
    {
        if (newAktion is null) { return false; }

        // Nicht selectierbarer Bereich
        if ( !(0 <= slot &&  slot <= 9)) { return false; }

        aktions_Manager.AktionEntfernen(slot);
        return aktions_Manager.AktionHinzufügen(newAktion, newAktion.CooldwonDuration, slot);
    }


    // Player Move Funktion

    public void Move(Heading direction, GameBoard World)
    {
        // Erst Blickrichtung ändern bevor da hin gehen.
        if (direction != this.heading)
        {
            this.heading = direction;
            return;
        }

        // Bewege in Richtung in die du schaust.
        var check = base.MoveOneField(direction, World);

        if (!check)
        {
            Console.WriteLine("Player Bewegungsfehler Aufgetreten");
        }
    }

    public bool ActionSlot(int n)
    {
        // Check ob Valiede Nummer
        if (0 <= n && n <= 9)
        {
            // Führe diese Aktion aus.
            return aktions_Manager.DoAction(n);
        }
        else { return false; }
    }
}
public class Action_Manager
{
    // Wie lange warten bis nächste Action
    protected TimeSpan[] actioncooldownLenght = new TimeSpan[10];

    // Wann wurde diese das Letzte Mal ausgeführt
    protected DateTime[] actioncooldown = new DateTime[10];

    // ActionsListe Welche gibt es
    protected Aktion[] ausgewaelteAktionen = new Aktion[10];

    public Action_Manager() 
    {
        
    }

    public IEnumerable<bool> ActiveCoolDowns
    {
        get
        {
            bool[] bools = new bool[actioncooldownLenght.Length];

            for (int i = 0; i < actioncooldownLenght.Length; i++)
            {
                bools[i] = DateTime.Now - actioncooldown[i] > actioncooldownLenght[i];
            }

            return bools;
        }
    }

    public bool AktionHinzufügen(Aktion newAction, TimeSpan newCooldown, int possition)
    {
        // Pos nur zwischen 0 und 10 erlaubt
        if (!(0 <= possition && possition <= 10)) { return false; }

        if (newAction == null) { return false; }
        if (newCooldown == null) { return false; }

        if (ausgewaelteAktionen[possition]  != null) { return false; }

        ausgewaelteAktionen[possition] = newAction;
        actioncooldownLenght[possition] = newCooldown;
        actioncooldown[possition] = DateTime.Now;

        return true;
    }

    public bool AktionEntfernen(int possition)
    {
        // Pos nur zwischen 0 und 10 erlaubt
        if (!(0 <= possition && possition <= 10)) { return false; }

        if (ausgewaelteAktionen[possition] == null) { return false; }

        ausgewaelteAktionen[possition] = null;
        actioncooldownLenght[possition] = new TimeSpan();
        actioncooldown[possition] = new DateTime();

        return true;
    }

    public bool DoAction(int AktionNumber)
    {
        // Von 10 ist das keine Valiede Nummer
        if (AktionNumber < 0 || AktionNumber > 9)
        {
            return false;
        }

        // Wenn Keine Cooldown Length dann auch keine Hinterlegte Aktion
        if (actioncooldownLenght[AktionNumber] == null)
        {
            return false;
        }

        // Wenn Keine Cooldown Length dann auch keine Hinterlegte Aktion
        if (ausgewaelteAktionen[AktionNumber] == null)
        {
            return false;
        }

        // Gib an Ob Cooldown abegelaufen ist?
        if (DateTime.Now - actioncooldown[AktionNumber] > actioncooldownLenght[AktionNumber])
        {
            // Führe Gewollte Aktion aus
            if (ausgewaelteAktionen[AktionNumber].DoAktion())
            {
                // Wenn klappt dann setze Cooldown
                actioncooldown[AktionNumber] = DateTime.Now;
                return true;
            } // Teile Mit das nicht geklappt.
            else { return false; }
        }
        else
        {
            return false;
        }

    }
}

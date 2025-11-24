using System.Security.Cryptography.X509Certificates;

public class Baue_Friedhof : Baue
{
    private List<(int, int)> Baupunkte = new List<(int, int)> { (0, 0) };

    public Baue_Friedhof(Controller Controller, GameBoard world, GamePeaces worldofpeaces) : base(Controller, world, worldofpeaces)
    {

    }

    protected override bool DoAktionAsFigur()
    {
        var kord = figur_controller.GetLooking(1);

        int x = kord.Item1;
        int y = kord.Item2;

        if (!IstBauBerreichFrei(Baupunkte, x, y))
        {
            return false;
        }

        BaueInWorld(x, y, new Friedhof(x, y, world, worldofpeaces));

        return true;
    }
}
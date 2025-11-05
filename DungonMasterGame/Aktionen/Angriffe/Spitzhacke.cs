public class Spitzhacke : Angriff
{
    public Spitzhacke(GamePeaces WorldFiguren, Controller Figur) : base(Figur, WorldFiguren)
    {

    }

    protected override bool DoAktionAsFigur()
    {
        // Check Figur ungleich null (Sicherheit).
        if (figur_controller == null)
        {
            return false;
        }


        int Schaden = 2;
        var Art = Schadensarten.physisch;
        (int, int) Look = figur_controller.GetLooking(1);

        return WorldPeaces.GreifeFeldAn(Look.Item1, Look.Item2, Schaden, Art);
    }
}
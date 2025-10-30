public class Skelett : HelferController
{
    public Skelett(int x, int y) : base(x, y)
    {
        grafik = 'S';

        speed = new TimeSpan(0, 0, 0, 1, 0);

        //Character Eigenschaften:
        actioncooldownLenght[0] = new TimeSpan(0, 0, 0, 2, 0);
    }

    public override void Update(GameBoard World,GamePeaces WorldPeaces, string[]? data = null)
    {
        // Move
        (int, int) FieldBefor = GetLooking(1);

        // Wenn vor die ein Supporter oder der Friedhof, dann
        if (World.GetHitbox(FieldBefor.Item1, FieldBefor.Item2) == Hitbox.FreeSpace_with_Supporter ||
            World.GetHitbox(FieldBefor.Item1, FieldBefor.Item2) == Hitbox.Friedhof)
        {
            // Ändere die Richtung im Uhrzeiger Sinn.
            switch (heading)
            {
                case Heading.Norden:
                    MoveOneField(Heading.Osten, World);
                    break;

                case Heading.Osten:
                    MoveOneField(Heading.Süden, World);
                    break;

                case Heading.Süden:
                    MoveOneField(Heading.Westen, World);
                    break;

                case Heading.Westen:
                    MoveOneField(Heading.Norden, World);
                    break;
            }
        } // BEwege dich weiter.
        else
        {
            MoveOneField(heading, World);
        }

        // Greife an.
        var temp = GetLooking(1);
        if (World.GetHitbox(temp.Item1, temp.Item2) == Hitbox.Wall)
        {
            // Spitzhacke
            if (DoAction(0))
            {
                int Schaden = 2;
                var Art = Schadensarten.physisch;
                (int, int) Look = GetLooking(1);

                WorldPeaces.GreifeFeldAn(Look.Item1, Look.Item2, Schaden, Art);
            }
        }
    }
}
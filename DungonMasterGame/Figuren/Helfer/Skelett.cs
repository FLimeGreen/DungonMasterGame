using DungonMasterGame;

public class Skelett : HelferController
{
    public Skelett(int x, int y, GamePeaces WorldFiguren) : base(x, y, WorldFiguren)
    {
        grafik = new GrafikContainer(x, y, 'S', "pack://application:,,,/WPF/Grafiken/Images/Figuren/Skelett_.png");

        speed = new TimeSpan(0, 0, 0, 1, 0);
        // Damit das Skelett sich nicht sofort Bewegt.
        movecooldown = DateTime.Now;

        //Character Eigenschaften:


        // Fügt Aktion hinzu

        // Spitzhacken Angriff
        aktions_Manager.AktionHinzufügen(new Spitzhacke(WorldFiguren, this), new TimeSpan(0, 0, 0, 2, 0), 0);
    }

    public override void Update(GameBoard World, GamePeaces WorldPeaces, string[]? data = null)
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
        UpdateGrafikRotaion();

        // Greife an.
        var temp = GetLooking(1);
        if (World.GetHitbox(temp.Item1, temp.Item2) == Hitbox.Wall)
        {
            // Spitzhacke
            aktions_Manager.DoAction(0);
        }
    }
}
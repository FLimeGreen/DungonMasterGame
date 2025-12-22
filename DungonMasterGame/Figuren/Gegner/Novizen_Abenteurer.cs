public class Novizen_Abenteurer : GegnerController
{
    public Novizen_Abenteurer(int x, int y, GamePeaces WorldFiguren) : base(x, y, WorldFiguren)
    {
        grafik = new GrafikContainer(x, y, 'N', "pack://application:,,,/WPF/Grafiken/Images/Figuren/Novice_Abenteuer.png");

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
        // Move to 0/0
        int r_x = 0 - this.x;
        int r_y = 0 - this.y;

        if (Math.Abs(r_x) >= Math.Abs(r_y)) 
        {
            // x größer
            // ist x negativ ->
            if (r_x > 0)
            {
                this.MoveOneField(Heading.Osten, World);
            }

            // ist x positiv <-
            if (r_x < 0)
            {
                this.MoveOneField(Heading.Westen, World);
            }
        }
        else
        {
            // y größer
            // ist y negativ ^
            if (r_y > 0)
            {
                this.MoveOneField(Heading.Norden, World);
            }

            // ist y positiv v
            if (r_y < 0)
            {
                this.MoveOneField(Heading.Süden, World);
            }
        }
        UpdateGrafikRotaion();
    }
}

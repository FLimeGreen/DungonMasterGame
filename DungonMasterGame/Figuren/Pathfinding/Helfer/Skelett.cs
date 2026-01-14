namespace DungonMasterGame.Figuren.Pathfinding.Helfer
{
    public class Skelett : HelferController
    {
        private Friedhof? parentFriedhof;

        private void INIT(GamePeaces WorldFiguren)
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

        public Skelett(int x, int y, GamePeaces WorldFiguren) : base(x, y, WorldFiguren)
        {
            INIT(WorldFiguren);

            this.heading = WorldFiguren.GetPlayer.Heading;
        }

        public Skelett(int x, int y, Friedhof ParentFriedhof, GamePeaces WorldFiguren) : base(x, y, WorldFiguren)
        {
            INIT(WorldFiguren);

            parentFriedhof = ParentFriedhof;
        }

        public override void Update(GameBoard World, GamePeaces WorldPeaces, string[]? data = null)
        {
            // Hat Friedhof Gebunden

            if (parentFriedhof is not null)
            {
                Advanced_AI(World);
            }
            else
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
                } // Bewege dich weiter.
                else
                {
                    MoveOneField(heading, World);
                }

                // Greife an.
                // Wall und Gegner
                var temp = GetLooking(1);
                if (World.GetHitbox(temp.Item1, temp.Item2) == Hitbox.Wall || World.GetHitbox(temp.Item1, temp.Item2) == Hitbox.FreeSpace_with_Gegner)
                {
                    // Spitzhacke
                    aktions_Manager.DoAction(0);
                }
            }

            // Allgemeine Updates
            UpdateGrafikRotaion();
        }

        private void Advanced_AI(GameBoard World)
        {
            // Return Wachpunkt
            if (Woduschonmalwarst.Count > 20) // Der Wert ist geraten
            {
                Woduschonmalwarst.Clear();
            }


            // Wenn Gegner vor dir Angreifen

            var temp = GetLooking(1);
            if (World.GetHitbox(temp.Item1, temp.Item2) == Hitbox.FreeSpace_with_Gegner)
            {
                // Spitzhacke
                aktions_Manager.DoAction(0);

                return; // Gehandelt
            }

            // Umgebungs Check nach Gegner
            foreach (var interesse in RayCastUmgebung(3, World))
            {
                if (interesse.Item2 == Hitbox.FreeSpace_with_Gegner)
                {
                    MoveOneField(interesse.Item3, World);

                    return; // Wichtiger als zum Wachpunkt
                }
            }

            if (parentFriedhof.Wachpunkt is null) return;

            // Bewege dich richtung Wachpunkt
            var move_case = Pathfinding(1, parentFriedhof.Wachpunkt.Value.Item1, parentFriedhof.Wachpunkt.Value.Item2, World);

            if (move_case.Item1)
            {
                // Hat Richtung
                MoveOneField(move_case.Item2.Value, World);
            }
            else
            {
                // Reset wo du wart
                Woduschonmalwarst.Clear();
            }
        }

        public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World, GamePeaces gamePeaces)
        {
            if (Schaden <= 0) { return false; }

            Hp = Hp - Schaden;

            if (Hp <= 0)
            {
                World.EntferneFigur(X, Y, this);
                gamePeaces.RemoveHelper(this as HelferController);

                if (parentFriedhof is not null)
                {
                    parentFriedhof.Skelett_Abnmelden(this);
                }
            }

            return true;
        }
    }
}
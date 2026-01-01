using DungonMasterGame;

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
        // Check was vor der Nase ist.
        int lockx = GetLooking(1).Item1;
        int locky = GetLooking(1).Item2;

        switch (World.GetHitbox(lockx, locky))
        {
            case Hitbox.FreeSpace_with_Supporter:
                // Greif an mit Spitzhacke
                aktions_Manager.DoAction(0);
                break;

            case Hitbox.FreeSpace_with_Player:
                // Greif an mit Spitzhacke
                aktions_Manager.DoAction(0);
                break;

            case Hitbox.Kern:
                // Greif an mit Spitzhacke
                aktions_Manager.DoAction(0);
                break;

            default:
                // Bewege dich richtung Kern
                var move_case = MoveToZiel(1, World);

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
                break;
        }

        UpdateGrafikRotaion();
    }
}

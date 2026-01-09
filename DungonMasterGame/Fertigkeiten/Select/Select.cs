using CommunityToolkit.Mvvm.ComponentModel;

namespace DungonMasterGame.Fertigkeiten.Select
{
    public partial class Select : ObservableObject
    {
        private Gebäude? ausgewaeltesGebaude;
        private PlayerController player;
        private GameBoard world;

        [ObservableProperty]
        private bool isGebaudeSelceted;

        // Grafik Informationen
        [ObservableProperty]
        private string gebaudeLP;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string beschreibung;
        [ObservableProperty]
        public List<string> andereEigenschaften;

        public Select(PlayerController Player, GameBoard World)
        {
            this.player = Player;
            this.world = World;
        }

        public bool NewSelect()
        {
            var Ort = player.GetLooking(1);
            int hit = (int)world.GetHitbox(Ort.Item1, Ort.Item2);
            // Gebaude
            if (hit.ToString().First() == '3')
            {
                ausgewaeltesGebaude = world.GetGebäude(Ort.Item1, Ort.Item2);
                GebaudeLP = ausgewaeltesGebaude.SP;
                Name = ausgewaeltesGebaude.Name;
                Beschreibung = ausgewaeltesGebaude.Beschreibung;
                AndereEigenschaften = ausgewaeltesGebaude.WeiterEigenschaften;
            }
            else
            {
                ausgewaeltesGebaude = null;
            }

            IsGebaudeSelceted = ausgewaeltesGebaude is not null;
            return true;
        }

        public void M_Key()
        {
            if (ausgewaeltesGebaude is not null)
            {
                ausgewaeltesGebaude.M_Key_Trigger(world.GetWorldPeaces);
            }
        }

        public void Update()
        {
            if (IsGebaudeSelceted)
            {
                GebaudeLP = ausgewaeltesGebaude.SP;
                Name = ausgewaeltesGebaude.Name;
                Beschreibung = ausgewaeltesGebaude.Beschreibung;
                AndereEigenschaften = ausgewaeltesGebaude.WeiterEigenschaften;
            }
        }
    }
}

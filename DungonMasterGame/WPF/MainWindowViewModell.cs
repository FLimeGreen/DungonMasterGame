using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

public partial class MainWindowViewModell : ObservableObject
{
    private GameBoard World;
    private GamePeaces WorldPeaces;

    public ObservableCollection<GrafikContainer> GrafikTiles { get; private set; }
    public ObservableCollection<GrafikContainer> GrafikFiguren { get; private set; }

    public ObservableCollection<char> AktionsLeiste { get; private set; }

    public MainWindowViewModell()
    {
        GrafikTiles = new ObservableCollection<GrafikContainer>();
        GrafikFiguren = new ObservableCollection<GrafikContainer>();
        AktionsLeiste = new ObservableCollection<char>();

        // Initialize Upddater
        var UpdateTimer = new DispatcherTimer();
        UpdateTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
        UpdateTimer.Tick += GeneralUpadate;

        // Fill Action Leiste Mit 0-9
        for (int i = 0; i < 10; i++)
        {
            string zahlen = "1234567890";
            AktionsLeiste.Add(zahlen[i]);
        }

        // Initilaze Game Data
        World = new GameBoard();
        WorldPeaces = World.GetWorldPeaces;

        UpdateGrafik();
        UpdateTimer.Start();

    }

    // Update Alle Teilnehmer
    private void GeneralUpadate(object? sender, EventArgs e)
    {
        World.GebaudeUpdaten(World, WorldPeaces);
        WorldPeaces.UpdateHelfer();
        WorldPeaces.UpdateGegner();
        UpdateGrafik();
        UpdateActionLeiste();
    }

    public void UpdateGrafik()
    {
        // myGrid.Children
        //.Cast<UIElement>()
        //.First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);

        int playerx = WorldPeaces.GetPlayer_X;
        int playery = WorldPeaces.GetPlayer_Y;

        GrafikTiles.Clear();

        double CanvasPx_X = 250 / 7;
        double CanvasPx_Y = 250 / 7;

        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                int relative_x = x - 3;
                // Weil das Grid y 0 -> 7 geht muss die rel y umgedreht werden damit bei 0 die Höchste y Korrdinate stehet.
                int relative_y = -y + 3;

                int vector_x = playerx + relative_x;
                int vector_y = playery + relative_y;

                if (World.IstDa(vector_x, vector_y))
                {
                    GrafikTiles.Add(new GrafikContainer((int)(CanvasPx_X * x), (int)(CanvasPx_Y * y), World.Grafik(vector_x, vector_y), ""));
                }
                else
                {
                    GrafikTiles.Add(new GrafikContainer((int)(CanvasPx_X * x), (int)(CanvasPx_Y * y), '?', ""));
                }
            }
        }

    }

    public void UpdateActionLeiste()
    {
        int i = 0;
        string zahlen = "1234567890";

        foreach (var status in WorldPeaces.GetPlayerCooldown)
        {

            if (status)
            {
                AktionsLeiste[i] = zahlen[i];
            }
            else
            {
                AktionsLeiste[i] = '-';
            }

            i++;
        }

    }

    // Manages Tastatur Eingabe
    [RelayCommand]
    private void Window_KeyDown(KeyEventArgs e)
    {
        // Movement WASD
        if (e.Key == Key.W)
        {
            WorldPeaces.PlayerMoveUp();
        }

        if (e.Key == Key.A)
        {
            WorldPeaces.PlayerMoveLeft();
        }

        if (e.Key == Key.S)
        {
            WorldPeaces.PlayerMoveDown();
        }

        if (e.Key == Key.D)
        {
            WorldPeaces.PlayerMoveRight();
        }

        // 1234567890 an Aktionen binden.

        if (e.Key == Key.Space || e.Key == Key.D1)
        { WorldPeaces.PlayerAction(0); }

        if (e.Key == Key.D2) { WorldPeaces.PlayerAction(1); }

        if (e.Key == Key.D3) { WorldPeaces.PlayerAction(2); }

        if (e.Key == Key.D4) { WorldPeaces.PlayerAction(3); }

        if (e.Key == Key.D5) { WorldPeaces.PlayerAction(4); }

        if (e.Key == Key.D6) { WorldPeaces.PlayerAction(5); }

        if (e.Key == Key.D7) { WorldPeaces.PlayerAction(6); }

        if (e.Key == Key.D8) { WorldPeaces.PlayerAction(7); }

        if (e.Key == Key.D9) { WorldPeaces.PlayerAction(8); }

        if (e.Key == Key.D0) { WorldPeaces.PlayerAction(9); }


        UpdateGrafik();
        UpdateActionLeiste();
    }
}

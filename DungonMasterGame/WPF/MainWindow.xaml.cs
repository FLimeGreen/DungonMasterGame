using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace DungonMasterGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameBoard World;
        private GamePeaces WorldPeaces;


        public MainWindow()
        {
            InitializeComponent();

            // Initialize Upddater
            var UpdateTimer = new DispatcherTimer();
            UpdateTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            UpdateTimer.Tick += GeneralUpadate;

            // Fill Action Leiste Mit 0-9
            for (int i = 0; i < 10; i++)
            {
                var temp = new TextBlock();
                string zahlen = "1234567890";

                temp.Name = "a" + i;
                temp.FontSize = 20;
                temp.FontWeight = FontWeights.Bold;
                temp.VerticalAlignment = VerticalAlignment.Center;
                temp.HorizontalAlignment = HorizontalAlignment.Center;
                temp.Text = "" + zahlen[i];
                Grid.SetRow(temp, 0);
                Grid.SetColumn(temp, i);

                ActionsLeiste.Children.Add(temp);
            }

            // Fill Grid with ? to Create
            var Board = GameBoard;

            for (int x = 0; x < 7;  x++)
            {
                for (int y = 0; y < 7; y++) 
                {
                    //<TextBlock x:Name="n0u0" FontSize="20" FontWeight="Bold" VerticalAlignment="Center" HorizontalAlignment="Center"
                    //Grid.Row="3" Grid.Column="3">ß</TextBlock>
                    var temp = new TextBlock();

                    temp.Name = "n" + x + "u" + y;
                    temp.FontSize = 20;
                    temp.FontWeight = FontWeights.Bold;
                    temp.VerticalAlignment = VerticalAlignment.Center;
                    temp.HorizontalAlignment = HorizontalAlignment.Center;
                    temp.Text = "?";
                    Grid.SetRow(temp, y);
                    Grid.SetColumn(temp, x);

                    Board.Children.Add(temp);
                }
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

            var Board = GameBoard;

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    //Gets the Boxes out of the Grid.
                    TextBlock temp = Board.Children
                        .Cast<TextBlock>()
                        .First(e => Grid.GetRow(e) == y && Grid.GetColumn(e) == x);
                    
                    int relative_x = x - 3;
                    // Weil das Grid y 0 -> 7 geht muss die rel y umgedreht werden damit bei 0 die Höchste y Korrdinate stehet.
                    int relative_y = -y + 3;

                    int vector_x = playerx + relative_x;
                    int vector_y = playery + relative_y;

                    if (World.IstDa(vector_x, vector_y))
                    {
                        temp.Text =  "" + World.Grafik(vector_x, vector_y);
                    }
                    else
                    {
                        temp.Text = "?";
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
                TextBlock temp = ActionsLeiste.Children
                        .Cast<TextBlock>()
                        .First(e => Grid.GetRow(e) == 0 && Grid.GetColumn(e) == i);

                if (status)
                {
                    temp.Text = "" + zahlen[i];
                }
                else
                {
                    temp.Text = "-";
                }

                i++;
            }

        }

        // Manages Tastatur Eingabe
        private void Window_KeyDown(object sender, KeyEventArgs e)
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
}
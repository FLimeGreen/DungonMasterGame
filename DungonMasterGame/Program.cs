public class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = true;
        int h = Console.WindowHeight;
        int w = Console.WindowWidth;
        
        int x_0 = w / 2;
        int y_0 = h / 2;

        int x_c = Console.CursorLeft;
        int y_c = Console.CursorTop;

        int x_r = 4;
        int y_r = 4;

        var world = new GameBoard();
        var peaces = new GamePeaces(world);

        for (int x_i = -x_r; x_i < x_r; x_i++)
        {
            for (int y_i = -y_r; y_i < y_r; y_i++)
            {
                if (world.IstDa(x_i, y_i)) 
                { 
                    Console.CursorLeft = x_i + x_0;
                    Console.CursorTop = y_i + y_0;
                    Console.Write(world.Grafik(x_i, y_i));
                }
            }
        }
    }
}
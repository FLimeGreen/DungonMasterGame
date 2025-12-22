public class GrafikContainer
{   
    public int X {  get; set; }
    public int Y { get; set; }
    public char Grafik_Char { get; set; }
    public string Grafik_Immage { get; set; }
    public double Rotation { get; set; }

    public GrafikContainer(int x, int y, char grafik_Char, string grafik_Immage, double rotation = 0)
    {
        X = x;
        Y = y;
        Grafik_Char = grafik_Char;
        Grafik_Immage = grafik_Immage;
        Rotation = rotation;
    }
}

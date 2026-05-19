using DungonMasterGame;
using DungonMasterGame.Tiles;
using DungonMasterGame.Tiles.Terrain_Teile;
using System.Text.RegularExpressions;

public class Fels : Terrain
{
    public Fels(int x, int y) : base(x, y)
    {
        hitbox = Hitbox.Wall;
        structurpunkte = 5;
        grafik[0] = new GrafikContainer(x, y, '#', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/EinzelFelder/Wand.png");
    }

    public override bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World)
    {
        // Negativer Schaden Erxistiert nicht.
        if (Schaden <= 0)
        {
            return false;
        }

        if (Art == Schadensarten.physisch)
        {
            Schaden = Schaden * 2;
        }

        structurpunkte = structurpunkte - Schaden;

        if (structurpunkte <= 0)
        {
            // Ersetze durch FreeSpace
            var newSpace = new FreeSpace(x, y);
            World.ErsetzeFeld(this, x, y, newSpace);


            // Platziere Wände
            // Check alle vier Richtungen ob da schon ein Feld ist?

            // Damit die Orginal Position nicht verändert wird.
            int c_x = x;
            int c_y = y;
            // Norden
            if (!World.IstDa(c_x, c_y + 1))
            {
                int rnd = new Random().Next(100);

                if (rnd > 75)
                {
                    var t = new Moor(c_x, c_y + 1);

                    World.FuegeEinFeldHinzu(c_x, c_y + 1, t);
                    t.MoorCreation(new Random().Next(2, 8), World);
                }
                else
                {
                    //World.FuegeEinFeldHinzu(c_x, c_y + 1, new Moor(c_x, c_y + 1, 4, World));

                    // Füge da eine Wand ein
                    World.FuegeEinFeldHinzu(c_x, c_y + 1, new Fels(c_x, c_y + 1));
                }
            }

            c_x = x;
            c_y = y;
            // Osten
            if (!World.IstDa(c_x + 1, c_y))
            {
                int rnd = new Random().Next(100);

                if (rnd > 75)
                {
                    var t = new Moor(c_x + 1, c_y);

                    World.FuegeEinFeldHinzu(c_x + 1, c_y, t);
                    t.MoorCreation(new Random().Next(2, 8), World);
                }
                else
                {
                    //World.FuegeEinFeldHinzu(c_x, c_y + 1, new Moor(c_x, c_y + 1, 4, World));

                    // Füge da eine Wand ein
                    World.FuegeEinFeldHinzu(c_x + 1, c_y, new Fels(c_x + 1, c_y));
                }
            }

            c_x = x;
            c_y = y;
            // Süden
            if (!World.IstDa(c_x, c_y - 1))
            {
                int rnd = new Random().Next(100);

                if (rnd > 75)
                {
                    var t = new Moor(c_x, c_y - 1);

                    World.FuegeEinFeldHinzu(c_x, c_y - 1, t);
                    t.MoorCreation(new Random().Next(2, 8), World);
                }
                else
                {
                    //World.FuegeEinFeldHinzu(c_x, c_y + 1, new Moor(c_x, c_y + 1, 4, World));

                    // Füge da eine Wand ein
                    World.FuegeEinFeldHinzu(c_x, c_y - 1, new Fels(c_x, c_y - 1));
                }
            }

            c_x = x;
            c_y = y;
            // Westen
            if (!World.IstDa(c_x - 1, c_y))
            {
                int rnd = new Random().Next(100);

                if (rnd > 75)
                {
                    var t = new Moor(c_x - 1, c_y);

                    World.FuegeEinFeldHinzu(c_x - 1, c_y, t);
                    t.MoorCreation(new Random().Next(2, 8), World);
                }
                else
                {
                    //World.FuegeEinFeldHinzu(c_x, c_y + 1, new Moor(c_x, c_y + 1, 4, World));

                    // Füge da eine Wand ein
                    World.FuegeEinFeldHinzu(c_x - 1, c_y, new Fels(c_x - 1, c_y));
                }
            }

        }

        return true;
    }
}
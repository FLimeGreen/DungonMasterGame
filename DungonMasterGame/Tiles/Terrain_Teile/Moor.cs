using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DungonMasterGame.Tiles.Terrain_Teile
{
    public class Moor : FreeSpace
    {
        public Moor(int x, int y) : base(x, y)
        {
            grafik[0] = new GrafikContainer(x, y, '~', "pack://application:,,,/WPF/Grafiken/Images/Gebäude_Terrain/EinzelFelder/Moor.png");

        }

        public void MoorCreation(int große, GameBoard World)
        {
            List<Moor> tmp = new List<Moor>();

            // Damit die Orginal Position nicht verändert wird.
            int c_x = x;
            int c_y = y;
            
            // Norden
            if (!World.IstDa(c_x, c_y + 1))
            {
                if (große > 0)
                {
                    große -= 1;

                    var t = new Moor(c_x, c_y + 1);
                    tmp.Add(t);

                    World.FuegeEinFeldHinzu(c_x, c_y + 1, t);
                }
                else
                {
                    // Füge da eine Wand ein
                    World.FuegeEinFeldHinzu(c_x, c_y + 1, new Fels(c_x, c_y + 1));
                }
            }

            c_x = x;
            c_y = y;
            // Osten
            if (!World.IstDa(c_x + 1, c_y))
            {
                if (große > 0)
                {
                    große -= 1;

                    var t = new Moor(c_x + 1, c_y);
                    tmp.Add(t);

                    World.FuegeEinFeldHinzu(c_x + 1, c_y, t);
                }
                else
                {
                    // Füge da eine Wand ein
                    World.FuegeEinFeldHinzu(c_x + 1, c_y, new Fels(c_x + 1, c_y));
                }
            }

            c_x = x;
            c_y = y;
            // Süden
            if (!World.IstDa(c_x, c_y - 1))
            {
                if (große > 0)
                {
                    große -= 1;

                    var t = new Moor(c_x, c_y - 1);
                    tmp.Add(t);

                    World.FuegeEinFeldHinzu(c_x, c_y - 1, t);
                }
                else
                {
                    // Füge da eine Wand ein
                    World.FuegeEinFeldHinzu(c_x, c_y - 1, new Fels(c_x, c_y - 1));
                }
            }

            c_x = x;
            c_y = y;
            // Westen
            if (!World.IstDa(c_x - 1, c_y))
            {
                if (große > 0)
                {
                    große -= 1;

                    var t = new Moor(c_x - 1, c_y);
                    tmp.Add(t);

                    World.FuegeEinFeldHinzu(c_x - 1, c_y, t);
                }
                else
                {
                    // Füge da eine Wand ein
                    World.FuegeEinFeldHinzu(c_x - 1, c_y, new Fels(c_x - 1, c_y));
                }
            }

            foreach (var mo in tmp)
            {
                mo.MoorCreation(große, World);
            }
        }
    }
}

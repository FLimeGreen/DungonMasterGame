using DungonMasterGame.Figuren.Pathfinding;

namespace DungonMasterGame.Figuren
{
    public abstract class Controller
    {
        protected int x;
        protected int y;
        protected Heading heading;
        // 1 = Norden = W | 2 = Osten = D | 3 = Süden = S | 4 = Westen = A
        protected GrafikContainer grafik;

        // Charakter Eigenschaften:
        // HP
        protected int Hp;
        // ATK
        // DEF

        // Wie lange warten bis nächste Bewegegung
        protected TimeSpan speed;

        // Cooldown: Wann ist es das letzte mal Passiert
        protected DateTime movecooldown;

        // Aktions Manager
        protected Action_Manager aktions_Manager = new Action_Manager();

        public Controller(int x, int y)
        {
            this.x = x;
            this.y = y;
            heading = Heading.Norden; // Norden

            //Charakter Eigenschaften
            Hp = 10;
            //Tagen, Stunden, Minuten, Sekunden und Millisekunden
            speed = new TimeSpan(0, 0, 0, 0, 30);
        }

        public GrafikContainer Grafik { get { return grafik; } }

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public (int, int) GetLooking(int Distance)
        {
            switch (heading)
            {
                case Heading.Norden:
                    return (x, y + Distance);

                case Heading.Osten:
                    return (x + Distance, y);

                case Heading.Süden:
                    return (x, y - Distance);

                case Heading.Westen:
                    return (x - Distance, y);

                default: throw new Exception("Some thing faild horrible (Looking Block)x: " + x + " y: " + y + " Head: " + heading);
            }
        }

        public virtual void Update(GameBoard World, GamePeaces WorldPeaces, string[]? data = null) { }

        protected bool FeldVorDirIstFrei(GameBoard World)
        {
            int FigurX = X;
            int FigurY = Y;

            switch (heading)
            {
                case Heading.Norden:
                    FigurY++;
                    break;

                case Heading.Osten:
                    FigurX++;
                    break;

                case Heading.Süden:
                    FigurY--;
                    break;

                case Heading.Westen:
                    FigurX--;
                    break;

                default: return false;
            }

            if (World.GetHitbox(FigurX, FigurY) == Hitbox.FreeSpace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool MoveOneField(Heading Direktion, GameBoard World)
        {
            // Wenn nicht Größer als Speed noch keine Bewegung
            if (!(DateTime.Now - movecooldown > speed))
            {
                return false;
            }

            // Fals doch bewege dich:

            switch (Direktion)
            {
                case Heading.Norden:
                    heading = Heading.Norden;

                    // Schaue ob Platz ist?
                    if (FeldVorDirIstFrei(World))
                    {
                        World.EntferneFigur(X, Y, this);
                        y++;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case Heading.Osten:
                    heading = Heading.Osten;

                    // Schaue ob Platz ist?
                    if (FeldVorDirIstFrei(World))
                    {
                        World.EntferneFigur(X, Y, this);
                        x++;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case Heading.Süden:
                    heading = Heading.Süden;

                    // Schaue ob Platz ist?
                    if (FeldVorDirIstFrei(World))
                    {
                        World.EntferneFigur(X, Y, this);
                        y--;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case Heading.Westen:
                    heading = Heading.Westen;

                    // Schaue ob Platz ist?
                    if (FeldVorDirIstFrei(World))
                    {
                        World.EntferneFigur(X, Y, this);
                        x--;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                default:
                    return false;
            }

            // Setze neu Cooldown
            movecooldown = DateTime.Now;
            // Setze Figur neu.
            World.PlatziereFigur(X, Y, this);
            return true;
        }

        protected bool UpdateGrafikRotaion(double StartRotaion = 0)
        {
            switch (heading)
            {
                case Heading.Norden:
                    grafik.Rotation = StartRotaion + 0;
                    break;

                case Heading.Osten:
                    grafik.Rotation = StartRotaion + 90;
                    break;

                case Heading.Süden:
                    grafik.Rotation = StartRotaion + 180;
                    break;

                case Heading.Westen:
                    grafik.Rotation = StartRotaion + 270;
                    break;

                default:
                    return false;
            }
            return true;
        }

        public virtual bool ErhalteSchaden(int Schaden, Schadensarten Art, GameBoard World, GamePeaces gamePeaces)
        {
            if (Schaden <= 0) { return false; }

            Hp = Hp - Schaden;

            if (Hp <= 0)
            {
                World.EntferneFigur(X, Y, this);

                if (this as GegnerController is not null)
                {
                    gamePeaces.RemoveGegner(this as GegnerController);
                }

                if (this as HelferController is not null)
                {
                    gamePeaces.RemoveHelper(this as HelferController);
                }

                if (this as PlayerController is not null)
                {
                    World.DuBistGestorben = true;
                }
            }

            return true;
        }

    }
}
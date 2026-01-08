using DungonMasterGame;
using DungonMasterGame.Figuren;

namespace DungonMasterGame.Figuren.Pathfinding
{
    public abstract class GegnerController : PathfindingController
    {
        protected GegnerController(int x, int y, GamePeaces WorldFiguren) : base(x, y, WorldFiguren)
        {

        }

        protected (bool, Heading?) MoveToZiel(int Radius, GameBoard World)
        {
            return Pathfinding(Radius, 0, 0, World);
        }
    }
}
using System.Collections;

namespace Forfront.Apps.Spiders
{
    public class Wall
    {
        Grid Grid { get; set; }

        public Wall(int width, int height)
        {
            Grid = new Grid(width, height);

        }
        public bool HasCell(int x, int y)
        {
            return Grid.Cells.Where(p => p.X == x && p.Y == y).Any();
        }
    }
}
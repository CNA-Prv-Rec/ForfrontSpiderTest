using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forfront.Apps.Spiders
{
    internal class Grid
    {
       internal List<Cell> Cells = new List<Cell>();

        public Grid(int width, int height)
        {
            for (var x=0;x <= width;x++) //initialising the grid
            {
                for (var y=0; y <= height;y++)
                {
                    Cells.Add(new Cell(x, y));
                }

            }
        }
    }
}

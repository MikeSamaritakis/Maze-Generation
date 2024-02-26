using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generation
{
    public class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool Visited { get; set; } = false;
        // Walls: Top, Right, Bottom, Left
        public bool[] Walls { get; set; } = { true, true, true, true };

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        // Add methods for cell logic here (e.g., CheckNeighbors)
    }
}

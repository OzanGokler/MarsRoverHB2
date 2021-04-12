using MarsRover2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover2.Controller
{
    public class GridController
    {
        private readonly Grid _grid;

        public GridController(Grid grid)
        {
            _grid = grid;
        }

        public Grid GetGrid()
        {
            return _grid;
        }

        public void SimulateGrid()
        {
            _grid.SimulateGrid();
        }
    }
}

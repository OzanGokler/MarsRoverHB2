using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover2.Exceptions
{
    [Serializable]
    public class GridOutOfBoundsException : Exception
    {
        public GridOutOfBoundsException() : base(String.Format("Rover is out of grid. Simulation ended!"))
        {

        }
    }
}

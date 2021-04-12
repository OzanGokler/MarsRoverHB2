using MarsRover2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover2.Controller
{
    public class RoverController
    {
        private readonly Rover _rover;

        public RoverController(Rover rover)
        {
            _rover = rover;
        }

        public Rover GetRover()
        {
            return _rover;
        }
        public void Move()
        {
            _rover.Move();
        }
        public void ChangeDirection(char direction)
        {
            _rover.ChangeDirection(direction);
        }

    }
}
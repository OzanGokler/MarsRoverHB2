using MarsRover2.Controller;
using MarsRover2.Exceptions;
using MarsRover2.Interfaces;
using System.Collections.Generic;

namespace MarsRover2.Model
{
    public class Grid: IGrid
    {
        public int Length { get; set; }

        public int Width { get; set; }

        public List<RoverController> RoverControllers { get; set; }

        public Grid()
        {

        }

        public Grid(int length, int width, List<RoverController> roverControllers)
        {
            Length = length;
            Width = width;
            RoverControllers = roverControllers;
        }

        public void SimulateGrid()
        {

            foreach (var roverControl in RoverControllers)
            {
                for (int i = 0; i < roverControl.GetRover().MoveList.Count; i++)
                {
                    if (roverControl.GetRover().MoveList[i] == 'L' || roverControl.GetRover().MoveList[i] == 'R')
                    {
                        roverControl.ChangeDirection(roverControl.GetRover().MoveList[i]);
                    }
                    else if (roverControl.GetRover().MoveList[i] == 'M')
                    {
                        if (CheckRoverCollision(roverControl.GetRover(), RoverControllers))
                        {
                            MakeMove(roverControl.GetRover());
                        }
                        if (!CheckGridBounds(roverControl.GetRover()))
                        {
                            throw new GridOutOfBoundsException();
                        }
                    }
                    else
                    {
                        throw new InvalidDirectionException();
                    }
                }
            }
        }


        private void MakeMove(Rover rover)
        {
            rover.Move();
        }

        public bool CheckRoverCollision(Rover rover, List<RoverController> roverControllers)
        {
            if (roverControllers.Exists(x => x.GetRover().ID != rover.ID && x.GetRover().X == rover.X && x.GetRover().Y == rover.Y))
            {
                throw new RoverCollisionException(rover.ID, "X=" + rover.X + " Y=" + rover.Y);
            }
            return true;
        }

        private bool CheckGridBounds(Rover rover)
        {
            if (rover.X > Width || rover.X < 0 || rover.Y > Length || rover.Y < 0)
            {
                return false;
            }
            return true;
        }
    }
}

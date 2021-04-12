using MarsRover2.Enum;
using MarsRover2.Exceptions;
using MarsRover2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover2.Model
{
    public class Rover: IRover
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public List<char> MoveList = new List<char>();

        public Rover()
        {

        }

        public Rover(int id, int x, int y, Direction direcion, List<char> moveList)
        {
            ID = id;
            X = x;
            Y = y;
            Direction = direcion;
            MoveList = moveList;
        }

        public void Move()
        {
            if(Direction == Direction.E)
            {
                MoveEast();
            }
            else if(Direction == Direction.W)
            {
                MoveWest();
            }
            else if (Direction == Direction.S)
            {
                MoveSouth();
            }
            else
            {
                MoveNorth();
            }
        }

        public Direction ChangeDirection(char direction)
        {
            if (direction == 'L')
            {
                ChangeDirectionLeft();
            }
            else if (direction == 'R')
            {
                ChangeDirectionRight();
            }
            return Direction;
        }



        private int MoveNorth()
        {
            Y += 1;
            return Y;
        }

        private int MoveSouth()
        {
            Y -= 1;
            return Y;
        }
        private int MoveEast()
        {
            X += 1;
            return X;
        }

        private int MoveWest()
        {
            X -= 1;
            return X;
        }

        private void ChangeDirectionLeft()
        {
            if (Direction == Direction.E)
            {
                Direction = Direction.N;
            }
            else if (Direction == Direction.N)
            {
               Direction = Direction.W;
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.S;
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.E;
            }
            else
            {
                throw new DirectionChangeException();
            }
        }

        private void ChangeDirectionRight()
        {
            if (Direction == Direction.E)
            {
                Direction = Direction.S;
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.W;
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.N;
            }
            else if (Direction == Direction.N)
            {
                Direction = Direction.E;
            }
            else
            {
                throw new DirectionChangeException();
            }
        }

    }
}

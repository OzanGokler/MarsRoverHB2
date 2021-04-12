using MarsRover2.Enum;
using MarsRover2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MarsRover2Test
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void Move()
        {
            Rover myRover = new Rover();
            myRover.X = 2;
            myRover.Y = 2;

            myRover.Direction = Direction.N;
            myRover.Move();
            Assert.AreEqual(myRover.Y, 3);

            myRover.Direction = Direction.E;
            myRover.Move();
            Assert.AreEqual(myRover.X, 3);

            myRover.Direction = Direction.S;
            myRover.Move();
            Assert.AreEqual(myRover.Y, 2);

            myRover.Direction = Direction.W;
            myRover.Move();
            Assert.AreEqual(myRover.X, 2);
        }

        [TestMethod]
        public void ChangeDirection()
        {
            Rover myRover = new Rover();
            myRover.X = 2;
            myRover.Y = 2;

            myRover.Direction = Direction.N;

            myRover.ChangeDirection('L');
            Assert.AreEqual(myRover.Direction, Direction.W);

            myRover.ChangeDirection('R');
            Assert.AreEqual(myRover.Direction, Direction.N);
        }
    }
}

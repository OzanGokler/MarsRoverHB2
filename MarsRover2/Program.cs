using MarsRover2.Controller;
using MarsRover2.Enum;
using MarsRover2.Exceptions;
using MarsRover2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRover = true;
            bool inputDone = false;
            int gridLenght = 0, gridWight = 0, id = 0;
            Rover myRover = new Rover();

            List<RoverController> myRoverContollers = new List<RoverController>();

            while (inputDone == false)
            {
                //case'deki input giriş şekline göre yapıldı.
                string input;
                List<string> inpultList = new List<string>();
                while (!string.IsNullOrEmpty(input = Console.ReadLine()))
                {
                    inpultList.Add(input);
                }
                try
                {
                    for (int i = 0; i < inpultList.Count; i++)
                    {
                        if (i == 0)// ilk input gridin eni ve boyu için 
                        {
                            for (int j = 0; j < inpultList[i].Length; j++)
                            {
                                string[] subs = inpultList[i].Split(' ');
                                gridWight = Convert.ToInt32(subs[0]);
                                gridLenght = Convert.ToInt32(subs[1]);
                            }
                        }
                        else
                        {
                            if (isRover == true)
                            {
                                string[] subs = inpultList[i].Split(' ');

                                myRover.X = Convert.ToInt32(subs[0]);
                                myRover.Y = Convert.ToInt32(subs[1]);
                                switch (subs[2])
                                {
                                    case "N":
                                        myRover.Direction = Direction.N;
                                        break;
                                    case "E":
                                        myRover.Direction = Direction.E;
                                        break;
                                    case "S":
                                        myRover.Direction = Direction.S;
                                        break;
                                    case "W":
                                        myRover.Direction = Direction.W;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Rover Direction Input. Try again...");
                                        inputDone = false;
                                        break;

                                }
                                isRover = false;
                            }
                            else
                            {
                                foreach (var item in inpultList[i])
                                {
                                    myRover.MoveList.Add(item);
                                }
                                myRover.ID = id;
                                id++;
                                myRoverContollers.Add(new RoverController(myRover));
                                myRover = new Rover();
                                isRover = true;
                            }
                        }
                    }
                    inputDone = true;
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message + " Try Again...");
                    inputDone = false;
                }
                catch (OverflowException exception)
                {
                    Console.WriteLine(exception.Message + " Try Again...");
                    inputDone = false;
                }
                catch (IndexOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message + " Try Again...");
                    inputDone = false;
                }
                
            }

            GridController gridController = new GridController(new Grid(gridLenght, gridWight, myRoverContollers));

            try
            {
                gridController.SimulateGrid();
            }
            catch (GridOutOfBoundsException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidDirectionException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (RoverCollisionException e)
            {
                Console.WriteLine(e.Message);
            }



            foreach (var item in gridController.GetGrid().RoverControllers)
            {
                Console.WriteLine(item.GetRover().X + " " + item.GetRover().Y + " " + item.GetRover().Direction);
            }

            Console.ReadKey();
        }
    }
}
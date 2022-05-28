using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _7x7_game
{
    internal class Program
    {
        static Random rnd = new Random();


        static string[,] startMap = { { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " },
                                      { " H ","   ", " H ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " # ", "   "," H " },
                                      { " H "," H ", "   ", "   ", " H ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", "   ", "   ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", " H ", "   ", "   "," H " },
                                      { " H ","   ", " H ", " C ", "   ", "   ", "   ", "   "," H " },
                                      { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " }};

        static byte[] startPlayerLocation = { 2, 6 };


        static string[,] map = startMap;

        static byte[] playerLocation = startPlayerLocation;

        static MowingCube player = new MowingCube(new Color[] { Color.kék, Color.kék, Color.piros, Color.kék, Color.kék });

        static int WaitTime =500;
        static void Main(string[] args)
        {
            string[,] map = startMap;

            byte[] playerLocation = startPlayerLocation;

            RefressTabe();

            //Winner();

            //ProbaHiba(WaitTime);
            //FejlestettProbaHiba(WaitTime);

            //RestartosProbaHiba(1,500);
            //FejlestettRestartosProbaHiba(50,500);

            EgyLépcsősMálységiKeresés(10);

            Console.ReadKey();
        }

        static void RefressTabe()
        {
            Console.Clear();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
            Console.WriteLine(String.Format($"        {player.GetColor(0)}"));
            Console.WriteLine(String.Format($"    {player.GetColor(1)} {player.GetColor(2)} {player.GetColor(3)}"));
            Console.WriteLine(String.Format($"        {player.GetColor(4)}"));
        }

        static public string UserMoveUp()
        {
            string succes = "";
            byte[] palayerLocation2 = playerLocation;
            Console.Clear();
            map = player.MoveUp(map,playerLocation, out succes, out palayerLocation2);
            playerLocation = palayerLocation2;
            RefressTabe();
            return succes;
        }
        static public string UserMoveDown()
        {
            string succes = "";
            byte[] playerLocation2 = playerLocation;
            Console.Clear();
            map = player.MoveDown(map, playerLocation, out succes, out playerLocation2);
            playerLocation = playerLocation2;
            RefressTabe();
            return succes;
        }
        static public string UserMoveLeft()
        {
            string succes = "";
            byte[] playerLocation2 = playerLocation;
            Console.Clear();
            map = player.MoveLeft(map, playerLocation, out succes, out playerLocation2);
            playerLocation = playerLocation2;
            RefressTabe();
            return succes;
        }
        static public string UserMoveRight()
        {
            string succes = "";
            byte[] playerLocation2 = playerLocation;
            Console.Clear();
            map = player.MoveRight(map, playerLocation, out succes, out playerLocation2);
            playerLocation = playerLocation2;
            RefressTabe();
            return succes;
        }

        static public void Winner()
        {
            Thread.Sleep(WaitTime);
           UserMoveRight();

            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(WaitTime);
                UserMoveDown();
            }

            Thread.Sleep(WaitTime);
            UserMoveLeft();

            Thread.Sleep(WaitTime);
            UserMoveDown();

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(WaitTime);
                UserMoveLeft();
            }

            Console.WriteLine("Finish");
        }

        static public void ProbaHiba(int wait)
        {
            string succes = "";

            while (succes != "failed")
            {
                int nextStep = rnd.Next(0, 3);

                switch (nextStep)
                {
                    case 0:
                        succes = UserMoveUp();
                        break;
                    case 1:
                        succes = UserMoveDown();
                        break;
                    case 2:
                        succes = UserMoveRight();
                        break;
                    case 3:
                        
                        succes = UserMoveLeft();
                        break;
                }
                Thread.Sleep(wait);
            }
        }
        static public void FejlestettProbaHiba(int wait)
        {
            string succes = "";
            int lastStep = 9;

            while (succes != "failed")
            {
                int nextStep = rnd.Next(0, 3);

                while (nextStep == lastStep)
                {
                    nextStep = rnd.Next(0, 3);
                }

                switch (nextStep)
                {
                    case 0:
                        succes = UserMoveUp();
                        lastStep = 1;
                        break;
                    case 1:
                        succes = UserMoveDown();
                        lastStep = 0;
                        break;
                    case 2:
                        succes = UserMoveRight();
                        lastStep = 3;
                        break;
                    case 3:
                        succes = UserMoveLeft();
                        lastStep = 2;
                        break;
                }
                Thread.Sleep(wait);
            }
        }

        static public void RestartosProbaHiba(int waitBetweenSteps, int waitBetweenStarts)
        {
            while(playerLocation[0] != 7 && playerLocation[1] != 3)
            {
                playerLocation = new byte[] { 2, 6 };
                map = new string[,] { { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " },
                                      { " H ","   ", " H ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " # ", "   "," H " },
                                      { " H "," H ", "   ", "   ", " H ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", "   ", "   ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", " H ", "   ", "   "," H " },
                                      { " H ","   ", " H ", " C ", "   ", "   ", "   ", "   "," H " },
                                      { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " }
                };
                player = new MowingCube(new Color[] { Color.kék, Color.kék, Color.piros, Color.kék, Color.kék });

                ProbaHiba(waitBetweenSteps);

                Thread.Sleep(waitBetweenStarts);
            }
        }
        static public void FejlestettRestartosProbaHiba(int waitBetweenSteps, int waitBetweenStarts)
        {
            while (playerLocation[0] != 7 && playerLocation[1] != 3)
            {
                playerLocation = new byte[] { 2, 6 };
                map = new string[,] { { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " },
                                      { " H ","   ", " H ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " # ", "   "," H " },
                                      { " H "," H ", "   ", "   ", " H ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", "   ", "   ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", " H ", "   ", "   "," H " },
                                      { " H ","   ", " H ", " C ", "   ", "   ", "   ", "   "," H " },
                                      { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " }
                };
                player = new MowingCube(new Color[] { Color.kék, Color.kék, Color.piros, Color.kék, Color.kék });

                FejlestettProbaHiba(waitBetweenSteps);

                Thread.Sleep(waitBetweenStarts);
            }
        }

        static public void EgyLépcsősMálységiKeresés(int wait)
        {
            string succes = "";

            int steps = 0;

            while (succes != "failed")
            {
                bool up = player.TryMoveUp(map,playerLocation);
                bool down = player.TryMoveDown(map, playerLocation);
                bool left = player.TryMoveLeft(map, playerLocation);
                bool right = player.TryMoveRight(map, playerLocation);

                List<int> possiblestep = new List<int>();

                if (up)
                {
                    possiblestep.Add(0);
                }
                if (down)
                {
                    possiblestep.Add(1);
                }
                if (right)
                {
                    possiblestep.Add(2);
                }
                if (left)
                {
                    possiblestep.Add(3);
                }

                int nextStep = rnd.Next(0, possiblestep.Count);

                switch (possiblestep[nextStep])
                {
                    case 0:
                        succes = UserMoveUp();
                        break;
                    case 1:
                        succes = UserMoveDown();
                        break;
                    case 2:
                        succes = UserMoveRight();
                        break;
                    case 3:
                        succes = UserMoveLeft();
                        break;
                }

                if (succes == "Finish")
                {
                    Console.WriteLine("Lépések száma: " + steps);
                    break;
                }

                steps++;

                Thread.Sleep(wait);
            }
        }

    }
}

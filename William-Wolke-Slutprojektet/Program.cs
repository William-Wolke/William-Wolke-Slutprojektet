using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace William_Wolke_Slutprojektet
{
    class Program
    {
        static void Main(string[] args)
        {
            //En 10*10 2d array
            int[,] board = new int[10, 10];

            int[] currentPosition = { 0, 0 };

            int[] formerPosition = { 9, 9 };

            bool win = false;

            PlaceShips(board);


            //WHile loop eftersom att man inte vet hur många gånger spelaren kommer att skjuta innan spelet är över
            while (win == false)
            {
                

                PlotBoard(board, currentPosition);

                Console.WriteLine();
                ChangePositionOrFire(currentPosition, board);

            }
        }

        private static int[,] PlaceShips(int[,] board)
        {
            Random generator = new Random();

            board[generator.Next(10), generator.Next(10)] += 1;
            

            return board;
        }

        private static void PlotBoard(int[,] board, int[] currentPosition)
        {
            Console.Clear();
            //FOr loop eftersom att den endast kommer köras ett visst antal gånger
            for (int i = 0; i < 10; i++)
            {
                //for loop eftersom att den alltid kommer köras 10 gånger
                for (int j = 0; j < 10; j++)
                {
                    if (i == currentPosition[0] && j == currentPosition[1]) 
                    {
                        Console.Write("[ * ]");
                    }

                    else if (board[i, j] == 2)
                    {
                        Console.Write("[ O ]");
                    }

                    else if (board[i, j] == 3)
                    {
                        Console.Write("[ X ]");
                    }

                    else
                    {
                        Console.Write("[   ]");
                    }


                }
                Console.WriteLine();

            }
        }

        private static int[] ChangePositionOrFire(int[] currentPosition, int[,] board)
        {
            ConsoleKeyInfo ValidKeys = Console.ReadKey(true);

            if (ValidKeys.Key == ConsoleKey.W)
            {
                if (currentPosition[0] == 0)
                {
                    return currentPosition; 
                }

                else
                {
                    currentPosition[0] -= 1;
                    return currentPosition;
                }
            }

            else if (ValidKeys.Key == ConsoleKey.S)
            {
                if (currentPosition[0] == 9)
                {
                    return currentPosition;
                }

                else
                {
                    currentPosition[0] += 1;
                    return currentPosition;
                }

            }

            else if (ValidKeys.Key == ConsoleKey.A)
            {
                if (currentPosition[1] == 0)
                { 
                    return currentPosition;
                }

                else
                {
                    currentPosition[1] -= 1;
                    return currentPosition;
                }
            }

            else if (ValidKeys.Key == ConsoleKey.D)
            {
                if (currentPosition[1] == 9)
                { 
                    return currentPosition;
                }

                else
                {
                    currentPosition[1] += 1;
                    return currentPosition;
                }

            }

            else if (ValidKeys.Key == ConsoleKey.F)
            {
                Shoot(currentPosition, board);
            }

            else
            {
                Console.WriteLine("Fel knapptryck");
            }

            return currentPosition;
        }

        private static void Shoot(int[] currentPosition, int[,] board)
        {
            int[,] shotSpots = new int[10, 10];

            int playerPoints = 0;

            if (board[currentPosition[0], currentPosition[1]] == 1) 
            {
                if (shotSpots[currentPosition[0], currentPosition[1]] == 0)
                {
                    board[currentPosition[0], currentPosition[1]] += 2;

                    shotSpots[currentPosition[0], currentPosition[1]] = 1;
                }


            }

            else if (board[currentPosition[0], currentPosition[1]] == 0)
            {
                board[currentPosition[0], currentPosition[1]] += 2;
            }

            if (board[currentPosition[0], currentPosition[1]] == 3)
            {

                Console.WriteLine("Lemur träff");
            }

            else if (board[currentPosition[0], currentPosition[1]] == 2)
            {
                Console.WriteLine("Lemur miss");
            }
            //shotSpots håller koll på vart man skjuter så att man inte skjuter på ett ställe flera gånger och kanske får mer poäng etc
            shotSpots[currentPosition[0], currentPosition[1]] = 1;
        }
    }
}

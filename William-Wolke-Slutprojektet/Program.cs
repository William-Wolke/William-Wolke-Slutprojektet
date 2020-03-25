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
            int [,] board;
            //En 10*10 2d array
            board = new int[10, 10];

            int[] currentPosition = { 0, 0 };

            int[] formerPosition = { 9, 9 };

            //WHile loop eftersom att man inte vet hur många gånger spelaren kommer att skjuta innan spelet är över
            while (1 == 1)
            {
                PlotBoard(board, formerPosition, currentPosition);

                Console.WriteLine();
                ChangePositionOrFire(currentPosition, board);

                

            }
        }

        private static void PlotBoard(int[,] board, int[] formerPosition, int[] currentPosition)
        {
            Console.Clear();
            //FOr loop eftersom att den endast kommer köras ett visst antal gånger
            for (int i = 0; i < 10; i++)
            {
                //for loop eftersom att den alltid kommer köras 10 gånger
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] == 0)
                    {
                        Console.Write("[   ]");
                    }

                    else if (board[i, j] == board[currentPosition[0],currentPosition[1]])
                    {
                        Console.Write("[ * ]");

                      
                    }

                    else if (board[i, j] == 3)
                    {
                        Console.Write("[ Hit ]");
                    }

                    else if (board[i, j] == 4)
                    {
                        Console.Write("[ Miss ]");
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
                board[currentPosition[0], currentPosition[1]] += 1;

                if (board[currentPosition[0], currentPosition[1]] == 2) {

                    Console.WriteLine("Lemur träff"); 
                }

                else if (board[currentPosition[0], currentPosition[1]] == 1)
                {
                    Console.WriteLine("Lemur miss");
                }
                    

            }

            else
            {
                Console.WriteLine("Fel knapptryck");
            }

            return currentPosition;
        }

    }
}

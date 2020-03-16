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

            int[] formerPosition = { 0, 0 };

            //WHile loop eftersom att man inte vet hur många gånger spelaren kommer att skjuta innan spelet är över
            while (1 == 1)
            {
                Console.Clear();
                board[formerPosition[0], formerPosition[1]] = 0;
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

                        else if (board[i, j] == 1)
                        {
                            Console.Write("[ * ]");

                            formerPosition[0] = i;
                            formerPosition[1] = j;
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                ChangePosition(currentPosition);
                board[currentPosition[0], currentPosition[1]] = 1;
            }
        }

        private static int[] ChangePosition(int[] currentPosition)
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

            if (ValidKeys.Key == ConsoleKey.A)
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
                    currentPosition[1] = 9;
                    return currentPosition;
                }

                else
                {
                    currentPosition[1] += 1;
                    return currentPosition;
                }

            }
            return currentPosition;
        }

    }
}

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
            //currentposition visar ens nuvarande läge och styr då markören.
            int[] currentPosition = { 0, 0 };

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
            for (int i = 0; i < 2; i++)
            {
                PlaceDestoyerHorizontal(board);
            }

            for (int j = 0; j < 2; j++)
            {
                PlaceDestroyerVertikal(board);
            }

            for (int l = 0; l < 2; l++)
            {
                PlaceCruiserVertikal(board);
            }

            PlaceCruiserHorizontal(board);

            return board;
        }

        private static int[,] PlaceCruiserVertikal(int[,] board)
        {
            Random generator = new Random();

            int cruiserYAxis = 0;

            int cruiserXAxis = 0;

            bool overlap = false;

            bool finished = false;

            while (finished == false)
            {
                cruiserYAxis = generator.Next(10);

                cruiserXAxis = generator.Next(10);

                overlap = false;

                for (int index = 0; index < 3; index++)
                {   //så den inte sätter skepp utanför index
                    while (cruiserYAxis > 7)
                    {
                        cruiserYAxis = generator.Next(10);
                    }
                    board[cruiserYAxis + index, cruiserXAxis] += 1;
                }
                //for loop för att jag vet att den alltid kommer att köras 10 gånger
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j] == 2)
                        {
                            //overlap finns eftersom att 
                            overlap = true;
                        }
                    }
                }

                if (overlap == true)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        board[cruiserYAxis + index, cruiserXAxis] -= 1;
                    }
                }

                else
                {
                    finished = true;
                }
            }
            return board;
        }

        private static int[,] PlaceCruiserHorizontal(int[,] board)
        {
            Random generator = new Random();

            int cruiserYAxis = 0;

            int cruiserXAxis = 0;

            bool overlap = false;

            bool finished = false;

            while (finished == false)
            {
                cruiserYAxis = generator.Next(10);

                cruiserXAxis = generator.Next(10);

                overlap = false;

                for (int index = 0; index < 3; index++)
                {

                    while (cruiserXAxis > 7)
                    {
                        cruiserXAxis = generator.Next(10);

                    }

                    board[cruiserYAxis, cruiserXAxis + index] += 1;
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j] == 2)
                        {
                            overlap = true;
                        }
                    }
                }

                if (overlap == true)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        board[cruiserYAxis, cruiserXAxis + index] -= 1;
                    }
                }

                else
                {
                    finished = true;
                }
            }

            return board;
        }

        private static int[,] PlaceDestroyerVertikal(int[,] board)
        {
            Random generator = new Random();

            int destroyerYAxis = 0;

            int destroyerXAxis = 0;

            bool overlap = false;

            bool finished = false;

            while (finished == false)
            {
                destroyerYAxis = generator.Next(10);

                destroyerXAxis = generator.Next(10);

                overlap = false;

                for (int index = 0; index < 2; index++)
                {   //så den inte sätter skepp utanför index
                    while (destroyerYAxis > 7)
                    {
                        destroyerYAxis = generator.Next(10);
                    }
                    board[destroyerYAxis + index, destroyerXAxis] += 1;
                }
                //for loop för att jag vet att den alltid kommer att köras 10 gånger
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j] == 2)
                        {
                            //overlap finns eftersom att 
                            overlap = true;
                        }
                    }
                }

                if (overlap == true)
                {
                    for (int index = 0; index < 2; index++)
                    {
                        board[destroyerYAxis + index, destroyerXAxis] -= 1;
                    }
                }

                else
                {
                    finished = true;
                }
            }
            return board;
        }

        private static int[,] PlaceDestoyerHorizontal(int[,] board)
        {
            Random generator = new Random();

            int destroyerYAxis = 0;

            int destroyerXAxis = 0;

            bool overlap = false;

            bool finished = false;

            while (finished == false)
            {
                destroyerYAxis = generator.Next(10);

                destroyerXAxis = generator.Next(10);

                overlap = false;

                for (int index = 0; index < 2; index++)
                {

                    while (destroyerXAxis > 8)
                    {
                        destroyerXAxis = generator.Next(10);
                        
                    }

                    board[destroyerYAxis, destroyerXAxis + index] += 1;
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j] == 2)
                        {
                            overlap = true;
                        }
                    }
                }

                if (overlap == true)
                {
                    for (int index = 0; index < 2; index++)
                    {
                        board[destroyerYAxis, destroyerXAxis + index] -= 1;
                    }
                }

                else
                {
                    finished = true;
                }
            }

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

            else if (ValidKeys.Key == ConsoleKey.Enter)
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

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
            string[,] board;
            int[] currentPosition = { 0, 0 };

            InitialBoard(out board);
            //WHile loop eftersom att man inte vet hur många gånger 
            while (1 == 1)
            {
                //FOr loop eftersom att den endast kommer köras ett visst antal gånger
                for (int i = 0; i < 10; i++)
                {
                    //for loop eftersom att den alltid kommer köras 10 gånger
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j] == board[currentPosition[0], currentPosition[1]])
                        {
                            board[i, j] = "[ * ]";
                        }

                        else { 
                            board[i, j] = "[   ]"; 
                        }

                        Console.Write(board[i, j]);
                    }
                    Console.WriteLine();
                    currentPosition[1] += 1;
                }
                Console.ReadLine();
            }
        }

        private static string[,] InitialBoard(out string[,] board)
        {
            //En 10*10 2d array
            board = new string[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    
                }
            }

            return board;
        }
    }
}

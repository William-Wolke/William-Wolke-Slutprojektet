using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace William_Wolke_Slutprojektet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Battleship");
            string menuChoice = "0";

            string[] winners = { "", "", "" };
            bool noWinners = true;
            int[] ages = new int[3];


            while (menuChoice != "4")
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Leaderboard");
                Console.WriteLine("3. Manual");
                Console.WriteLine("4. Exit");

                menuChoice = Console.ReadLine();

                Console.WriteLine();

                switch (menuChoice)
                {
                    case "1":
                        RunGame();
                        break;

                    case "2":
                        Leaderboard(winners, ages, noWinners);
                        break;

                    case "3":
                        /*Manual();*/
                        break;

                    case "4":
                        break;

                    default:
                        Console.WriteLine("Wrong");
                        break;
                }

            }
        }

        private static void RunGame()
        {

            //En 10*10 2d array, jag använder array eftersom att spelplanen är statisk och alltid kommer att vara 10*10 och man kommer aldrig att behöva ta bort eller lägga till platser på spelplanen.
            int[,] board = new int[10, 10];
            //currentposition visar ens nuvarande läge och styr då markören.
            int[] currentPosition = { 0, 0 };

            bool runProgram = true;

            

            while (runProgram == true)
            {
                int playerPoints = 0;

                PlaceShips(board);

                PlayGame(board, currentPosition, playerPoints);

                
            }
        }

        private static void Leaderboard(string[] winners, int[] ages, bool noWinners)
        {

            Console.WriteLine("Welcome to Battleship");
            Console.WriteLine("These are todays winners:");
            Console.WriteLine();

            string name = "";

            int age = 0;

            for (int i = 0; i < winners.Length; i++)
            {
                if (winners[i] != "")
                {
                    Console.WriteLine(i + 1 + ": " + winners[i] + " " + ages[i]);
                    noWinners = false;
                }
            }

            if (noWinners == true)
            {
                Console.WriteLine("There are no winners right now");
                Console.WriteLine();
            }

            name = EnterName();

            age = EnterAge(winners, ages, age);

            for (int i = 0; i < winners.Length; i++)
            {
                if (winners[i] == "")
                {
                    winners[i] = name;
                    ages[i] = age;
                    break;
                }
            }
        }

        private static string EnterName()
        {
            Console.WriteLine("Wow you won the game, great job!");
            Console.WriteLine("Please enter your name:");
            //tar in namn input
            string name = Console.ReadLine();
            name = name.Trim();
            return name;
        }

        private static int EnterAge(string[] winners, int[] ages, int age)
        {
            age = 0;
            bool succes = false;
            

            //while loop så att man ska kunna misslyckas med att skriva in ett tal hur många gånger som helst
            while (succes == false)
            {
                Console.WriteLine("Now please enter your age");
                //tryparse för att kunna se så att det användaren skriver är ett tal
                succes = int.TryParse(Console.ReadLine(), out age);

                if (succes == false)
                {
                    Console.WriteLine("Whoops you have entered a non valid age.");
                }

                else if (age > 120)
                {
                    Console.WriteLine("Are you really that old? Try again.");
                }
            }
            return age;
        }

        private static void PlayGame(int[,] board, int[] currentPosition, int playerPoints)
        {
            bool gameOver = false;

            //WHile loop eftersom att man inte vet hur många gånger spelaren kommer att skjuta innan spelet är över
            while (gameOver == false)
            {   //skriver ut rutnätet
                PlotBoard(board, currentPosition, playerPoints);

                Console.WriteLine();
                /*playerPoint = */ChangePositionOrFire(currentPosition, board, playerPoints);
                //om man skjutit alla skepp så ska man bryta loopen och vinna spelet
                if (playerPoints >= 26)
                {
                    gameOver = true;
                }
            }
        }

        private static int[,] PlaceShips(int[,] board)
        {
            PlaceAircraftCarrier(board);

            PlaceBattleShip(board);

            for (int i = 0; i < 2; i++)
            {
                PlaceDestoyerHorizontal(board);
            }

            for (int i = 0; i < 2; i++)
            {
                PlaceDestroyerVertikal(board);
            }

            for (int i = 0; i < 2; i++)
            {
                PlaceCruiserVertikal(board);
            }

            PlaceCruiserHorizontal(board);

            return board;
        }

        private static int[,] PlaceAircraftCarrier(int[,] board)
        {
            Random generator = new Random();

            int aircraftCarrierYAxis = 0;

            int aircraftCarrierXAxis = 0;

            bool overlap = false;

            bool finished = false;
            //loopen bryts när den är klar
            while (finished == false)
            {
                aircraftCarrierYAxis = generator.Next(10);

                aircraftCarrierXAxis = generator.Next(10);

                overlap = false;

                int direction = generator.Next(2);
                //slumpar åt vilket håll skeppet ska gå åt, 
                if (direction == 1)
                {
                    for (int index = 0; index < 5; index++)
                    {   //så den inte sätter skepp utanför index
                        while (aircraftCarrierYAxis > 5)
                        {
                            aircraftCarrierYAxis = generator.Next(10);
                        }
                        board[aircraftCarrierYAxis + index, aircraftCarrierXAxis] += 1;
                    }
                }
                //detta skeppet sätts då ut horizontelt och är 5 långt
                else if (direction == 0)
                {
                    for (int index = 0; index < 5; index++)
                    {   //så den inte sätter skepp utanför index
                        while (aircraftCarrierXAxis > 5)
                        {
                            aircraftCarrierXAxis = generator.Next(10);
                        }
                        board[aircraftCarrierYAxis, aircraftCarrierXAxis + index] += 1;
                    }
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

                //när den tar bort skeppet så måste den ta bort åt rätt håll så att säga 
                if (direction == 1)
                {
                    if (overlap == true)
                    {
                        for (int index = 0; index < 5; index++)
                        {
                            board[aircraftCarrierYAxis + index, aircraftCarrierXAxis] -= 1;
                        }
                    }
                }
                //här tar den bort horizontelt skepp
                else if (direction == 0)
                {
                    if (overlap == true)
                    {
                        for (int index = 0; index < 5; index++)
                        {
                            board[aircraftCarrierYAxis, aircraftCarrierXAxis + index] -= 1;
                        }
                    }
                }

                else
                {
                    finished = true;
                }
            }
            return board;
        }

        private static int[,] PlaceBattleShip(int[,] board)
        {
            Random generator = new Random();

            int battleShipYAxis = 0;

            int battleShipXAxis = 0;

            bool overlap = false;

            bool finished = false;

            while (finished == false)
            {
                battleShipYAxis = generator.Next(10);

                battleShipXAxis = generator.Next(10);

                overlap = false;

                int direction = generator.Next(2);
                // eftersom att det bara finns ett skepp så slumpar jag vilket håll den sitter åt, 1 är horizontelt och 0 är vertikalt
                if (direction == 1)
                {   //sätter ut skeppet
                    for (int index = 0; index < 4; index++)
                    {   //så den inte sätter skepp utanför index
                        while (battleShipYAxis > 5)
                        {
                            battleShipYAxis = generator.Next(10);
                        }
                        board[battleShipYAxis + index, battleShipXAxis] += 1;
                    }
                }
                //om skeppet blev vertikalt
                else if (direction == 0)
                {   //sätter ut skeppet som är 4 långt
                    for (int index = 0; index < 5; index++)
                    {   //så den inte sätter skepp utanför index
                        while (battleShipXAxis > 5)
                        {
                            battleShipXAxis = generator.Next(10);
                        }
                        board[battleShipYAxis, battleShipXAxis + index] += 1;
                    }
                }


                //for loop för att jag vet att den alltid kommer att köras 10 gånger, kollar ifall något lappar över
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j] > 1)
                        {
                            //overlap finns eftersom att den inte ska gå igenom och ändra i if (overlap == true) flera gånger så att den
                            overlap = true;
                        }
                    }
                }
                //när den tar bort skeppet så måste den ta bort åt rätt håll så att säga 
                if (direction == 1)
                {
                    if (overlap == true)
                    {
                        for (int index = 0; index < 4; index++)
                        {
                            board[battleShipYAxis + index, battleShipXAxis] -= 1;
                        }
                    }
                }
                //här tar den bort horizontelt skepp
                else if (direction == 0)
                {
                    if (overlap == true)
                    {
                        for (int index = 0; index < 4 ; index++)
                        {
                            board[battleShipYAxis, battleShipXAxis + index] -= 1;
                        }
                    }
                }
                //om inget lappar över är den klar
                else
                {
                    finished = true;
                }
            }
            return board;
        }

        private static int[,] PlaceCruiserVertikal(int[,] board)
        {
            Random generator = new Random();

            int cruiserYAxis = 0;

            int cruiserXAxis = 0;

            bool overlap = false;

            bool finished = false;
            //medans den inte är klar
            while (finished == false)
            {
                cruiserYAxis = generator.Next(10);

                cruiserXAxis = generator.Next(10);

                overlap = false;
                //sätter ut skeppet som är 3 långt
                for (int index = 0; index < 3; index++)
                {   //så den inte sätter skepp utanför index
                    while (cruiserYAxis > 7)
                    {
                        cruiserYAxis = generator.Next(10);
                    }
                    board[cruiserYAxis + index, cruiserXAxis] += 1;
                }
                //for loop för att jag vet att den alltid kommer att köras 10 gånger, kollar igeonm ifall den överlappar
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
                //om den lappar över så tar den bort skeppet
                if (overlap == true)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        board[cruiserYAxis + index, cruiserXAxis] -= 1;
                    }
                }
                //bryter loopen ifall inget gör det
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
                //sätter ut skeppet
                for (int index = 0; index < 3; index++)
                {

                    while (cruiserXAxis > 7)
                    {
                        cruiserXAxis = generator.Next(10);

                    }

                    board[cruiserYAxis, cruiserXAxis + index] += 1;
                }
                //kollar igenom board om något överlappar
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
                //tar bort skeppet
                if (overlap == true)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        board[cruiserYAxis, cruiserXAxis + index] -= 1;
                    }
                }
                // bryter loopen
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
                //tar bort skeppet om det lappar över
                if (overlap == true)
                {
                    for (int index = 0; index < 2; index++)
                    {
                        board[destroyerYAxis + index, destroyerXAxis] -= 1;
                    }
                }
                //annars är den klar och bryter loopen
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
            //overlap säger till ifall något överlappar så körs loopen igen för att få en ny position som förhoppningsvis inte lappar över
            bool overlap = false;

            bool finished = false;
            //medans den inte är klar så körs loopen
            while (finished == false)
            {   //slumpar en position
                destroyerYAxis = generator.Next(10);

                destroyerXAxis = generator.Next(10);

                overlap = false;
                // gör skeppet längre än en position(2 långt skepp)
                for (int index = 0; index < 2; index++)
                {

                    while (destroyerXAxis > 8)
                    {   //skeppet måste högst gå från 8 till 9 annars går den utanför index
                        destroyerXAxis = generator.Next(10);
                    }
                    //sätter dit skeppet
                    board[destroyerYAxis, destroyerXAxis + index] += 1;
                }
                //kollar igenom hela board för att se att inget lappar över
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
                //om något lappar över så gör den om allt såm hände innan, alltså tar bort de skepp som satts dit
                if (overlap == true)
                {
                    for (int index = 0; index < 2; index++)
                    {
                        board[destroyerYAxis, destroyerXAxis + index] -= 1;
                    }
                }
                //annars säger den att den är klar om inget lappar över
                else
                {
                    finished = true;
                }
            }

            return board;
        }

        private static void PlotBoard(int[,] board, int[] currentPosition, int playerPoints)
        {
            Console.Clear();
            //FOr loop eftersom att den endast kommer köras ett visst antal gånger
            for (int i = 0; i < 10; i++)
            {
                //for loop eftersom att den alltid kommer köras 10 gånger
                for (int j = 0; j < 10; j++)
                {
                    if (i == currentPosition[0] && j == currentPosition[1])
                    {   //rutan med markören på
                        Console.Write("[ * ]");
                    }

                    else if (board[i, j] == 2)
                    {   //Ifall man skutit på en ruta utan ett skepp
                        Console.Write("[ O ]");
                    }

                    else if (board[i, j] == 3)
                    {   //ifall man skjutit på en ruta med ett skepp på
                        Console.Write("[ X ]");
                    }

                    else
                    { // ifall inget här hänt än med rutan
                        Console.Write("[   ]");
                    }


                }
                //ny rad
                Console.WriteLine();

            }
            Console.WriteLine(playerPoints);
        }

        private static int[] ChangePositionOrFire(int[] currentPosition, int[,] board, int playerPoints)
        {   //Console.ReadKey är som console.ReadLine fast att man ska trycka på en tangent istället, lättare för navigering etc. att man inte behöver skriva rätt varje gång man ska röra markören
            ConsoleKeyInfo ValidKeys = Console.ReadKey(true);
            //ifall man trycker på w
            if (ValidKeys.Key == ConsoleKey.W)
            {   // här kollar den så man inte går upp medans man redan är längst upp och hamnar utanför index på board
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
            //om man trycker på s
            else if (ValidKeys.Key == ConsoleKey.S)
            {   // här kollar den så man inte går utanför index på board om man är längst ned
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
            //om man trycker på a
            else if (ValidKeys.Key == ConsoleKey.A)
            {   //här kollar den om man är på vänstar kanten och går åt vänster och stannar istället på samma ruta istället för att gå utanför index
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
            //om man trycker på d
            else if (ValidKeys.Key == ConsoleKey.D)
            {   //den kollar här så man inte går utanför index på board
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
            //man skjuter med enter
            else if (ValidKeys.Key == ConsoleKey.Enter)
            {
                playerPoints = Shoot(currentPosition, board, playerPoints);
            }

            else
            {
                Console.WriteLine("Fel knapptryck");
            }

            return currentPosition;
        }

        private static int Shoot(int[] currentPosition, int[,] board, int playerPoints)
        {
            int[,] shotSpots = new int[10, 10];
            //om man skjuter på en ruta med ett skepp på
            if (board[currentPosition[0], currentPosition[1]] == 1)
            {   //denna kollar så att man inte skjutit på den rutan innan, ifall man har så bara gör den inget, shotSpots är 0 på rutor man inte skjutit på
                if (shotSpots[currentPosition[0], currentPosition[1]] == 0)
                {
                    board[currentPosition[0], currentPosition[1]] += 2;

                    shotSpots[currentPosition[0], currentPosition[1]] = 1;

                    playerPoints += 1;
                }
            }
            //om man skjuter på en ruta med inget skepp på
            else if (board[currentPosition[0], currentPosition[1]] == 0)
            {   //plus två eftersom att rutor med skepp på sig har värdet 1, så 0 blir till 2 och 1 blir till 3 när de skjuts på.
                board[currentPosition[0], currentPosition[1]] += 2;
            }
             
            //shotSpots håller koll på vart man skjuter så att man inte skjuter på ett ställe flera gånger och kanske får mer poäng etc
            shotSpots[currentPosition[0], currentPosition[1]] = 1;
            return playerPoints;
        }
    }
}

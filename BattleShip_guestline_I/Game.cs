using System;

namespace BattleShip_guestline_I
{
    public class Game
    {
        public Player Player { get; set; }
        public static char[] _columns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public Computer Computer { get; set; }
        private int row;
        private int column;
        private ShootResultType result;
        private Coordinates coordinates;
        public Game(string playerName)
        {

            Player = new Player(playerName);
            Computer = new Computer("Computer");
            Computer.placeShips();
        }

        public void playRound()
        {
            proceedFirstRound();
            if (!Computer.HasLost)
            {
                computerStillAliveProcedure();
            }
        }


        private void proceedFirstRound()
        {
            proceedInputs();
            shootProcess();
        }


        private void computerStillAliveProcedure()
        {
            Console.WriteLine("Next round, if you give up and want to see Computer board, input 'Give up' as a row or column!");
            proceedInputs();
            shootProcess();
        }


        private void shootProcess()
        {
            coordinates = Player.generateCoords(row, column);
            result = Computer.processShot(coordinates);
            Player.processShootResultType(coordinates, result);
            Player.PlayerBoard.outputBoard();
        }


        private void proceedInputs()
        {
            row = proceedRowInput();
            column = proceedColumnInput();
        }


        private int proceedRowInput()
        {
            int numberVariable;
            bool flag = false;
            do
            {
                Console.WriteLine("Please input which row you want to attack (1-10):");
                var userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out numberVariable) && userInput != "Give up")
                {
                    Console.WriteLine("Not valid row number, try again(1-10):");
                }
                else if (userInput == "Give up")
                {
                    Computer.GameBoard.outputBoard();
                }
                else if (numberVariable > 10 || numberVariable <= 0)
                {
                    Console.WriteLine("Not valid row number, try again(1-10):");
                }
                else
                {
                    flag = true;
                }
            }
            while (!flag);
            return numberVariable;
        }


        public int proceedColumnInput()
        {
            char charVariable;
            bool flag = false;
            do
            {
                Console.WriteLine("Please input which column you want to attack (A-J):");
                var userInput = Console.ReadLine();
                if (!Char.TryParse(userInput, out charVariable) && userInput != "Give up")
                {
                    Console.WriteLine("Not valid colum number, try again(A-J):");
                }
                else if (userInput == "Give up")
                {
                    Computer.GameBoard.outputBoard();
                }
                else if (!isColumnNameInRange(charVariable))
                {
                    Console.WriteLine("Not valid colum number, try again(A-J):");
                }
                else
                {
                    flag = true;
                }
            }
            while (!flag);
            return charToIntTranslate(charVariable);
        }


        public bool isColumnNameInRange(char charVariable)
        {
            bool result = false;
            foreach (var column in _columns)
            {
                if (charVariable == column)
                {
                    result = true;
                }
            }
            return result;
        }


        public int charToIntTranslate(char userInput)
        {
            foreach (var column in _columns)
            {
                if (userInput == column)
                {
                    return Array.IndexOf(_columns, userInput) + 1;
                }
            }
            return 0;
        }
    }
}

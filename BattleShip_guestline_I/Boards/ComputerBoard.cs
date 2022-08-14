using System;
using System.Collections.Generic;

namespace BattleShip_guestline_I
{
    public class ComputerBoard : IBoard
    {
        public static char[] _columns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public List<Square> Squares { get; set; }

        public ComputerBoard()
        {
            Squares = new List<Square>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Squares.Add(new Square(i, j));
                }
            }
        }

        private void outputGaveUp()
        {
            Console.WriteLine("You gave up, thats a Comptuer board:   ");
        }

        public void outputBoard()
        {
            outputGaveUp();
            outputColumnsTitle();
            for (int row = 1; row <= 10; row++)
            {
                Console.Write("                ");
                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    if (ownColumn == 1)
                    {
                        Console.Write(row + "   ");
                    }
                    Console.Write(Squares.At(row, ownColumn).Status + "     ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }



        public void outputColumnsTitle()
        {
            Console.Write("                   ");
            foreach (var column in _columns)
            {
                Console.Write(column + "     ");
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}

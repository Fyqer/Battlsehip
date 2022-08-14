using System;

namespace BattleShip_guestline_I
{
    public class PlayerBoard/*just tracks player shots*/ : ComputerBoard
    {
        public static string[] columns = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        public new void outputBoard()
        {
            Console.WriteLine("Firing Board:");
            outputColumnsTitle();
            for (int row = 1; row <= 10; row++)
            {
                Console.Write("                ");
                for (int firingColumn = 1; firingColumn <= 10; firingColumn++)
                {
                    if (firingColumn == 1)
                    {
                        Console.Write(row + "   ");
                    }
                    Console.Write(Squares.At(row, firingColumn).Status + "     ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}

using System;

namespace BattleShip_guestline_I
{
    class Program
    {
        internal static string _playerName;
        static void Main(string[] args)
        {
            Game game = new Game(initializePlayerName());
            game.playRound();

            do
            {
                game.playRound();

            } while (!game.Computer.HasLost);
        }
        public static string initializePlayerName()
        {
            Console.WriteLine("Set your's battleship player nickname:");
            return _playerName = Console.ReadLine();
        }
    }
}

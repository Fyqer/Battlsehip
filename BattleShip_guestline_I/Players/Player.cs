
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip_guestline_I
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public PlayerBoard PlayerBoard { get; set; }
        public List<AShip> Ships { get; set; }
        public bool GaveUp { get; set; }
        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public Player(string name)
        {
            Name = name;
            PlayerBoard = new PlayerBoard();
            GaveUp = false;
        }


        public Coordinates generateCoords(int row, int column)
        {
            Coordinates coords = new Coordinates(row, column);
            outputCoords(coords.Row, coords.Column);
            return coords;
        }

        private void outputCoords(int row, int col)
        {
            Console.WriteLine(Name + " : \"Firing shot at " + row.ToString() + ", " + PlayerBoard._columns[col - 1] + "\"");
        }


        public void processShootResultType(Coordinates coords, ShootResultType result)
        {
            var Square = PlayerBoard.Squares.At(coords.Row, coords.Column);
            switch (result)
            {
                case ShootResultType.Hit:
                    Square.OccupationType = OccupationType.Hit;
                    break;

                default:
                    Square.OccupationType = OccupationType.Miss;
                    break;
            }
        }
    }
}

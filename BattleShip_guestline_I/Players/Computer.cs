
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip_guestline_I
{
    public class Computer : IComputer
    {
        public string Name { get; set; }
        public ComputerBoard GameBoard { get; set; }
        public List<AShip> Ships { get; set; }
        public bool HasLost
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }


        public Computer(string name)
        {
            Name = name;
            Ships = new List<AShip>()
            {
                new Destroyer(),
                new Destroyer("Destroyer2"),
                new Battleship(),
            };
            GameBoard = new ComputerBoard();
        }


        public void placeShips()
        {
            // stolen from http://stackoverflow.com/a/18267477/106356
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                bool isOpen = true;
                while (isOpen)
                {
                    var startcolumn = rand.Next(1, 11);
                    var startrow = rand.Next(1, 11);
                    int endrow = startrow, endcolumn = startcolumn;
                    var orientation = rand.Next(1, 101) % 2;

                    List<int> SquareNumbers = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endrow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endcolumn++;
                        }
                    }
                    if (isRowOrColumnBiggerThan10(endrow, endcolumn) == true)
                    {
                        isOpen = true;
                        continue;
                    }
                    var affectedSquares = GameBoard.Squares.Range(startrow, startcolumn, endrow, endcolumn);
                    if (affectedSquares.Any(x => x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }
                    setOccupationType(affectedSquares, ship);
                    isOpen = false;
                }
            }
        }


        public bool isRowOrColumnBiggerThan10(int endrow, int endcolumn)
        {
            if (endrow > 10 || endcolumn > 10)
            {
                return true;
            }
            return false;
        }


        public void setOccupationType(List<Square> affectedSquares, AShip ship)
        {
            foreach (var Square in affectedSquares)
            {
                Square.OccupationType = ship.OccupationType;
                Square.NameOfShip = ship.Name;
            }
        }


        public ShootResultType processShot(Coordinates coords)
        {
            var Square = GameBoard.Squares.At(coords.Row, coords.Column);
            if (!Square.IsOccupied)
            {
                Console.WriteLine(Name + " says: \"Miss!\"");
                return ShootResultType.Miss;
            }
            var ship = getShip(Square);
            processHit(ship);
            if (ship.IsSunk)
            {
                Console.WriteLine(Name + " says: \"You sunk my " + ship.Name + "!\"");
            }
            return ShootResultType.Hit;
        }


        public AShip getShip(Square Square)
        {
            return Ships.First(x => x.Name == Square.NameOfShip);
        }


        private void processHit(dynamic ship)
        {
            ship.Hits++;
            Console.WriteLine(Name + " says: \"Hit!\"");
        }
    }
}

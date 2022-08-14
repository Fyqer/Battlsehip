using System;
using System.ComponentModel;

namespace BattleShip_guestline_I
{
    public class Square
    {
        public OccupationType OccupationType { get; set; }
        public string NameOfShip { get; set; }
        public Coordinates Coordinates { get; set; }

        public Square(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.Empty;
            NameOfShip = String.Empty;
        }

        public string Status
        {
            get
            {
                return OccupationType.GetAttributeOfType<DescriptionAttribute>().Description;
            }
        }

        public bool IsOccupied
        {
            get
            {
                return OccupationType == OccupationType.Battleship
                    || OccupationType == OccupationType.Destroyer;
            }
        }

    }
}

using System.Collections.Generic;
using System.Linq;

namespace BattleShip_guestline_I
{
    public static class SSquareExtension
    {
        public static Square At(this List<Square> Squares, int row, int column)
        {
            return Squares.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
        }

        public static List<Square> Range(this List<Square> Squares,
                                        int startRow,
                                        int startColumn,
                                        int endRow,
                                        int endColumn)
        {
            return Squares.Where(x => x.Coordinates.Row >= startRow
                                     && x.Coordinates.Column >= startColumn
                                     && x.Coordinates.Row <= endRow
                                     && x.Coordinates.Column <= endColumn).ToList();
        }
    }
}

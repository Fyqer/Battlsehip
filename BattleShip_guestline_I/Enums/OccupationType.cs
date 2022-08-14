using System.ComponentModel;

namespace BattleShip_guestline_I
{
    public enum OccupationType
    {
        [Description("O")]
        Empty,

        [Description("B")]
        Battleship,

        [Description("D")]
        Destroyer,

        [Description("X")]
        Hit,

        [Description("M")]
        Miss
    }
}

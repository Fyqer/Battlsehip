namespace BattleShip_guestline_I
{
    public class Destroyer : AShip
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Width = 4;
            OccupationType = OccupationType.Destroyer;
        }

        public Destroyer(string name)
        {
            Name = name;
            Width = 4;
            OccupationType = OccupationType.Destroyer;
        }
    }
}

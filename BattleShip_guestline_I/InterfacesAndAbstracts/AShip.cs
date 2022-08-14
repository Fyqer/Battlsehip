namespace BattleShip_guestline_I
{
    public abstract class AShip
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Hits { get; set; }
        public OccupationType OccupationType { get; set; }
        public bool IsSunk
        {
            get
            {
                return Hits >= Width;
            }
        }
    }
}

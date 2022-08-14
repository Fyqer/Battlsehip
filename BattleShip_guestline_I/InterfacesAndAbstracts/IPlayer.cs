namespace BattleShip_guestline_I
{
    public interface IPlayer
    {
        public Coordinates generateCoords(int row, int column);
        public void processShootResultType(Coordinates coords, ShootResultType result);
    }
}




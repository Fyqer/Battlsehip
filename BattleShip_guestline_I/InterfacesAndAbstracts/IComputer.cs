namespace BattleShip_guestline_I
{
    public interface IComputer
    {
        public void placeShips();
        public ShootResultType processShot(Coordinates coords);
    }
}

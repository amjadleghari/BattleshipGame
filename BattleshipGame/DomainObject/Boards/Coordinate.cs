namespace BattleshipGame.DomainObjects.Boards
{
    public class Coordinates
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Coordinates(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public Coordinates()
        {
        }
    }
}
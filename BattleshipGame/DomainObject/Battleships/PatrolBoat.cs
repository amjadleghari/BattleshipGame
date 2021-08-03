using System;
namespace BattleshipGame.DomainObjects.Battleships
{
    public class PatrolBoat : Battleship
    {
        public PatrolBoat()
        {
            GUID = Guid.NewGuid();
            Name = "PatrolBoat";
            Width = 1;
            Length = 2;
        }
    }
}

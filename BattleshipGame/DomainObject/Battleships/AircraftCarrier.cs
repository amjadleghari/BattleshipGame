using System;

namespace BattleshipGame.DomainObjects.Battleships
{
    public class AircraftCarrier : Battleship
    {
        public AircraftCarrier()
        {
            GUID = Guid.NewGuid();
            Name = "Aircraft Carrier";
            Width = 2;
            Length = 5;

        }
    }
}

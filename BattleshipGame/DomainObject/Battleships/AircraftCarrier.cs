using System;
using System.Collections.Generic;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;

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
            ShipAlignment = Alignment.Horizontal;
            Placement = new List<(Coordinates, string)>();
        }
    }
}

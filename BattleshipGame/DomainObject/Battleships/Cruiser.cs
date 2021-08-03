using System;
using System.Collections.Generic;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;

namespace BattleshipGame.DomainObjects.Battleships
{
    public class Cruiser : Battleship
    {
        public Cruiser()
        {
            GUID = Guid.NewGuid();
            Name = "Cruiser";
            Width = 1;
            Length = 4;
            ShipAlignment = Alignment.Vertical;
            Placement = new List<(Coordinates, string)>();
        }
    }

}
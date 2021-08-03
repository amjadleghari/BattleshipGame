using System;
using System.Collections.Generic;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;

namespace BattleshipGame.DomainObjects.Battleships
{
    public class Destroyer: Battleship
    {
        public Destroyer()
        {
            GUID = Guid.NewGuid();
            Name = "Destroyer";
            Width = 1;
            Length = 3;
            ShipAlignment = Alignment.Vertical;
            Placement = new List<(Coordinates, string)>();
        }
    }

}
using System;
using System.Collections.Generic;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;

namespace BattleshipGame.DomainObjects.Battleships
{
    public class Submarine : Battleship
    {
        public Submarine()
        {
            GUID = Guid.NewGuid();
            Name = "Submarine";
            Width = 1;
            Length = 3;
            ShipAlignment = Alignment.Horizontal;
            Placement = new List<(Coordinates, string)>();
        }
    }
}


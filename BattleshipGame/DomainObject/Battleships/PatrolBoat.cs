using System;
using System.Collections.Generic;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;

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
            Placement = new List<(Coordinates, MoveOutcome)>();
        }
    }
}

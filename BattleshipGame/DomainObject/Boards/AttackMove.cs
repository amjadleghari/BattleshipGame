using System;
using BattleshipGame.DomainObjects.Boards;

namespace BattleshipGame.DomainObject.Boards
{
    public class AttackMove
    {
        public AttackMove(Coordinates _positionCoordinates)
        {
            PositionCoordinates = _positionCoordinates;
        }


        public string OutCome { get; set; }
        public Coordinates PositionCoordinates { get; set; }
    }
}

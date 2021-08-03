using System;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;

namespace BattleshipGame.DomainObject.Boards
{
    public class AttackMove
    {
        public AttackMove(Coordinates _positionCoordinates, MoveOutcome _outcome)
        {
            PositionCoordinates = _positionCoordinates;
            OutCome = _outcome;
        }


        public MoveOutcome OutCome { get; set; }
        public Coordinates PositionCoordinates { get; set; }
    }
}

using System.Collections.Generic;
using BattleshipGame.DomainObject.Boards;
using BattleshipGame.Entities;

namespace BattleshipGame.DomainObjects.Boards
{
    public class ScoreBoard
    {
        public List<AttackMove> Moves { get; set; }

        public ScoreBoard()
        {
            Moves = new List<AttackMove>();
        }

               
        public void ExecuteMove(Coordinates coordinates, MoveOutcome outcome)
        { 
            Moves.Add(new AttackMove(coordinates, outcome));
        }
    }
   
}
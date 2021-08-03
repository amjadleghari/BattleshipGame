using System.Collections.Generic;
using BattleshipGame.DomainObject.Boards;
using BattleshipGame.Entities;

namespace BattleshipGame.DomainObjects.Boards
{
    public class ScoreBoard
    {
        public List<(Coordinates, MoveOutcome)> Moves { get; set; }

        public ScoreBoard()
        {
            Moves = new List<(Coordinates, MoveOutcome)>();
        }


        // 1). Check Enemy battleship positions for the provided coordinates and if matching then mark it as Hit in battleship coordinate tuple and Add Move in MovesList
        // Returns MoveOutcome
        public AttackMove ExecuteMove(Coordinates coordinates)
        { //(MoveOutcome.M, "Type of ship if opponent ship completed destroyed or Miss / Target")
            return new AttackMove(coordinates);
        }
    }
   
}
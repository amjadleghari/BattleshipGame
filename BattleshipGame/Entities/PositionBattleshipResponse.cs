using System;
using BattleshipGame.DomainObjects.Battleships;

namespace BattleshipGame.Entities
{
    public class PositionBattleshipResponse
    {
        public PositionBattleshipResponse()
        {
        }

        public Battleship Battleship { get; set; }

        public bool IsPlacementSuccessful { get; set; }
    }
}

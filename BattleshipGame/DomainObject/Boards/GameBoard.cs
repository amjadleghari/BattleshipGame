using System.Collections.Generic;
using BattleshipGame.DomainObjects.Battleships;

namespace BattleshipGame.DomainObjects.Boards
{
    public class GameBoard
    {
        public List<Battleships.Battleship> BattleshipPlacements { get; set; }

        public GameBoard()
        {
            BattleshipPlacements = new List<Battleships.Battleship>();
        }

        public void PlaceBattleShip(Battleship Ship)
        {

        }
    }
    
}
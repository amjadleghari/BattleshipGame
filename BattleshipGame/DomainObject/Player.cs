using System;
using System.Collections.Generic;
using BattleshipGame.DomainObjects.Battleships;
using BattleshipGame.DomainObjects.Boards;
using BattleshipGame.Entities;

namespace BattleshipGame.DomainObjects
{
    public class Player
    {
        public Guid GUID { get; set; }

        public string Name { get; set; }
        
        public GameBoard GameBoard { get; set; }
        
        public ScoreBoard ScoreBoard { get; set; }

        public List<Battleship> Battleships { get; set; }

        public Player(string name, bool turn)
        {
            GUID = Guid.NewGuid();
            Name = name;
            Battleships = new List<Battleship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new AircraftCarrier(),
                new PatrolBoat()
            };
            GameBoard = new GameBoard();
            ScoreBoard = new ScoreBoard();
            IsItMyTurn = turn;
        }

        public bool IsItMyTurn { get; set; }

        public MoveOutcome NextMove(Coordinates coordinates)
        {
            //check on gameboard do we have a coordinate which coincides with requestCoordinate and if it does then return MoveOutcome.Hit else MoveOutcome.Miss 
            //ScoreBoard.Moves
            return MoveOutcome.Miss;
        }
    }
}
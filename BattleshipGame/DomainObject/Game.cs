using System;
using BattleshipGame.DomainObjects;

namespace BattleshipGame.DomainObjects
{
    public class Game
    {
        public Guid GUID { get; set; }

        public Player Player1 { get; set; }
        
        public Player Player2 { get; set; }

        //public string Outcome { get; set; }

        public Game(Player p1, Player p2)
        {
            GUID = Guid.NewGuid();
            Player1 = p1;
            Player2 = p2;
        }

        public Game()
        {
            GUID = Guid.NewGuid();
        }
    }
    
}
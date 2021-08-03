using System;
using BattleshipGame.DomainObjects.Boards;

namespace BattleshipGame.Entities
{
    public class AttackRequest
    {
        public AttackRequest()
        {
        }

        public AttackRequest(string gameGUID, string playerGUID, Coordinates attackCoordinates)
        {
            GameGUID = gameGUID;
            PlayerGUID = playerGUID;
            AttackCoordinates = attackCoordinates;
        }

        public string GameGUID { get; set; }
        public string PlayerGUID { get; set; }
        public Coordinates AttackCoordinates { get; set; }
    }
}

using System;
using BattleshipGame.DomainObjects.Boards;

namespace BattleshipGame.Entities
{
    public class PositionBattleshipRequest
    {
        public PositionBattleshipRequest()
        {
            Coordinates = new Coordinates();
        }

        public PositionBattleshipRequest(string gameGUID, string playerGUID, string battleshipGUID, Coordinates coordinates)
        {
            GameGUID = gameGUID;
            PlayerGUID = playerGUID;
            BattleshipGUID = battleshipGUID;
            Coordinates = coordinates;
        }

        public string GameGUID { get; set; }

        public string PlayerGUID { get; set; }

        public string BattleshipGUID { get; set; }

        public Coordinates Coordinates { get; set; }
    }
}

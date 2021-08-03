using System;
namespace BattleshipGame.Entities
{
    public class CreateGameResponse
    {
        public string GameGUID { get; set; }
        public string Player1GUID { get; set; }
        public string Player2GUID { get; set; }

        public CreateGameResponse(string gameGUID, string p1GUID, string p2GUID)
        {
            GameGUID = GameGUID;
            Player1GUID = p1GUID;
            Player2GUID = p2GUID;
        }

        
        public CreateGameResponse()
        {

        }
    }
}

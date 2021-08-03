using System;
namespace BattleshipGame.Entities
{
    public class CreateGameRequest
    {
        public CreateGameRequest(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
        }

        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
    }
}

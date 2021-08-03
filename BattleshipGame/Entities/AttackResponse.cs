using System;
namespace BattleshipGame.Entities
{
    public class AttackResponse
    {
        public AttackResponse()
        {
        }

        public bool IsCompleted { get; set; }

        public string MoveOutcome { get; set; }
    }
}

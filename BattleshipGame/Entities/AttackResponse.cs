using System;
namespace BattleshipGame.Entities
{
    public class AttackResponse
    {
        public AttackResponse()
        {
        }

        public AttackResponse(bool _isCompleted, string outcome)
        {
            IsCompleted = _isCompleted;
            MoveOutcome = outcome;
        }

        public bool IsCompleted { get; set; }

        public string MoveOutcome { get; set; }
    }
}

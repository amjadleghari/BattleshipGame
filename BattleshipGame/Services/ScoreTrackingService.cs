using System;
using System.Threading.Tasks;
using BattleshipGame.Entities;
using BattleshipGame.Services.Interfaces;

namespace BattleshipGame.Services
{
    public class ScoreTrackingService : IScoreTrackingService
    {
        public ScoreTrackingService()
        {
        }

        public async Task<AttackResponse> Attack(AttackRequest request)
        {
            AttackResponse retVal = new AttackResponse();
            return retVal;
        }
    }
}

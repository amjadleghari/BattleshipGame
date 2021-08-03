using System;
using System.Threading.Tasks;
using BattleshipGame.Entities;

namespace BattleshipGame.Services.Interfaces
{
    public interface IScoreTrackingService
    {
        Task<AttackResponse> Attack(AttackRequest request);
    }
}

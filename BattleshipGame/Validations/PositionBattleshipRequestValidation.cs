using System;
using BattleshipGame.Entities;
using BattleshipGame.Extensions;
using FluentValidation;

namespace BattleshipGame.Validations
{
    public class PositionBattleshipRequestValidation : AbstractValidator<PositionBattleshipRequest>
    {
        public PositionBattleshipRequestValidation()
        {
            RuleFor(x => x.GameGUID)
               .Must(field => !field.IsNullOrEmpty())
               .WithMessage(ErrorMessages.GUIDInvalid.GetDescription());

            RuleFor(x => x.BattleshipGUID)
               .Must(field => !field.IsNullOrEmpty())
               .WithMessage(ErrorMessages.GUIDInvalid.GetDescription());

            RuleFor(x => x.PlayerGUID)
               .Must(field => !field.IsNullOrEmpty())
               .WithMessage(ErrorMessages.GUIDInvalid.GetDescription());

            RuleFor(x => x.Coordinates)
               .Must(field => field.XCoordinate > 0 && field.XCoordinate <=10)
               .WithMessage(ErrorMessages.XCoordinateInvalid.GetDescription());

            RuleFor(x => x.Coordinates)
               .Must(field => field.YCoordinate > 0 && field.YCoordinate <= 10)
               .WithMessage(ErrorMessages.YCoordinateInvalid.GetDescription());
        }
    }
}
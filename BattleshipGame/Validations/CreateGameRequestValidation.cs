using System;
using BattleshipGame.Entities;
using FluentValidation;
using BattleshipGame.Extensions;

namespace BattleshipGame.Validations
{
    public class CreateGameRequestValidation : AbstractValidator<CreateGameRequest>
    {
        

        public CreateGameRequestValidation()
        {
            RuleFor(x => x.Player1Name)
               .Must(field => !field.IsNullOrEmpty())
               .WithMessage(ErrorMessages.EmptyPlayerName.GetDescription());

            RuleFor(x => x.Player2Name)
               .Must(field => !field.IsNullOrEmpty())
               .WithMessage(ErrorMessages.EmptyPlayerName.GetDescription());
        }
    }
}

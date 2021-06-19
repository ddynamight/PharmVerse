using System.Data;
using FluentValidation;
using PharmVerse.Presentation.Invites.Commands;

namespace PharmVerse.Presentation.Invites.Validators
{
     public class CreateInviteCommandValidator : AbstractValidator<CreateInviteCommand>
     {
          public CreateInviteCommandValidator()
          {
               RuleFor(e => e.Name);

               //ToDo: Add other validators
          }
     }
}
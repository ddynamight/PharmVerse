using FluentValidation;
using PharmVerse.Presentation.Invites.Commands;

namespace PharmVerse.Presentation.Invites.Validators
{
     public class UpdateInviteCommandValidator : AbstractValidator<UpdateInviteCommand>
     {
          public UpdateInviteCommandValidator()
          {
               RuleFor(e => e.Date);

               // ToDo: Add other validation
          }
     }
}
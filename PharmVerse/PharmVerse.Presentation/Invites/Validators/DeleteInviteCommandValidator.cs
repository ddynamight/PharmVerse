using FluentValidation;
using PharmVerse.Presentation.Invites.Commands;

namespace PharmVerse.Presentation.Invites.Validators
{
     public class DeleteInviteCommandValidator : AbstractValidator<DeleteInviteCommand>
     {
          public DeleteInviteCommandValidator()
          {
               RuleFor(e => e.Id);

               //ToDo: Add other validations here
          }
     }
}

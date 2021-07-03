using FluentValidation;
using PharmVerse.Presentation.Patients.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Validator
{
    public class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
    {
        public DeletePatientCommandValidator()
        {
            RuleFor(p => p.Id);
        }
    }
}

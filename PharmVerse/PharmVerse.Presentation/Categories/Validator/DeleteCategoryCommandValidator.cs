using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PharmVerse.Presentation.Categories.Commands;

namespace PharmVerse.Presentation.Categories.Validator
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty().NotNull().WithMessage("Category Id is required");
        }
    }
}

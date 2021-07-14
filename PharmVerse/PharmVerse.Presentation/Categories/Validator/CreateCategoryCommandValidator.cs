using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PharmVerse.Presentation.Categories.Commands;

namespace PharmVerse.Presentation.Categories.Validator
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage("Category name is required");
        }
    }
}

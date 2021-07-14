using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PharmVerse.Presentation.Categories.Commands;

namespace PharmVerse.Presentation.Categories.Validator
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage("Category Name is require");
            RuleFor(e => e.Id).NotEmpty().NotNull().WithMessage("Category Id is required for update");
        }
    }
}

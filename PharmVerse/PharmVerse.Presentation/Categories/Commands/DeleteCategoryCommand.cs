using MediatR;
using PharmVerse.Presentation.Categories.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandResult>
    {
        public Guid Id { get; set; }

    }
}

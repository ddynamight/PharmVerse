using MediatR;
using PharmVerse.Presentation.Categories.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

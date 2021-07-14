using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Categories;
using PharmVerse.Domain.Events.Invites;
using PharmVerse.Presentation.Categories.Commands;
using PharmVerse.Presentation.Categories.Models.Results;
using PharmVerse.Presentation.Invites.Models.Results;

namespace PharmVerse.Presentation.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResult>
    {
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;

        public DeleteCategoryCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<DeleteCategoryCommandResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
            category.AddDomainEvent(new CategoryDeletedEvent(category));
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new CategoryDeletedEvent(category), cancellationToken);

            return new DeleteCategoryCommandResult()
            {
                Id = request.Id,
                IsDeleted = true,
                Message = $"Category with Id {request} is deleted successfully"
            };
        }
    }
}

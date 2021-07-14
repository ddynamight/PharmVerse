using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResult>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateCategoryCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryFromDb = await _context.Categories.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);

            var category = _mapper.Map(request, categoryFromDb);
            category.AddDomainEvent(new CategoryUpdatedEvent(category));

            _context.Categories.Attach(category);
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new CategoryUpdatedEvent(category), cancellationToken);

            return _mapper.Map(category, new UpdateCategoryCommandResult());
        }
    }
}

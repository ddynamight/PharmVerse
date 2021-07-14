using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Categories;
using PharmVerse.Domain.Products;
using PharmVerse.Presentation.Categories.Commands;
using PharmVerse.Presentation.Categories.Models.Results;

namespace PharmVerse.Presentation.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCategoryCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            

            category.AddDomainEvent(new CategoryCreatedEvent(category));
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new CategoryCreatedEvent(category), cancellationToken);

            return _mapper.Map(category, new CreateCategoryCommandResult());
        }
    }
}

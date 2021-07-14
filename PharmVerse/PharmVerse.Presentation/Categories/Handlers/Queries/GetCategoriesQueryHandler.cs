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
using PharmVerse.Presentation.Categories.Models.Results;
using PharmVerse.Presentation.Categories.Queries;
using PharmVerse.Presentation.Invites.Models.Results;

namespace PharmVerse.Presentation.Categories.Handlers.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<GetCategoryQueryResult>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetCategoriesQueryHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<GetCategoryQueryResult>> Handle(GetCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            await _mediator.Publish(new AllCategoriesAccessedEvent(categories), cancellationToken);
            return _mapper.Map<IEnumerable<GetCategoryQueryResult>>(categories);
        }
    }
}

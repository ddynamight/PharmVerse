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
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, GetCategoryQueryResult>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetCategoryQueryHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<GetCategoryQueryResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
            await _mediator.Publish(new CategoryAccessedEvent(category), cancellationToken);
            return _mapper.Map<GetCategoryQueryResult>(category);
        }
    }
}

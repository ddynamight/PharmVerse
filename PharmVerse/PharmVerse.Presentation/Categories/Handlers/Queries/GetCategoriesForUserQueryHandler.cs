using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Presentation.Categories.Models.Results;
using PharmVerse.Presentation.Categories.Queries;

namespace PharmVerse.Presentation.Categories.Handlers.Queries
{
    public class GetCategoriesForUserQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<GetCategoryQueryResult>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetCategoriesForUserQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetCategoryQueryResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {

            //todo, implementation of the handle;
            throw new NotImplementedException();
        }
    }
}

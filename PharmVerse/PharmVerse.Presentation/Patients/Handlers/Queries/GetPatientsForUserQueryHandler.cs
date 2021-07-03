using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Patients;
using PharmVerse.Presentation.Patients.Models.Result;
using PharmVerse.Presentation.Patients.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Handlers.Queries
{
     class GetPatientsForUserQueryHandler : IRequestHandler<GetPatientsForUserQuery, IEnumerable<GetPatientQueryResult>>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public GetPatientsForUserQueryHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _mediator = mediator;
          }

          public async Task<IEnumerable<GetPatientQueryResult>> Handle(GetPatientsForUserQuery request, CancellationToken cancellationToken)
          {
               var patients = await _context.Patients.Where(p => p.Id.Equals(request.AppUserId)).ToListAsync(cancellationToken);
               await _mediator.Publish(new AllPatientAccessedEvent(patients), cancellationToken);

               return _mapper.Map<IEnumerable<GetPatientQueryResult>>(patients);
          }
     }
}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Patients.Patients;
using PharmVerse.Presentation.Patients.Models.Result;
using PharmVerse.Presentation.Patients.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Handlers.Queries
{


        public class GetPatientsQueryHandler : IRequestHandler<GetPatientsForUserQuery, IEnumerable<GetPatientQueryResult>>
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            public GetPatientsQueryHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }

            public async Task<IEnumerable<GetPatientQueryResult>> Handle(GetPatientsForUserQuery request, CancellationToken cancellationToken)
            {
                var patient = await _context.Patients.Where(p => p.Id.Equals(request.AppUserId)).ToListAsync(cancellationToken);
                await _mediator.Publish(new AllPatientAccessedEvent(patient), cancellationToken);

                return _mapper.Map<IEnumerable<GetPatientQueryResult>>(patient);
            }
        
    }

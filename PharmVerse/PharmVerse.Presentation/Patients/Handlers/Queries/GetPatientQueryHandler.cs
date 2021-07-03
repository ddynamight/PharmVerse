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
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, GetPatientQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IAppDbContext _context;

        public GetPatientQueryHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<GetPatientQueryResult> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients.SingleAsync(p => p.Id.Equals(request.Id), cancellationToken);
            await _mediator.Publish(new PatientAccessedEvent(patient), cancellationToken);
            return _mapper.Map<GetPatientQueryResult>(patient);
            
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Patients.Patients;
using PharmVerse.Presentation.Patients.Commands;
using PharmVerse.Presentation.Patients.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Handlers.Commands
{
    public class UpdatePatientCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;
        private readonly IMediator _mediator;

        public UpdatePatientCommandHandler(IMediator mediator, IAppDbContext context, IMapper mapper)
        {
            _context = context; 
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UpdatePatientCommandResult> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientFromDb = await _context.Patients.SingleAsync(p => p.Id.Equals(request.Id), cancellationToken);

            var patient = _mapper.Map(request, patientFromDb);
            patient.AddDomainEvent(new PatientUpdatedEvent(patient));
            _context.Patients.Attach(patient);
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new PatientUpdatedEvent(patient), cancellationToken);

            return _mapper.Map(patient, new UpdatePatientCommandResult());
        }
    }
}

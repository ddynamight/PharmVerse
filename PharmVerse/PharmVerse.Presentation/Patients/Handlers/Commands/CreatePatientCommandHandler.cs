using AutoMapper;
using MediatR;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Patients;
using PharmVerse.Domain.Patients;
using PharmVerse.Presentation.Patients.Commands;
using PharmVerse.Presentation.Patients.Models.Result;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Handlers.Commands
{
     public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatePatientCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public CreatePatientCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _mediator = mediator;
          }

          public async Task<CreatePatientCommandResult> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
          {
               var patient = _mapper.Map<Patient>(request);
               patient.Created = DateTime.Now;

               patient.AddDomainEvent(new PatientCreatedEvent(patient));
               await _context.Patients.AddAsync(patient, cancellationToken);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new PatientCreatedEvent(patient), cancellationToken);
               return _mapper.Map(patient, new CreatePatientCommandResult());
          }
     }
}

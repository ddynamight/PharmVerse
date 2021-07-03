using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Patients;
using PharmVerse.Presentation.Patients.Commands;
using PharmVerse.Presentation.Patients.Models.Result;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Handlers.Commands
{
     public class DeletePatientCommandHandler
     {
          private readonly IMediator _mediator;
          private readonly IAppDbContext _context;

          public DeletePatientCommandHandler(IAppDbContext context, IMediator mediator)
          {
               _context = context;
               _mediator = mediator;
          }

          public async Task<DeletePatientCommandResult> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
          {
               var patient = await _context.Patients.SingleAsync(p => p.Id.Equals(request.Id), cancellationToken);
               patient.AddDomainEvent(new PatientDeletedEvent(patient));
               _context.Patients.Remove(patient);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new PatientDeletedEvent(patient), cancellationToken);

               return new DeletePatientCommandResult
               {
                    Id = request.Id,
                    IsDeleted = true,
                    Message = $"Patient with Id {request.Id} is deleted successfully"
               };
          }
     }
}
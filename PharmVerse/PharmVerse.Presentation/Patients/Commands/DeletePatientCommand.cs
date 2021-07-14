using MediatR;
using PharmVerse.Presentation.Patients.Models.Result;
using System;

namespace PharmVerse.Presentation.Patients.Commands
{
     public class DeletePatientCommand : IRequest<DeletePatientCommandResult>
     {
          public Guid Id { get; set; }
     }
}
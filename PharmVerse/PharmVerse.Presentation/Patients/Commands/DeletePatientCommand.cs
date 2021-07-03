using MediatR;
using PharmVerse.Presentation.Patients.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Commands
{
    public class DeletePatientCommand : IRequest<DeletePatientCommandResult>
    {
        public Guid Id { get; set; }
    }
}

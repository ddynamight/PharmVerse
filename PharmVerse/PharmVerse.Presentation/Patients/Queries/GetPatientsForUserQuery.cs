using MediatR;
using PharmVerse.Presentation.Patients.Models.Result;
using System.Collections.Generic;

namespace PharmVerse.Presentation.Patients.Queries
{
     public class GetPatientsForUserQuery : IRequest<IEnumerable<GetPatientQueryResult>>
     {
          public string AppUserId { get; set; }

     }
}
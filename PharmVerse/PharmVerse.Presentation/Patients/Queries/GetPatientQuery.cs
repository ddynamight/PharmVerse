using MediatR;
using PharmVerse.Presentation.Patients.Models.Result;
using System;

namespace PharmVerse.Presentation.Patients.Queries
{
     public class GetPatientQuery : IRequest<GetPatientQueryResult>
     {
          public Guid Id { get; set; }
     }
}

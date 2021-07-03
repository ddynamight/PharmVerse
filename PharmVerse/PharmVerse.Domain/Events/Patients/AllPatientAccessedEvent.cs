using MediatR;
using PharmVerse.Domain.Patients;
using System.Collections.Generic;

namespace PharmVerse.Domain.Events.Patients
{
     public class AllPatientAccessedEvent : INotification
     {
          public AllPatientAccessedEvent(List<Patient> patient)
          {
               Patient = patient;
          }
          public List<Patient> Patient { get; }

     }
}
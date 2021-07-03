using MediatR;
using PharmVerse.Domain.Patients;

namespace PharmVerse.Domain.Events.Patients
{
     public class PatientAccessedEvent : INotification
     {
          public PatientAccessedEvent(Patient patient)
          {
               Patient = patient;
          }

          public Patient Patient { get; }

     }
}
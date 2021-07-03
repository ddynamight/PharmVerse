using MediatR;
using PharmVerse.Domain.Patients;

namespace PharmVerse.Domain.Events.Patients
{
     public class PatientCreatedEvent : INotification
     {
          public PatientCreatedEvent(Patient patient)
          {
               Patient = patient;
          }
          public Patient Patient { get; }
     }
}
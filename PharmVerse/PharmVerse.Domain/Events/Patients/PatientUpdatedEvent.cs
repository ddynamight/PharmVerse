using MediatR;
using PharmVerse.Domain.Patients;

namespace PharmVerse.Domain.Events.Patients
{
     public class PatientUpdatedEvent : INotification
     {
          public PatientUpdatedEvent(Patient patient)
          {
               Patient = patient;
          }
          public Patient Patient { get; }
     }
}
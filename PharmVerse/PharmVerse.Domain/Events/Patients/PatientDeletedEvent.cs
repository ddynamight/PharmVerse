using MediatR;
using PharmVerse.Domain.Patients;

namespace PharmVerse.Domain.Events.Patients
{
     public class PatientDeletedEvent : INotification
     {
          public PatientDeletedEvent(Patient patient)
          {
               Patient = patient;
          }
          public Patient Patient { get; }
     }
}
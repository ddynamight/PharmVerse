using MediatR;

namespace PharmVerse.Domain.Patients.Patients
{
    public class PatientCreatedEvent : INotification
    {
        public Patient Patient { get; }
        public PatientCreatedEvent(Patient patient)
        {
            Patient = patient;
        }
    }
}

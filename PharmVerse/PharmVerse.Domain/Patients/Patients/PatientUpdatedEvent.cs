using MediatR;

namespace PharmVerse.Domain.Patients.Patients
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

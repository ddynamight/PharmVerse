using MediatR;

namespace PharmVerse.Domain.Patients.Patients
{
    public class PatientAccessedEvent : INotification
    {
        public Patient Patient { get; }
        public PatientAccessedEvent(Patient patient)
        {
            Patient = patient;
        }
    }
}

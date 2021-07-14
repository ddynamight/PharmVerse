using MediatR;

namespace PharmVerse.Domain.Patients.Patients
{
    public class PatientDeletedEvent : INotification
    {
        public Patient Patient { get; }
        public PatientDeletedEvent(Patient patient)
        {
            Patient = patient;
        }
    }
}

using System.Collections.Generic;
using MediatR;

namespace PharmVerse.Domain.Patients.Patients
{
    public class AllPatientAccessedEvent : INotification
    {
        public List<Patient> Patients { get; }

        public AllPatientAccessedEvent(List<Patient> patients)
        {
            Patients = patients;
        }
    }
}

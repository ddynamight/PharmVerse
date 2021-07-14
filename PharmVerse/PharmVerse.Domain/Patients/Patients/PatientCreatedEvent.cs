using MediatR;
using PharmVerse.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

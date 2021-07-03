using MediatR;
using PharmVerse.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Patients.Patients
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

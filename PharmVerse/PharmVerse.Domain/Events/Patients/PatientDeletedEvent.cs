using MediatR;
using PharmVerse.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Events.Patients
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

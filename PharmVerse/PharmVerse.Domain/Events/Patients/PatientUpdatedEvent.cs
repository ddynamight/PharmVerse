using MediatR;
using PharmVerse.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

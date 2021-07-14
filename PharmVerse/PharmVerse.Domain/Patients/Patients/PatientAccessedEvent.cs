using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

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
        public PatientAccessedEvent(Patient patient)
        {
            Patient = patient;
        }

        public Patient Patient { get; }

    }

}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Patients.Patients
{
    public class AllPatientAccessedEvent : INotification
    {
        public AllPatientAccessedEvent(List<Patient> patient)
        {
            Patient = patient;
        }
        public List<Patient> Patient { get; }

    }
}

using MediatR;
using PharmVerse.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Events.Patients
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

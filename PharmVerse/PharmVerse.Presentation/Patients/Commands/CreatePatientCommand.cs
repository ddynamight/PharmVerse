using MediatR;
using PharmVerse.Presentation.Patients.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Commands
{
    public class CreatePatientCommand : IRequest<CreatePatientCommandResult>
    {
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string DoctorInCharge { get; set; }
        public string Ailment { get; set; }
    }
}

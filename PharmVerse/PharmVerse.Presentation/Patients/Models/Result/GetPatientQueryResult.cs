using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Models.Result
{
    public class GetPatientQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DoctorInCharge { get; set; }
        public string Ailment { get; set; }


    }
}

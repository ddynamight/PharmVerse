using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Models.Result
{
    public class DeletePatientCommandResult
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Message { get; set; }

    }
}

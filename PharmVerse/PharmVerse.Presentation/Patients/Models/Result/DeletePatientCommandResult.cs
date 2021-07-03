using System;

namespace PharmVerse.Presentation.Patients.Models.Result
{
     public class DeletePatientCommandResult
     {
          public Guid Id { get; set; }
          public bool IsDeleted { get; set; }
          public string Message { get; set; }

     }
}
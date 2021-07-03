using System;

namespace PharmVerse.Presentation.Patients.Models.Result
{
     public class UpdatePatientCommandResult
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
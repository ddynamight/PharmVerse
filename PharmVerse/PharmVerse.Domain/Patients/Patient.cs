using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Patients
{
     public class Patient : Entity, IHasDomainEvent
     {
          public string DoctorsInCharge { get; set; }
          public string Ailment { get; set; }
          public DateTime Created { get; set; }
          public DateTime LastOnline { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
     }
}
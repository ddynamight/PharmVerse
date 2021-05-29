using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Products
{
     public class Category : Entity, IHasDomainEvent
     {
          public string Name { get; set; }
          public DateTime Created { get; set; }
          public bool IsDeleted { get; set; }
          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
     }
}

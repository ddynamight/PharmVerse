using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Products
{
     public class Product : Entity, IHasDomainEvent
     {
          public string Name { get; set; }
          public int Stock { get; set; }
          public decimal Price { get; set; }
          public DateTime Created { get; set; }
          public Guid CategoryId { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Many Product Relationship
          public virtual Category Category { get; set; }
     }
}

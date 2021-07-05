using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;

namespace PharmVerse.Domain.Products
{
     public class Category : Entity, IHasDomainEvent
     {
          public string Name { get; set; }
          public string Description { get; set; }
          public string Slug { get; set; }
          public DateTime Created { get; set; }
          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Many Relationships
          public ICollection<Product> Products { get; set; } = new HashSet<Product>();
     }
}
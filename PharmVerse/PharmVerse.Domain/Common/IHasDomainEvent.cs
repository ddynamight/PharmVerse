using System.Collections.Generic;

namespace PharmVerse.Domain.Common
{
     public interface IHasDomainEvent
     {
          public List<DomainEvent> DomainEvents { get; set; }
     }
}

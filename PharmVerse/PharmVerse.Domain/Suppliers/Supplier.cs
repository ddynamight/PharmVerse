using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Models
{
    public class Supplier : Entity, IHasDomainEvent
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Contact { get; set; } 
        public string Email { get; set; }
        public DateTime Created { get; set; } 

        public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

    }
}

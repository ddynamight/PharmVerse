using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Staffs
{
    public class Staff : Entity, IHasDomainEvent
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; } 
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastOnline { get; set; }     

        public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}

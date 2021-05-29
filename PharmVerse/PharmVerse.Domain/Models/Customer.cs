using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Models
{
    public class Customer
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; } 
        public DateTime LastOnline { get; set; }
        public bool IsVerified { get; set; }
        public bool IsArchived { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; } 
    }
}

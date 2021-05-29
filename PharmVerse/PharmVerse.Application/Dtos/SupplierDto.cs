using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Application.Dtos
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

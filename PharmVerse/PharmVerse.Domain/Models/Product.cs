using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Models
{
    public class Product
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool isDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Category Category { get; set; }
    }
}

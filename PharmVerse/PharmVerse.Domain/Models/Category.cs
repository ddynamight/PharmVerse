using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Models
{
    public class Category
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool isDeleted { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Models
{
    public class Expenses
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string ExpenseType { get; set; } 
        public decimal Amount { get; set; } 
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

    }
}

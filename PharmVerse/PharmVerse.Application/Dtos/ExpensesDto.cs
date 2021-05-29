using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Application.Dtos
{
    public class ExpensesDto
    {
        public Int64 Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ExpenseType { get; set; }
        [Required]
        public decimal Amount { get; set; } 
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

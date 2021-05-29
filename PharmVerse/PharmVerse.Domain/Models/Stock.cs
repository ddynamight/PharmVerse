using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int PurchaseUnit { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public int RestockUnit { get; set; }
        public DateTime StockDate { get; set; }
        public DateTime LastRestockDate { get; set; }
    }
}

using PharmVerse.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Stocks
{
    public class Stock : Entity, IHasDomainEvent
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public decimal SalesPrice { get; set; }
        public int Quantity { get; set; }
        public int RestockUnit { get; set; }
        public DateTime StockDate { get; set; }
        public DateTime LastRestockDate { get; set; }
        public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}

using MediatR;
using PharmVerse.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Events.Categories
{
    public class AllCategoriesAccessedEvent : INotification
    {
        public List<Category> Categories { get; }
        public AllCategoriesAccessedEvent(List<Category> categories)
        {
            Categories = categories;
        }
    }
}

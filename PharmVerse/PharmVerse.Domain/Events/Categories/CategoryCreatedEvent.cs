using MediatR;
using PharmVerse.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmVerse.Domain.Events.Categories
{
    public class CategoryCreatedEvent : INotification
    {
        public Category Category { get; }
        public CategoryCreatedEvent(Category category)
        {
            Category = category;
        }
    }
}

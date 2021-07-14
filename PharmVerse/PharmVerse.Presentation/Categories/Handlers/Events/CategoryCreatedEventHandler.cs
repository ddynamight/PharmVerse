using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Events.Categories;

namespace PharmVerse.Presentation.Categories.Handlers.Events
{
    public class CategoryCreatedEventHandler : INotificationHandler<CategoryCreatedEvent>
    {
        private readonly ILogger<CategoryCreatedEventHandler> _logger;

        public CategoryCreatedEventHandler(ILogger<CategoryCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.Category.DomainEvents;

            _logger.LogInformation($"Category Created Event: {domainEvent.GetType().Name} succeeded for Category with Name: " +
                                   $"{notification.Category.Name} and Id: {notification.Category.Id}");
            
            return Task.CompletedTask;
        }
    }
}

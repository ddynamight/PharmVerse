using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Events.Categories;

namespace PharmVerse.Presentation.Categories.Handlers.Events
{
    public class CategoryAccessedEventHandler : INotificationHandler<CategoryAccessedEvent>
    {
        private readonly ILogger<CategoryAccessedEventHandler> _logger;

        public CategoryAccessedEventHandler(ILogger<CategoryAccessedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CategoryAccessedEvent notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.Category.DomainEvents;

            _logger.LogInformation($"Category Accessed Event: {domainEvent.GetType().Name} succeeded for Category with Name: " +
                                   $"{notification.Category.Name} and Id: {notification.Category.Id}");

            return Task.CompletedTask;
        }
    }
}

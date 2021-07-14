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
    public class AllCategoriesAccessedEventHandler : INotificationHandler<AllCategoriesAccessedEvent>
    {
        private readonly ILogger<AllCategoriesAccessedEventHandler> _logger;

        public AllCategoriesAccessedEventHandler(ILogger<AllCategoriesAccessedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AllCategoriesAccessedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"All Categories Accessed Event: {notification.Categories.Capacity} Categories accessed successfully");

            return Task.CompletedTask;
        }
    }
}

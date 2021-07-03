using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Patients.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Handlers.Events
{
    public class PatientDeletedEventHandler : INotificationHandler<PatientDeletedEvent>
    {
        private readonly ILogger<PatientAccessedEventHandler> _logger;

        public PatientDeletedEventHandler(ILogger<PatientAccessedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(PatientDeletedEvent notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.Patient.DomainEvents;
            _logger.LogInformation($"Patient Deleted Event {domainEvent.GetType().Name} succeeded  for patient with name " +
                $"{notification.Patient.FirstName} {notification.Patient.LastName} and Id {notification.Patient.Id}");

            return Task.CompletedTask;
        }
    }
}

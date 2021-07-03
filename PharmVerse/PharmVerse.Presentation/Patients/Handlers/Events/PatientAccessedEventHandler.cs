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
    public class PatientAccessedEventHandler
    {
        private readonly ILogger<PatientAccessedEventHandler> _logger;

        public PatientAccessedEventHandler(ILogger<PatientAccessedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(PatientAccessedEvent notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.Patient.DomainEvents;
            _logger.LogInformation($"Patient Accessed Event {domainEvent.GetType().Name} succeeded for patient with name " +
                $"{notification.Patient.FirstName} {notification.Patient.LastName} and Id {notification.Patient.Id}");
            return Task.CompletedTask;
        }
    }
}

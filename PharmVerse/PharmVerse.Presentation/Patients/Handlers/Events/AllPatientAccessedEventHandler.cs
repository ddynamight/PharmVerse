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
    public class AllPatientAccessedEventHandler
    {
        private readonly ILogger<AllPatientAccessedEventHandler> _logger;

        public AllPatientAccessedEventHandler(ILogger<AllPatientAccessedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AllPatientAccessedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"All Patient accessed Event: {notification.Patient.Capacity} Patients accessed Successfully");

            return Task.CompletedTask;
        }
    }
}

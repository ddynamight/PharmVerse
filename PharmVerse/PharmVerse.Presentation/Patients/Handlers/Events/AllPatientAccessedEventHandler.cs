<<<<<<< HEAD
﻿using MediatR;
using Microsoft.Extensions.Logging;
=======
﻿using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Events.Patients;
>>>>>>> main
using System.Threading;
using System.Threading.Tasks;
using PharmVerse.Domain.Patients.Patients;

namespace PharmVerse.Presentation.Patients.Handlers.Events
{
<<<<<<< HEAD
    public class AllPatientAccessedEventHandler : INotificationHandler<AllPatientAccessedEvent>
    {
        private readonly ILogger<AllPatientAccessedEventHandler> _logger;
=======
     public class AllPatientAccessedEventHandler
     {
          private readonly ILogger<AllPatientAccessedEventHandler> _logger;
>>>>>>> main

          public AllPatientAccessedEventHandler(ILogger<AllPatientAccessedEventHandler> logger)
          {
               _logger = logger;
          }

<<<<<<< HEAD
        public Task Handle(AllPatientAccessedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"All Patient accessed Event: {notification.Patients.Capacity} Patients accessed Successfully");
=======
          public Task Handle(AllPatientAccessedEvent notification, CancellationToken cancellationToken)
          {
               _logger.LogInformation($"All Patient accessed Event: {notification.Patient.Capacity} Patients accessed Successfully");
>>>>>>> main

               return Task.CompletedTask;
          }
     }
}
using FormulaOne.Entities.Contracts;
using FormulaOne.Services.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Services
{
    public class DriverNotificationPublisherService : IDriverNotificationPublisherService
    {
        private readonly ILogger _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public DriverNotificationPublisherService(IPublishEndpoint publishEndpoint, ILogger<DriverNotificationPublisherService> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task SentNotification(Guid driverId, string teamName)
        {
            _logger.LogInformation("Driver Notification for " + driverId);
            await _publishEndpoint.Publish(new DriverNotificationRecord(driverId, teamName));
        }
    }
}

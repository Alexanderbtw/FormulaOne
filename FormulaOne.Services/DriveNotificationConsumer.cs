using FormulaOne.Entities.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FormulaOne.Services
{
    public class DriveNotificationConsumer : IConsumer<DriverNotificationRecord>
    {
        private readonly ILogger _logger;

        public DriveNotificationConsumer(ILogger<DriveNotificationConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<DriverNotificationRecord> context)
        {
            _logger.LogInformation("FIA Log: " + context.Message.DriverId + " Name: " + context.Message.DriverName);
            return Task.CompletedTask;
        }
    }
}

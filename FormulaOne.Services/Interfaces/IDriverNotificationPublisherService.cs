namespace FormulaOne.Services.Interfaces
{
    public interface IDriverNotificationPublisherService
    {
        Task SentNotification(Guid driverId, string teamName);
    }
}

namespace Catalog.Product.EventHandlers;

public class ProductCreateEventHandler(ILogger<ProductCreateEventHandler> logger) : INotificationHandler<ProductCreateEvent>
{
    public Task Handle(ProductCreateEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(ProductCreateEventHandler)} create event handler called");
        return Task.CompletedTask;
    }
}
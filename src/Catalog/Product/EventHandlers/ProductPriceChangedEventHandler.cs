namespace Catalog.Product.EventHandlers;

public class ProductPriceChangedEventHandler(ILogger<ProductCreateEventHandler> logger) : INotificationHandler<ProductPriceChangedEvent>
{
    public Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(ProductPriceChangedEventHandler)} create event handler called");
        return Task.CompletedTask;
    }
}
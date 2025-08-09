namespace Catalog.Product.Events;

public record ProductPriceChangedEvent(Models.Product Product): IDomainEvent;
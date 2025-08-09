namespace Catalog.Product.Events;

public record ProductCreateEvent(Models.Product Product) : IDomainEvent;
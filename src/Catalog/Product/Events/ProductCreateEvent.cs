using Shared.DDD.DomainEvents;

namespace Catalog.Product.Events;

public record ProductCreateEvent(Models.Product Product) : IDomainEvent;
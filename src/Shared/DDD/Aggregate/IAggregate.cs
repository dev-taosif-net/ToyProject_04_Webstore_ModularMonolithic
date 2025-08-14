using Shared.DDD.DomainEvents;
using Shared.DDD.Entities;

namespace Shared.DDD.Aggregate;

public interface IAggregate<T> : IAggregate  , IEntity<T>
{
}

public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}
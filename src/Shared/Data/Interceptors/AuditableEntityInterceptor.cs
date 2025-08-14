using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.DDD.Entities;

namespace Shared.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateEntities(eventData.Context);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        foreach (var entity in context.ChangeTracker.Entries<IEntity>())
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.Entity.CreatedAt = DateTime.UtcNow;
                    entity.Entity.CreatedBy = "Taosif";
                    break;
                case EntityState.Modified when entity.HasChangedOwnedEntities():
                case EntityState.Modified:
                    entity.Entity.LastModifiedAt = DateTime.UtcNow;
                    entity.Entity.LastModifiedBy = "Taosif";
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            r.TargetEntry.State is EntityState.Added or EntityState.Modified);
}
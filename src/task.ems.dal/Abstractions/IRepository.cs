namespace task.ems.dal.Abstractions;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    ValueTask<EntityEntry<TEntity>> CreateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    );
    EntityEntry<TEntity> Create(TEntity entity);
    void CreateRange(IEnumerable<TEntity> entities);
    Task CreateRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default
    );
    EntityEntry<TEntity> Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    EntityEntry<TEntity> Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
    ValueTask<TEntity> FindAsync(long id, CancellationToken cancellationToken = default);
    TEntity Find(long id, CancellationToken cancellationToken = default);
    ValueTask<bool> AnyAsync(
        Expression<Func<TEntity, bool>> pridecate,
        CancellationToken cancellationToken = default
    );
    bool Any(Expression<Func<TEntity, bool>> pridecate);
    ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default);
    bool Any();

    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<int> CountAsync(
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default
    );
}

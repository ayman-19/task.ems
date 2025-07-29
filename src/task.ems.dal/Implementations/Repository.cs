namespace task.ems.dal.Implementations;

internal class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    protected readonly EMSDbContext _context;
    protected readonly DbSet<TEntity> _entities;

    public Repository(EMSDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public ValueTask<EntityEntry<TEntity>> CreateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    ) => _entities.AddAsync(entity, cancellationToken);

    public EntityEntry<TEntity> Create(TEntity entity) => _entities.Add(entity);

    public EntityEntry<TEntity> Update(TEntity entity) => _entities.Update(entity);

    public EntityEntry<TEntity> Delete(TEntity entity) => _entities.Remove(entity);

    public void CreateRange(IEnumerable<TEntity> entities) => _entities.AddRange(entities);

    public Task CreateRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default
    ) => _entities.AddRangeAsync(entities, cancellationToken);

    public void UpdateRange(IEnumerable<TEntity> entities) => _entities.UpdateRange(entities);

    public void DeleteRange(IEnumerable<TEntity> entities) => _entities.RemoveRange(entities);

    public ValueTask<TEntity> FindAsync(long id, CancellationToken cancellationToken = default) =>
        _entities.FindAsync(id, cancellationToken);

    public TEntity Find(long id, CancellationToken cancellationToken = default) =>
        _entities.Find(id);

    public async ValueTask<bool> AnyAsync(
        Expression<Func<TEntity, bool>> pridecate,
        CancellationToken cancellationToken = default
    ) => await _entities.AnyAsync(pridecate, cancellationToken);

    public bool Any(Expression<Func<TEntity, bool>> pridecate) => _entities.Any(pridecate);

    public async ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default) =>
        await _entities.AnyAsync(cancellationToken);

    public bool Any() => _entities.Any();

    public Task<int> CountAsync(CancellationToken cancellationToken = default) =>
        _entities.CountAsync(cancellationToken);

    public Task<int> CountAsync(
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default
    ) => _entities.CountAsync(filter, cancellationToken);
}

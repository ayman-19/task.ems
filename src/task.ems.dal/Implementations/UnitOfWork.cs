namespace task.ems.dal.Implementations;

public sealed class UnitOfWork : IUnitOfWork
{
    readonly EMSDbContext _context;

    public UnitOfWork(EMSDbContext context) => _context = context;

    public int SaveChanges() => _context.SaveChanges();

    public bool SaveChanges(int expectedModifiedRows)
    {
        var modifiedRows = _context.SaveChanges();
        return modifiedRows == expectedModifiedRows;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);

    public async Task<bool> SaveChangesAsync(
        int expectedModifiedRows,
        CancellationToken cancellationToken = default
    )
    {
        var modifiedRows = await _context.SaveChangesAsync();
        return modifiedRows == expectedModifiedRows;
    }

    public Task<IDbContextTransaction> BeginTransactionAsync(
        CancellationToken cancellationToken = default
    ) => _context.Database.BeginTransactionAsync(cancellationToken);

    public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();
}

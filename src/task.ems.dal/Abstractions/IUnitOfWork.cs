namespace task.ems.dal.Abstractions;

public interface IUnitOfWork
{
    Task<IDbContextTransaction> BeginTransactionAsync(
        CancellationToken cancellationToken = default
    );
    IDbContextTransaction BeginTransaction();

    int SaveChanges();
    bool SaveChanges(int expectedModifiedRows);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveChangesAsync(
        int expectedModifiedRows,
        CancellationToken cancellationToken = default
    );
}

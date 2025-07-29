namespace task.ems.dal.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> Paginate<T>(
        this IQueryable<T> query,
        int index,
        int size,
        CancellationToken cancellationToken = default
    ) => query.Skip((index - 1) * size).Take(size);

    public static bool HasValue(this string value)
    {
        return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
    }
}

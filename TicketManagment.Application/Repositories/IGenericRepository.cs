namespace TicketManagment.Application.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    TEntity? Get(object id);

    IEnumerable<TEntity> GetAll();

    IQueryable<TEntity> AsQueryable();

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    // This method was not in the videos, but I thought it would be useful to add.
    TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

    bool Any(Expression<Func<TEntity, bool>> predicate);

    TEntity Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    TEntity Update(TEntity entity);

    void Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);

    Task<TEntity?> GetAsync(object id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    // This method was not in the videos, but I thought it would be useful to add.
    Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> AddAsync(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task RemoveAsync(TEntity entity);

    Task RemoveRangeAsync(IEnumerable<TEntity> entities);
}
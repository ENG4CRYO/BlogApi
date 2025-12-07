using System.Linq.Expressions;

public interface IGenericRepo<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

    
    Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

    //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip);
    //Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
    //    Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC");
    

    Task<T> AddAsync(T entity);
    //Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

    T Update(T entity);
    void Delete(T entity);

    Task SaveChangesAsync();
    //void DeleteRange(IEnumerable<T> entities);

    //Task<int> CountAsync();
    //Task<int> CountAsync(Expression<Func<T, bool>> criteria);
}


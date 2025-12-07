using Blog.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly AppDbContext _context;
    internal DbSet<T> _dbSet;

    public GenericRepo(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach(var iclude in includes)
            {
                query = query.Include(iclude);
            }
        }

        return await query.SingleOrDefaultAsync(criteria);
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T,bool>> criteria, string[] includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var iclude in includes)
            {
                query = query.Include(iclude);
            }
        }

        return await query.Where(criteria).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        _context.SaveChanges();
        return entity;
    }

    public T Update (T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}


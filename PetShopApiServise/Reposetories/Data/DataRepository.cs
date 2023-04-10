using PetShopApiServise.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PetShopApiServise.Attributes.ExeptionAttributes;

namespace PetShopApiServise.Reposetories.Data;

[PetShopExceptionFilter]
public class DataRepository<T> : IDataRepository<T> where T : class
{
    private readonly PetShopDBContext _context;

    public DataRepository(PetShopDBContext context) => _context = context;

    public async Task<int> Post(T entity)
    {

        _context.Set<T>().Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        var element = await _context.Set<T>().FindAsync(id);
        return element!;
    }

    public async Task<int> Put(T entity)
    {
        _context.Set<T>().Update(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteById(int id)
    {
        var entity = await GetById(id);
        if (entity == null)
        {
            return -1;
        }

        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<T>> GetAllById(int id)
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
    {
        return await _context.Set<T>().Where(condition).ToListAsync();
    }

    public async Task<int> DeleteByCondition(Expression<Func<T, bool>> condition)
    {
        var entities = await _context.Set<T>().Where(condition).ToListAsync();
        _context.Set<T>().RemoveRange(entities);
        return await _context.SaveChangesAsync();
    }
}

using System.Linq.Expressions;

namespace PetShopApiServise.Reposetories.Data;

public interface IDataRepository<T>
{
    Task<int> DeleteById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAllById(int id);
    Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition);
    Task<int> DeleteByCondition(Expression<Func<T, bool>> condition);
    Task<T> GetById(int id);
    Task<int> Post(T entity);
    Task<int> Put(T entity);
}

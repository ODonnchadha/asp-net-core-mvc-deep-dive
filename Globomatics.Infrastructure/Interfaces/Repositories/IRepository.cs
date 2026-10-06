namespace Globomatics.Infrastructure.Interfaces.Repositories;

public interface IRepository<T>
{
    T Add(T entity);
    T Update(T entity);
    T? Get(Guid id);
    IEnumerable<T> All();
    void SaveChanges();
}

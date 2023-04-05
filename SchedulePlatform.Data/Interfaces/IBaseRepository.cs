using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Delete(T entity);
        List<T> GetAll();
        T? GetById(Guid id);
        T Update(T entity);
    }
}
using Core.Entity;

namespace Core.Interface.Generic;

public interface IGenericRepository<T> where T :BaseEntity
{
    Task<T> GetById(object id);
    Task<IReadOnlyList<T>> GetAll();
}
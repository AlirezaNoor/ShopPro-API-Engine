using Core.Entity;
using Core.Interface.Generic;

namespace Infrastructure.Data.Repository.GenericRepository;

public class GenericRepositories<T> :IGenericRepository<T> where T :BaseEntity
{
    public Task<T> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAll()
    {
        throw new NotImplementedException();
    }
}
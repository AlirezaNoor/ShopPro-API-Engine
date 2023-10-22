using Core.Entity;

namespace Core.Interface.Generic;

public interface IGenericRepository<T> where T : BaseEntity
{
    /// <summary>
    /// this  method is Generic .that means you can pass the class that is Entity .but Noteic that the entity class should be imharence from base entity
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetById(object id);

    Task<IReadOnlyList<T>> GetAll();
}
using Core.Entity;
using Core.Interface.Generic;
using Microsoft.EntityFrameworkCore;
using ShopStoreApi.Data.Context;

namespace Infrastructure.Data.Repository.GenericRepository;

public class GenericRepositories<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreContext _context;

    public GenericRepositories(StoreContext context)
    {
        _context = context;
    }

    public async Task<T> GetById(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }
}
using Core.Interface.IReposetory;
using Microsoft.EntityFrameworkCore;
using ShopStoreApi.Data.Context;

namespace Infrastructure.Data.Repository;

public class productRepository : IproductRepository
{
    private readonly StoreContext _context;

    public productRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<product> GetBtIdAsync(int Id)
    {
        return await _context.prooduct.FindAsync(Id);
    }

    public async Task<IReadOnlyList<product>> GetProductsAsync()
    {
        return await _context.prooduct.ToListAsync();
    }
}
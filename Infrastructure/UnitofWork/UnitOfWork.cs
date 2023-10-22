using Core.Interface.UnitofWork;
using Infrastructure.Data.Repository.GenericRepository;
using ShopStoreApi.Data.Context;

namespace Infrastructure.UnitofWork;

public class UnitOfWork : IUnitOfWork,IDisposable
{
    private readonly StoreContext _context;
    private GenericRepositories<product> _product;
    private GenericRepositories<ProductBrand> _productbrand;
    private GenericRepositories<ProductType> _productType;

    public UnitOfWork(StoreContext context)
    {
        _context = context;
    }

    public GenericRepositories<product> productuw
    {
        get
        {
            if (_product == null)
            {
                _product = new GenericRepositories<product>(_context);
            }

            return _product;
        }
    }

    public GenericRepositories<ProductBrand> productbranduw
    {
        get
        {
            if (_productbrand == null)
            {
                _productbrand = new GenericRepositories<ProductBrand>(_context);
            }

            return _productbrand;
        }
    }

    public GenericRepositories<ProductType> producttypeuw
    {
        get
        {
            if (_productType == null)
            {
                _productType = new GenericRepositories<ProductType>(_context);
            }

            return _productType;
        }
    }

    public void save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
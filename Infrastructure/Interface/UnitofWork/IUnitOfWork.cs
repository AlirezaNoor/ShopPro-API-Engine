using Infrastructure.Data.Repository.GenericRepository;

namespace Core.Interface.UnitofWork;

public interface IUnitOfWork
{
    GenericRepositories<product> productuw  { get; }
    GenericRepositories<ProductBrand> productbranduw { get; }
    GenericRepositories<ProductType> producttypeuw { get; }
}
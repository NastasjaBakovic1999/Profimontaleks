using Profimontaleks.Data;

namespace Profimontaleks.DataAccess
{
    public interface IRepositoryProductCardboard : IRepository<ProductCardboard>
    {
        public void Add(ProductCardboard productCardboard);
        public void Update(ProductCardboard productCardboard);
        public ProductCardboard GetById(int PCCNumber);
    }
}

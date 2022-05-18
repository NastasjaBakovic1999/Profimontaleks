using Profimontaleks.Data;

namespace Profimontaleks.Services.Interfaces
{
    public interface IServiceProductCardboard : IService<ProductCardboard>
    {
        public void Add(ProductCardboard productCardboard);
        public void Update(ProductCardboard productCardboard);
        public ProductCardboard GetById(int PCCNumber);
    }
}

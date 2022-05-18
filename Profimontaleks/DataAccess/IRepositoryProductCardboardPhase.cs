using Profimontaleks.Data;
using System.Collections.Generic;

namespace Profimontaleks.DataAccess
{
    public interface IRepositoryProductCardboardPhase : IRepository<ProductCardboardPhase>
    {
        public void Add(ProductCardboardPhase productCardboardPhase);
        public void Update(ProductCardboardPhase productCardboardPhase);
        public ProductCardboardPhase GetById(int id);
        public List<ProductCardboardPhase> GetAllByPCCNumber(int PCCNumber);
    }
}

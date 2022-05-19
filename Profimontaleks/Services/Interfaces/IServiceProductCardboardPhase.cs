using Profimontaleks.Data;
using System.Collections.Generic;

namespace Profimontaleks.Services.Interfaces
{
    public interface IServiceProductCardboardPhase : IService<ProductCardboardPhase>
    {
        public void Add(ProductCardboardPhase productCardboardPhase);
        public void Update(ProductCardboardPhase productCardboardPhase);
        public void Delete(int PCCNumber, int id);
        public ProductCardboardPhase GetById(int PCCNumber, int Id);
        public List<ProductCardboardPhase> GetAllByPCCNumber(int PCCNumber);
    }
}

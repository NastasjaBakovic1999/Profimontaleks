using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Services.Implementation
{
    public class ServiceProductType : IServiceProductType
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceProductType(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<ProductType> GetAll()
        {
            return unitOfWork.ProductType.GetAll();
        }
    }
}

using Profimontaleks.Data;
using Profimontaleks.DataAccess.UnitOfWork;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Services.Implementation
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceProduct(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Product> GetAll()
        {
            return unitOfWork.Product.GetAll();
        }
    }
}

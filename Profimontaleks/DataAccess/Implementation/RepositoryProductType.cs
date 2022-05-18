using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryProductType : IRepositoryProductType
    {
        private readonly ProfimontaleksContext context;

        public RepositoryProductType(ProfimontaleksContext context)
        {
            this.context = context;
        }

        public List<ProductType> GetAll()
        {
            try
            {
                return context.ProductTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

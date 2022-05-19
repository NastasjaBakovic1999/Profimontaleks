using Microsoft.EntityFrameworkCore;
using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly ProfimontaleksContext context;

        public RepositoryProduct(ProfimontaleksContext context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            try
            {
                return context.Products.Include(x => x.Type).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

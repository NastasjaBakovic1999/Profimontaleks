using Microsoft.EntityFrameworkCore;
using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryProductCardboard : IRepositoryProductCardboard
    {
        private readonly ProfimontaleksContext context;

        public RepositoryProductCardboard(ProfimontaleksContext context)
        {
            this.context = context;
        }

        public void Add(ProductCardboard productCardboard)
        {
            try
            {
                context.ProductCardboards.Add(productCardboard);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProductCardboard> GetAll()
        {
            try
            {
                return context.ProductCardboards.Include(p => p.Product).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductCardboard GetById(int PCCNumber)
        {
            try
            {
                return context.ProductCardboards.Include(p=>p.Product)
                                    .SingleOrDefault(s => s.PCCNumber == PCCNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ProductCardboard productCardboard)
        {
            try
            {
                context.ProductCardboards.Attach(productCardboard);
                context.Entry(productCardboard).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

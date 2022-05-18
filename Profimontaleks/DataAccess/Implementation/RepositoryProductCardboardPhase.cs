using Profimontaleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Profimontaleks.DataAccess.Implementation
{
    public class RepositoryProductCardboardPhase : IRepositoryProductCardboardPhase
    {
        private readonly ProfimontaleksContext context;

        public RepositoryProductCardboardPhase(ProfimontaleksContext context)
        {
            this.context = context;
        }
        public void Add(ProductCardboardPhase productCardboardPhase)
        {
            try
            {
                context.ProductCardboardPhases.Add(productCardboardPhase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProductCardboardPhase> GetAll()
        {
            try
            {
                return context.ProductCardboardPhases.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProductCardboardPhase> GetAllByPCCNumber(int PCCNumber)
        {
            try
            {
                return context.ProductCardboardPhases.Where(p => p.PCCNumber == PCCNumber).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductCardboardPhase GetById(int PCCNumber, int Id)
        {
            try
            {
                return context.ProductCardboardPhases.Find(PCCNumber, Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ProductCardboardPhase productCardboardPhase)
        {
            try
            {
                context.ProductCardboardPhases.Update(productCardboardPhase);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
